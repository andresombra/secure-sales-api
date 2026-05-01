using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using SecureSales.Application.Interfaces;
using SecureSales.Application.Services;
using SecureSales.Domain.Interfaces.Repositories;
using SecureSales.Infrastructure.Data;
using SecureSales.Infrastructure.Repositories;
using SecureSales.Infrastructure.Security;
using System;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// DB Context
//builder.Services.AddDbContext<AppDbContext>(options =>
//  options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
//    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));
//ou
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseMySql(
//        connectionString,
//        ServerVersion.AutoDetect(connectionString)
//    ));

// DI
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddMapster();

builder.Services.AddSingleton<ISecretProvider, KeyVaultSecretProvider>();
builder.Services.AddScoped<IConnectionStringFactory, ConnectionStringFactory>();

builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
{
    var factory = serviceProvider.GetRequiredService<IConnectionStringFactory>();
    var connectionString = factory.GetConnectionStringAsync().GetAwaiter().GetResult();

    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllers()
    .AddJsonOptions(opts =>
    {
        // Prevent serializer exceptions when cycles exist (ignore navigation back-references)
        opts.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var tenantId = builder.Configuration["KeyVault:TenantId"];
        var apiClientId = builder.Configuration["KeyVault:CientIdDaAPI"];

        options.Authority = $"https://login.microsoftonline.com/{tenantId}/v2.0";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidAudiences = new[]
            {
                apiClientId,
                $"api://{apiClientId}"
            },
            ValidIssuers = new[]
            {
                $"https://sts.windows.net/{tenantId}/",
                $"https://login.microsoftonline.com/{tenantId}/v2.0"
            }
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine($"[JWT] AuthenticationFailed: {context.Exception.Message}");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                var iss = context.Principal?.FindFirst("iss")?.Value;
                var aud = context.Principal?.FindFirst("aud")?.Value;
                Console.WriteLine($"[JWT] TokenValidated - iss: {iss}, aud: {aud}");
                return Task.CompletedTask;
            },
            OnChallenge = context =>
            {
                Console.WriteLine($"[JWT] Challenge - error: {context.Error}, desc: {context.ErrorDescription}");
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "SecureSales API",
    });

    // 1. Define o esquema Bearer
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Insira o token JWT. Exemplo: Bearer {seu token}"
    });

    //// 2. Exige o Bearer em todos os endpoints ← ESTE É O QUE FAZ APARECER O 🔒
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = string.Empty;
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SecureSales API v1");
});

app.UseAuthentication(); // ← antes do Authorization
app.UseAuthorization();
app.MapControllers();
app.Run();