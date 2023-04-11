using Finanzauto.PowerBI.API.Configuration;
using Finanzauto.PowerBI.Application;
using Finanzauto.PowerBI.Auth;
using Finanzauto.PowerBI.Infraestructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();// Service to ignore circular references

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwagger();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddAuthServices(builder.Configuration);

var app = builder.Build();

//app.UseCors("PolicyCors");
app.UseCors("PolicyCors");
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("./v1/swagger.json", "PowerBI V1");
});

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();
IConfiguration configuration = app.Configuration;
IWebHostEnvironment environment = app.Environment;

app.MapControllers();

app.Run();
