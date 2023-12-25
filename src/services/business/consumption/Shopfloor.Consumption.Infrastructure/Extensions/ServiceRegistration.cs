using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Consumption.Domain.Interfaces;
using Shopfloor.Consumption.Infrastructure.Contexts;
using Shopfloor.Consumption.Infrastructure.Repositories;

namespace Shopfloor.Consumption.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                services.AddDbContext<ConsumptionContext>(options => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ConsumptionContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                          .EnableSensitiveDataLogging());
            }
            else
            {
                services.AddDbContext<ConsumptionContext>(options => options.UseSqlServer(
                    Environment.GetEnvironmentVariable("ConnectionString"),
                    b => b.MigrationsAssembly(typeof(ConsumptionContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
            }

            services.AddTransient<ITestEntityRepository, TestEntityRepository>();
        }
    }
}
