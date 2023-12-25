using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Planning.Domain.Interfaces;
using Shopfloor.Planning.Infrastructure.Contexts;
using Shopfloor.Planning.Infrastructure.Repositories;

namespace Shopfloor.Planning.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                services.AddDbContext<PlanningContext>(options => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(PlanningContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                          .EnableSensitiveDataLogging());
            }
            else
            {
                services.AddDbContext<PlanningContext>(options => options.UseSqlServer(
                    Environment.GetEnvironmentVariable("ConnectionString"),
                    b => b.MigrationsAssembly(typeof(PlanningContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
            }

            services.AddTransient<ITestEntityRepository, TestEntityRepository>();
        }
    }
}
