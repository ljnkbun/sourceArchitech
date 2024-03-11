using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Cache.Extensions;
using Shopfloor.Core.Extensions.Services;
using Shopfloor.Core.Services;
using Shopfloor.Core.Settings;
using Shopfloor.Planning.Api.Extensions;
using Shopfloor.Planning.Api.Services;
using Shopfloor.Planning.Application;
using Shopfloor.Planning.Application.Extensions;
using Shopfloor.Planning.Application.Settings;
using Shopfloor.Planning.Infrastructure.Contexts;
using Shopfloor.Planning.Infrastructure.Extensions;
using System.Text.Json.Serialization;
using Shopfloor.Planning.Infrastructure.SeedDatas;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Repositories;
using Shopfloor.Planning.Api.Jobs;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

//Read Configuration from appSettings
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.Development.json")
    .AddEnvironmentVariables()
    .Build();

//Initialize Logger
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

// Add services to the container.

builder.Services.AddDistributedCache(configuration);
builder.Services.Configure<CacheSettings>(configuration.GetSection("CacheSettings"));
builder.Services.Configure<JobPorSettings>(configuration.GetSection("JobPorSettings"));
builder.Services.Configure<JobSettings>(configuration.GetSection("JobSettings"));
builder.Services.Configure<QueueCapacitySettings>(configuration.GetSection("QueueCapacitySettings"));
builder.Services.AddSharedInfrastructure();
builder.Services.AddApiVersioningExtension();

builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
builder.Services.AddInfrastructure(configuration);
builder.Services.AddApplication();
builder.Services.AddHealthChecks();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(configurePolicy =>
    {
        configurePolicy.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(opts => opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEventBus(configuration);
builder.Services.AddJob();
builder.Services.AddSingleton<IBackgroundTaskQueue>(ctx =>
{
    var queueCapacity = ctx.GetRequiredService<IOptions<QueueCapacitySettings>>().Value.Capacity;
    return new BackgroundTaskQueue(queueCapacity);
});
builder.Services.AddHostedService<QueuedHostedService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.UseSharedMiddleware();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PlanningContext>();
    db.Database.Migrate();
    if (configuration["IsSeedData"] == "True")
    {
        await SeedAutoIncrement.SeedAsync(db);
    }
    Log.Information("Application Starting");
}

app.Run();
