using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.FileStorage.Application.Interfaces;
using Shopfloor.FileStorage.Domain.Interfaces;
using Shopfloor.FileStorage.Infrastructure.Contexts;
using Shopfloor.FileStorage.Infrastructure.Repositories;
using Shopfloor.FileStorage.Infrastructure.Services;
using System.Net;
using WebDAVClient;

namespace Shopfloor.FileStorage.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                services.AddDbContext<FileStorageContext>(options => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(FileStorageContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                          .EnableSensitiveDataLogging());

                services.AddTransient<IClient>(serviceProvider =>
                {
                    var networkCredential = new NetworkCredential
                    {
                        UserName = configuration["NextCloudSettings:UserName"],
                        Password = configuration["NextCloudSettings:Password"]
                    };
                    return new Client(networkCredential)
                    {
                        Server = configuration["NextCloudSettings:Server"],
                        BasePath = configuration["NextCloudSettings:BasePath"]
                    };
                });
            }
            else
            {
                services.AddDbContext<FileStorageContext>(options => options.UseSqlServer(
                    Environment.GetEnvironmentVariable("ConnectionString"),
                    b => b.MigrationsAssembly(typeof(FileStorageContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

                services.AddTransient<IClient>(serviceProvider =>
                {
                    var networkCredential = new NetworkCredential
                    {
                        UserName = Environment.GetEnvironmentVariable("NextCloudSettings_UserName"),
                        Password = Environment.GetEnvironmentVariable("NextCloudSettings_Password")
                    };
                    return new Client(networkCredential)
                    {
                        Server = Environment.GetEnvironmentVariable("NextCloudSettings_Server"),
                        BasePath = Environment.GetEnvironmentVariable("NextCloudSettings_BasePath")
                    };
                });
            }

            services.AddTransient<IFileRepository, FileRepository>();
            services.AddTransient<INextCloudService, NextCloudService>();
        }
    }
}
