using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Material.Domain.Interfaces;
using Shopfloor.Material.Infrastructure.Contexts;
using Shopfloor.Material.Infrastructure.Repositories;

namespace Shopfloor.Material.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                services.AddDbContext<MaterialContext>(options => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(MaterialContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                          .EnableSensitiveDataLogging());
            }
            else
            {
                services.AddDbContext<MaterialContext>(options => options.UseSqlServer(
                    Environment.GetEnvironmentVariable("ConnectionString"),
                    b => b.MigrationsAssembly(typeof(MaterialContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
            }

            services.AddTransient<IAutoIncrementRepository, AutoIncrementRepository>();
            services.AddTransient<IMaterialRequestRepository, MaterialRequestRepository>();
            services.AddTransient<IFabricCompositionRepository, FabricCompositionRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<ISupplierWisePurchaseOptionRepository, SupplierWisePurchaseOptionRepository>();
            services.AddTransient<IMOQMSQRoudingOptionItemRepository, MOQMSQRoudingOptionItemRepository>();
            services.AddTransient<IBuyerRepository, BuyerRepository>();
            services.AddTransient<IBuyerProductCategoryRepository, BuyerProductCategoryRepository>();
            services.AddTransient<IPriceListDetailSizeRepository, PriceListDetailSizeRepository>();
            services.AddTransient<IPriceListDetailRepository, PriceListDetailRepository>();
            services.AddTransient<IPriceListDetailColorRepository, PriceListDetailColorRepository>();
            services.AddTransient<IPriceListRepository, PriceListRepository>();
            services.AddTransient<ISupplierProductCategoryRepository, SupplierProductCategoryRepository>();
            services.AddTransient<IDynamicColumnRepository, DynamicColumnRepository>();
            services.AddTransient<IDynamicColumnContentRepository, DynamicColumnContentRepository>();
            services.AddTransient<IMaterialRequestDynamicColumnRepository, MaterialRequestDynamicColumnRepository>();
        }
    }
}