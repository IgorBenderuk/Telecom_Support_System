using Scalar.AspNetCore;
using TelecomSupportSystem.API.Middleware;
using TelecomSupportSystem.Application;
using TelecomSupportSystem.Infrastructure;
using TelecomSupportSystem.Infrastructure.Persistence.Seeders;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddInfrastructure(config);
builder.Services.AddApplication();


builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddHostedService<DatabaseInitializer>();

builder.Services.AddOpenApi();

var app = builder.Build();


if ( app.Environment.IsDevelopment() )
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
