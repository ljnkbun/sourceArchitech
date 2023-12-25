using Microsoft.AspNetCore.ResponseCompression;
using Serilog;
using Shopfloor.Notification.Extensions;

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
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
          new[] { "application/octet-stream" });
});
builder.Services.AddEventBus(configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseResponseCompression();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapHub();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
