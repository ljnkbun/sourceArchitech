using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.FileStorage.Services;

namespace Shopfloor.FileStorage.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddFileStorageService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IFileStorageService, FileStorageService>();
            services.AddHttpClient<IFileStorageService, FileStorageService>((x) =>
            {
                string uri = configuration["NextCloudSettings:Uri"];
                string user = configuration["NextCloudSettings:UserName"];
                string password = configuration["NextCloudSettings:Password"];
                x.BaseAddress = new Uri(uri);
            });
        }
    }
}
