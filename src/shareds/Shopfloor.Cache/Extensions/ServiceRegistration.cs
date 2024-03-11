using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Cache.Services;
using StackExchange.Redis;

namespace Shopfloor.Cache.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddDistributedCache(this IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                _ = bool.TryParse(configuration["CacheSettings:IsMemory"], out bool isMemory);

                if (isMemory)
                {
                    services.AddDistributedMemoryCache();
                }
                else
                {
                    _ = bool.TryParse(configuration["RedisSettings:SSL"], out bool ssl);
                    var configurationOptions = new ConfigurationOptions
                    {
                        EndPoints = { configuration["RedisSettings:Uri"] },
                        Ssl = ssl,
                    };
                    services.AddStackExchangeRedisCache(options => options.ConfigurationOptions = configurationOptions);
                }
            }
            else
            {
                _ = bool.TryParse(Environment.GetEnvironmentVariable("RedisSettings_SSL"), out bool ssl);
                var configurationOptions = new ConfigurationOptions
                {
                    EndPoints = { Environment.GetEnvironmentVariable("RedisSettings_Uri") },
                    Ssl = ssl,
                };
                services.AddStackExchangeRedisCache(options => options.ConfigurationOptions = configurationOptions);
            }

            services.AddTransient<ICachingService, CachingService>();
        }
    }
}
