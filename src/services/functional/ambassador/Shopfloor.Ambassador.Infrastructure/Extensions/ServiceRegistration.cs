using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Ambassador.Application.Interfaces;
using Shopfloor.Ambassador.Domain.Interfaces;
using Shopfloor.Ambassador.Infrastructure.Contexts;
using Shopfloor.Ambassador.Infrastructure.Repositories;
using Shopfloor.Ambassador.Infrastructure.Services;
using Shopfloor.Core.Helpers;

namespace Shopfloor.Ambassador.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                services.AddDbContext<AmbassadorContext>(options => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AmbassadorContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                          .EnableSensitiveDataLogging());
            }
            else
            {
                services.AddDbContext<AmbassadorContext>(options => options.UseSqlServer(
                    Environment.GetEnvironmentVariable("ConnectionString"),
                    b => b.MigrationsAssembly(typeof(AmbassadorContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
            }

            services.AddTransient<ITestEntityRepository, TestEntityRepository>();

            services.AddTransient<IRestClientHelper, RestClientHelper>();
            services.AddTransient<IWfxMasterDataService, WfxMasterDataService>();
            services.AddHttpClient<IWfxMasterDataService, WfxMasterDataService>((x) =>
            {
                string apiUrl = configuration["WfxApiSettings:Uri"];
                x.BaseAddress = new Uri(apiUrl);
            });

            services.AddTransient<IWfxArticleService, WfxArticleService>();
            services.AddHttpClient<IWfxArticleService, WfxArticleService>((x) =>
            {
                string apiUrl = configuration["WfxApiArticleSettings:Uri"];
                x.BaseAddress = new Uri(apiUrl);
            });

            services.AddTransient<IWfxPOArticleDataService, WfxPOArticleDataService>();
            services.AddHttpClient<IWfxPOArticleDataService, WfxPOArticleDataService>((x) =>
            {
                string apiUrl = configuration["WfxApiPOArticleSettings:Uri"];
                x.BaseAddress = new Uri(apiUrl);
            });
        }
    }
}
