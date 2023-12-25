using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Barcode.Application.Services.Wfxs;
using Shopfloor.Barcode.Domain.Interfaces;
using Shopfloor.Barcode.Infrastructure.Contexts;
using Shopfloor.Barcode.Infrastructure.Repositories;
using Shopfloor.Barcode.Infrastructure.Services.Wfxs;

namespace Shopfloor.Barcode.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                services.AddDbContext<BarcodeContext>(options => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(BarcodeContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                          .EnableSensitiveDataLogging());
            }
            else
            {
                services.AddDbContext<BarcodeContext>(options => options.UseSqlServer(
                    Environment.GetEnvironmentVariable("ConnectionString"),
                    b => b.MigrationsAssembly(typeof(BarcodeContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
            }

            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IArticleBarcodeRepository, ArticleBarcodeRepository>();
            services.AddTransient<IArticleBarcodeHistoryRepository, ArticleBarcodeHistoryRepository>();
            services.AddTransient<IBarcodeLocationRepository, BarcodeLocationRepository>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IImportTransferToSiteSyncRepository, ImportTransferToSiteSyncRepository>();
            services.AddTransient<IImportRepository, ImportRepository>();
            services.AddTransient<IImportArticleRepository, ImportArticleRepository>();
            services.AddTransient<IImportDetailRepository, ImportDetailRepository>();

            services.AddTransient<IExportRepository, ExportRepository>();
            services.AddTransient<IExportArticleRepository, ExportArticleRepository>();
            services.AddTransient<IExportDetailRepository, ExportDetailRepository>();
            services.AddTransient<IWfxPOArticleRepository, WfxPOArticleRepository>();

            services.AddTransient<IWfxPOArticleServices, WfxPOArticleServices>();
            //services.AddHttpClient<IWfxPOArticleServices, WfxPOArticleServices>((x) =>
            //{
            //    string apiUrl = configuration["WfxApiPOArticleSettings:Uri"];
            //    x.BaseAddress = new Uri(apiUrl);
            //});

        }
    }
}
