using Azure.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecureSales.Application.Interfaces;
using SecureSales.Application.Services;
using SecureSales.Domain.Interfaces.Repositories;
using SecureSales.Infrastructure.Data;
using SecureSales.Infrastructure.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// DB Context
//builder.Services.AddDbContext<AppDbContext>(options =>
//  options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
//    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))));

//var connectionString = builder.Configuration["ConnectionStrings:Default"];
// Nome do Key Vault
var keyVaultName = builder.Configuration["KeyVaultName"];

if (!string.IsNullOrEmpty(keyVaultName))
{
    var kvUri = new Uri($"https://{keyVaultName}.vault.azure.net/");

    builder.Configuration.AddAzureKeyVault(
        kvUri,
        new DefaultAzureCredential()
    );
}


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        keyVaultName,
        ServerVersion.AutoDetect(keyVaultName)
    ));


// DI
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

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