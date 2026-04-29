using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SecureSales.Application.Interfaces;
using SecureSales.Application.Services;
using SecureSales.Domain.Interfaces.Repositories;
using SecureSales.Infrastructure.Data;
using SecureSales.Infrastructure.Repositories;
using SecureSales.Infrastructure.Security;

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
builder.Services.AddSingleton<ISecretProvider, KeyVaultSecretProvider>();
builder.Services.AddScoped<IConnectionStringFactory, ConnectionStringFactory>();

builder.Services.AddDbContext<AppDbContext>((serviceProvider, options) =>
{
    var factory = serviceProvider.GetRequiredService<IConnectionStringFactory>();
    var connectionString = factory.GetConnectionStringAsync().GetAwaiter().GetResult();

    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = string.Empty;
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SecureSales API v1");
});

app.Run();