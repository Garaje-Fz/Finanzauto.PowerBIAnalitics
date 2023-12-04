using Finanzauto.PowerBI.API.Configuration;
using Finanzauto.PowerBI.Application;
using Finanzauto.PowerBI.Auth;
using Finanzauto.PowerBI.Infraestructure;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();
builder.Services.AddEndpointsApiExplorer();// Service to ignore circular references
builder.Services.ConfigureSwagger();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddAuthServices(builder.Configuration);

var app = builder.Build();
app.UseCors("PolicyCors");
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("./v1/swagger.json", "PowerBI V1");
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;

app.MapControllers();
app.Run();
