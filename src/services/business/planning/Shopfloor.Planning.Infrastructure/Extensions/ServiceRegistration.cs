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

            services.AddTransient<IOrderEfficiencyRepository, OrderEfficiencyRepository>();
            services.AddTransient<ILearningCurveEfficiencyRepository, LearningCurveEfficiencyRepository>();
            services.AddTransient<ILearningCurveDetailEfficiencyRepository, LearningCurveDetailEfficiencyRepository>();
            services.AddTransient<IProfileEfficiencyRepository, ProfileEfficiencyRepository>();
            services.AddTransient<IProfileEfficiencyDetailRepository, ProfileEfficiencyDetailRepository>();
            services.AddTransient<IPORRepository, PORRepository>();
            services.AddTransient<IPORDetailRepository, PORDetailRepository>();
            services.AddTransient<IMergeSplitPORRepository, MergeSplitPORRepository>();
            services.AddTransient<ICapacityColorRepository, CapacityColorRepository>();
            services.AddTransient<IFactoryCapacityRepository, FactoryCapacityRepository>();
            services.AddTransient<IStripFactoryRepository, StripFactoryRepository>();
            services.AddTransient<IStripScheduleRepository, StripScheduleRepository>();
            services.AddTransient<IStripScheduleDetailRepository, StripScheduleDetailRepository>();
            services.AddTransient<IStripSchedulePlanningDetailRepository, StripSchedulePlanningDetailRepository>();
            services.AddTransient<IStripFactoryScheduleRepository, StripFactoryScheduleRepository>();
            services.AddTransient<IMergeSplitPorDetailRepostiry, MergeSplitPorDetailRepostiry>();
            services.AddTransient<IStripFactoryDetailRepository, StripFactoryDetailRepository>();
            services.AddTransient<IStripFactoryScheduleDetailRepository, StripFactoryScheduleDetailRepository>();
            services.AddTransient<ILineMachineCapacityRepository, LineMachineCapacityRepository>();
            services.AddTransient<IFPPORepository, FPPORepository>();
            services.AddTransient<IFPPODetailRepository, FPPODetailRepository>();
			services.AddTransient<ICriticalPartRepository, CriticalPartRepository>();
            services.AddTransient<IStripScheduleCaptureRepository, StripScheduleCaptureRepository>();
            services.AddTransient<IStripScheduleDetailCaptureRepository, StripScheduleDetailCaptureRepository>();
            services.AddTransient<IStripSchedulePlanningDetailCaptureRepository, StripSchedulePlanningDetailCaptureRepository>();
            services.AddTransient<IAutoIncrementRepository, AutoIncrementRepository>();
        }
    }
}
