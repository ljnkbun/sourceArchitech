using Microsoft.EntityFrameworkCore;
using Serilog;
using Shopfloor.Cache.Extensions;
using Shopfloor.Core.Extensions.Services;
using Shopfloor.Core.Services;
using Shopfloor.Core.Settings;
using Shopfloor.Master.Api.Extensions;
using Shopfloor.Master.Api.Services;
using Shopfloor.Master.Application.Extensions;
using Shopfloor.Master.Application.Settings;
using Shopfloor.Master.Infrastructure.Contexts;
using Shopfloor.Master.Infrastructure.Extensions;
using Shopfloor.Master.Infrastructure.SeedDatas;
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
builder.Services.Configure<WfxApiSettings>(configuration.GetSection("WfxApiSettings"));
builder.Services.Configure<WfxBuyerApiSettings>(configuration.GetSection("WfxApiBuyerSettings"));
builder.Services.Configure<WfxSupplierApiSettings>(configuration.GetSection("WfxApiSupplierSettings"));
builder.Services.Configure<WfxArticleApiSettings>(configuration.GetSection("WfxApiArticleSettings"));
builder.Services.Configure<CalculateFactoryCapacityApiSettings>(configuration.GetSection("CalculateFactoryCapacityApiSettings"));
builder.Services.AddSharedInfrastructure();
builder.Services.AddApiVersioningExtension();

builder.Services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();
builder.Services.AddInfrastructure(configuration);
builder.Services.AddApplication();
builder.Services.AddJob();
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
    var db = scope.ServiceProvider.GetRequiredService<MasterContext>();
    db.Database.Migrate();
    if (configuration["IsSeedData"] == "True")
    {
        await SeedCategory.SeedAsync(db);
        await SeedDivision.SeedAsync(db);
        Log.Information("Finished Seeding Default Data");
    }
    Log.Information("Application Starting");
}

app.Run();
