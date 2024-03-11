using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Inspection.Domain.Interfaces;
using Shopfloor.Inspection.Infrastructure.Contexts;
using Shopfloor.Inspection.Infrastructure.Repositories;

namespace Shopfloor.Inspection.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                services.AddDbContext<InspectionContext>(options => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(InspectionContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                          .EnableSensitiveDataLogging());
            }
            else
            {
                services.AddDbContext<InspectionContext>(options => options.UseSqlServer(
                    Environment.GetEnvironmentVariable("ConnectionString"),
                    b => b.MigrationsAssembly(typeof(InspectionContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
            }

            services.AddTransient<IInspectionRepository, InspectionRepository>();
            services.AddTransient<IInspectionBySizeRepository, InspectionBySizeRepository>();
            services.AddTransient<IInspectionMesurementRepository, InspectionMesurementRepository>();
            services.AddTransient<IInspectionDefectCapturingRepository, InspectionDefectCapturingRepository>();
            services.AddTransient<IAttachmentRepository, AttachmentRepository>();
            services.AddTransient<IAQLVersionRepository, AQLVersionRepository>();
            services.AddTransient<IAQLRepository, AQLRepository>();
            services.AddTransient<IFabricWeightRepository, FabricWeightRepository>();
            services.AddTransient<IOneHundredPointSystemRepository, OneHundredPointSystemRepository>();
            services.AddTransient<ITestRepository, TestRepository>();
            services.AddTransient<ITestGroupRepository, TestGroupRepository>();
            services.AddTransient<IConversionRepository, ConversionRepository>();

            services.AddTransient<IQCRequestRepository, QCRequestRepository>();
            services.AddTransient<IQCRequestArticleRepository, QCRequestArticleRepository>();
            services.AddTransient<IQCDefinitionDefectRepository, QCDefinitionDefectRepository>();
            services.AddTransient<IQCDefinitionRepository, QCDefinitionRepository>();
            services.AddTransient<IQCDefectRepository, QCDefectRepository>();
            services.AddTransient<IQCDefectTypeRepository, QCDefectTypeRepository>();
            services.AddTransient<IProblemTimelineRepository, ProblemTimelineRepository>();
            services.AddTransient<IProblemCorrectiveActionRepository, ProblemCorrectiveActionRepository>();
            services.AddTransient<IProblemRootCauseRepository, ProblemRootCauseRepository>();
            services.AddTransient<IZoneTypeRepository, ZoneTypeRepository>();
            services.AddTransient<IInpection4PointSysRepository, Inpection4PointSysRepository>();
            services.AddTransient<IInspectionDefectCapturing4PointSysRepository, InspectionDefectCapturing4PointSysRepository>();
            services.AddTransient<IInspectionDefectError4PointSysRepository, InspectionDefectError4PointSysRepository>();
            services.AddTransient<IInpection100PointSysRepository, Inpection100PointSysRepository>();
            services.AddTransient<IInspectionDefectCapturing100PointSysRepository, InspectionDefectCapturing100PointSysRepository>();
            services.AddTransient<IInspectionDefectError100PointSysRepository, InspectionDefectError100PointSysRepository>();
            services.AddTransient<IInpectionTCStandardRepository, InpectionTCStandardRepository>();
            services.AddTransient<IInspectionDefectCapturingTCStandardRepository, InspectionDefectCapturingTCStandardRepository>();
            services.AddTransient<IQCTypeRepository, QCTypeRepository>();
            services.AddTransient<IFourPointsSystemRepository, FourPointsSystemRepository>();
            services.AddTransient<IFourPointsSystemDetailRepository, FourPointsSystemDetailRepository>();
            services.AddTransient<IOneHundredPointSystemRepository, OneHundredPointSystemRepository>();
            services.AddTransient<IOneHundredPointSystemDetailRepository, OneHundredPointSystemDetailRepository>();
        }
    }
}
