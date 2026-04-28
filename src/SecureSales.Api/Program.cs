using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SecureSales.Application.Interfaces;
using SecureSales.Application.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// DI
builder.Services.AddScoped<IClienteService, ClienteService>();

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