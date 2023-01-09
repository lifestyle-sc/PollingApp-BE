using Contracts;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using PollingApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

// Add services to the container.

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers()
    .AddApplicationPart(typeof(PollingApp.Presentation.AssemblyReference).Assembly);
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();

// Configure the HTTP request pipeline.

app.ConfigureExceptionHandler(logger);

if (app.Environment.IsProduction())
    app.UseHsts();

app.UseHttpsRedirection();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
