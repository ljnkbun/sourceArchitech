using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Ambassador.Api.Extensions;
using Shopfloor.Ambassador.Api.Services;
using Shopfloor.Ambassador.Application.Extensions;
using Shopfloor.Ambassador.Infrastructure.Contexts;
using Shopfloor.Ambassador.Infrastructure.Extensions;
using Shopfloor.Ambassador.Infrastructure.SeedDatas;
using Shopfloor.Cache.Extensions;
using Shopfloor.Core.Extensions.Services;
using Shopfloor.Core.Services;
using Shopfloor.Core.Settings;
using System.Text.Json.Serialization;

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
builder.Services.AddSharedInfrastructure();
builder.Services.AddApiVersioningExtension();

builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
builder.Services.AddInfrastructure(configuration);
builder.Services.AddApplication();
builder.Services.AddHealthChecks();

builder.Services.AddControllers()
    .AddJsonOptions(opts => opts.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEventBus(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSharedMiddleware();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AmbassadorContext>();
    db.Database.Migrate();
    if (configuration["IsSeedData"] == "True")
    {
        await SeedTestEntity.SeedTestEntityAsync(db);
        Log.Information("Finished Seeding Default Data");
    }
    Log.Information("Application Starting");
}

app.Run();