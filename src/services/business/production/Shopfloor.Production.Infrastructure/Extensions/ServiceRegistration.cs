using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Production.Domain.Interfaces;
using Shopfloor.Production.Infrastructure.Contexts;
using Shopfloor.Production.Infrastructure.Repositories;

namespace Shopfloor.Production.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                services.AddDbContext<ProductionContext>(options => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ProductionContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                          .EnableSensitiveDataLogging());
            }
            else
            {
                services.AddDbContext<ProductionContext>(options => options.UseSqlServer(
                    Environment.GetEnvironmentVariable("ConnectionString"),
                    b => b.MigrationsAssembly(typeof(ProductionContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
            }

            services.AddTransient<IInspectionBySizeRepository, InspectionBySizeRepository>();
            services.AddTransient<IProductionOutputRepository, ProductionOutputRepository>();
            services.AddTransient<IDefectCapturingRepository, DefectCapturingRepository>();
            services.AddTransient<IDefectCapturingStandardRepository, DefectCapturingStandardRepository>();
            services.AddTransient<IDefectCapturing4PointsRepository, DefectCapturing4PointsRepository>();
            services.AddTransient<IDefectCapturing100PointsRepository, DefectCapturing100PointsRepository>();
            services.AddTransient<IMeasurementRepository, MeasurementRepository>();
            services.AddTransient<IFPPOOutputRepository, FPPOOutputRepository>();
            services.AddTransient<IFPPOOutputDetailRepository, FPPOOutputDetailRepository>();
            services.AddTransient<IAttachmentRepository, AttachmentRepository>();
        }
    }
}
