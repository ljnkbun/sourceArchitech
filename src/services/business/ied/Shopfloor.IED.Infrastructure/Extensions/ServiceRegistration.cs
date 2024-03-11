using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.IED.Domain.Interfaces;
using Shopfloor.IED.Infrastructure.Contexts;
using Shopfloor.IED.Infrastructure.Repositories;

namespace Shopfloor.IED.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                services.AddDbContext<IEDContext>(options => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(IEDContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                          .EnableSensitiveDataLogging());
            }
            else
            {
                services.AddDbContext<IEDContext>(options => options.UseSqlServer(
                    Environment.GetEnvironmentVariable("ConnectionString"),
                    b => b.MigrationsAssembly(typeof(IEDContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
            }

            services.AddTransient<IProcessTaskRepository, ProcessTaskRepository>();
            services.AddTransient<ILabourSkillRepository, LabourSkillRepository>();
            services.AddTransient<IRecipeUnitRepository, RecipeUnitRepository>();
            services.AddTransient<IConcentrateRepository, ConcentrateRepository>();
            services.AddTransient<IShadeRepository, ShadeRepository>();
            services.AddTransient<IZoneRepository, ZoneRepository>();
            services.AddTransient<IFormulaRepository, FormulaRepository>();
            services.AddTransient<IFormulaFieldRepository, FormulaFieldRepository>();
            services.AddTransient<ISewingTaskLibRepository, SewingTaskLibRepository>();
            services.AddTransient<ISewingMacroLibRepository, SewingMacroLibRepository>();
            services.AddTransient<ISewingOperationLibRepository, SewingOperationLibRepository>();
            services.AddTransient<ISewingFeatureLibRepository, SewingFeatureLibRepository>();
            services.AddTransient<IRequestRepository, RequestRepository>();
            services.AddTransient<IRequestDivisionRepository, RequestDivisionRepository>();
            services.AddTransient<IProcessTemplateRepository, ProcessTemplateRepository>();
            services.AddTransient<IProcessTemplateItemRepository, ProcessTemplateItemRepository>();
            services.AddTransient<IDyeingTBRequestRepository, DyeingTBRequestRepository>();
            services.AddTransient<IDyeingTBMaterialRepository, DyeingTBMaterialRepository>();
            services.AddTransient<IDyeingTBRequestFileRepository, DyeingTBRequestFileRepository>();
            services.AddTransient<IDyeingTBMaterialColorRepository, DyeingTBMaterialColorRepository>();
            services.AddTransient<IRequestDivisionFileRepository, RequestDivisionFileRepository>();
            services.AddTransient<IFolderTreeRepository, FolderTreeRepository>();
            services.AddTransient<IRequestDivisionProcessRepository, RequestDivisionProcessRepository>();
            services.AddTransient<IRequestTypeRepository, RequestTypeRepository>();
            services.AddTransient<ISewingRoutingRepository, SewingRoutingRepository>();
            services.AddTransient<ISewingRoutingBOLRepository, SewingRoutingBOLRepository>();
            services.AddTransient<ISewingMacroLibBOLRepository, SewingMacroLibBOLRepository>();
            services.AddTransient<ISewingOperationLibBOLRepository, SewingOperationLibBOLRepository>();
            services.AddTransient<ISewingFeatureLibBOLRepository, SewingFeatureLibBOLRepository>();
            services.AddTransient<ISewingOperationLibResultRepository, SewingOperationLibResultRepository>();
            services.AddTransient<ILightRepository, LightRepository>();
            services.AddTransient<IWeavingBackgroundStyleRepository, WeavingBackgroundStyleRepository>();
            services.AddTransient<IWeavingBorderStyleRepository, WeavingBorderStyleRepository>();
            services.AddTransient<IDyeingTBRecipeRepository, DyeingTBRecipeRepository>();
            services.AddTransient<IDyeingTBRChemicalValueRepository, DyeingTBRChemicalValueRepository>();
            services.AddTransient<IDyeingTBRTaskRepository, DyeingTBRTaskRepository>();
            services.AddTransient<IDyeingTBRChemicalRepository, DyeingTBRChemicalRepository>();
            services.AddTransient<IDCTemplateRepository, DCTemplateRepository>();
            services.AddTransient<IDCTemplateTaskRepository, DCTemplateTaskRepository>();
            services.AddTransient<IDCTemplateDetailRepository, DCTemplateDetailRepository>();
            services.AddTransient<IRecipeRepository, RecipeRepository>();
            services.AddTransient<IRecipeTaskRepository, RecipeTaskRepository>();
            services.AddTransient<IRecipeChemicalRepository, RecipeChemicalRepository>();
            services.AddTransient<IRequestArticleOutputRepository, RequestArticleOutputRepository>();
            services.AddTransient<IRequestArticleInputRepository, RequestArticleInputRepository>();
            services.AddTransient<IWeavingIEDRepository, WeavingIEDRepository>();
            services.AddTransient<IWeavingRoutingRepository, WeavingRoutingRepository>();
            services.AddTransient<IWeavingRusticFabricSpecRepository, WeavingRusticFabricSpecRepository>();
            services.AddTransient<IWeavingDetailStructureRepository, WeavingDetailStructureRepository>();
            services.AddTransient<IWeavingYarnRepository, WeavingYarnRepository>();
            services.AddTransient<IWeavingRappoRepository, WeavingRappoRepository>();
            services.AddTransient<IWeavingRappoMarkRepository, WeavingRappoMarkRepository>();
            services.AddTransient<IWeavingRappoMatricRepository, WeavingRappoMatricRepository>();
            services.AddTransient<IWeavingSpecificationRepository, WeavingSpecificationRepository>();
            services.AddTransient<IDyeingIEDRepository, DyeingIEDRepository>();
            services.AddTransient<IDyeingProcessChemicalRepository, DyeingProcessChemicalRepository>();
            services.AddTransient<IDyeingRoutingRepository, DyeingRoutingRepository>();
            services.AddTransient<IKnittingTypeRepository, KnittingTypeRepository>();
            services.AddTransient<IKnittingBodyTypeRepository, KnittingBodyTypeRepository>();
            services.AddTransient<IKnittingTypeRepository, KnittingTypeRepository>();
            services.AddTransient<IKnittingShrinkageRepository, KnittingShrinkageRepository>();
            services.AddTransient<IKnittingFeederRepository, KnittingFeederRepository>();
            services.AddTransient<IKnittingMachineDiameterRepository, KnittingMachineDiameterRepository>();
            services.AddTransient<IKnittingIEDRepository, KnittingIEDRepository>();
            services.AddTransient<IKnittingYarnRepository, KnittingYarnRepository>();
            services.AddTransient<IKnittingRoutingRepository, KnittingRoutingRepository>();
            services.AddTransient<IKnittingGreigeRepository, KnittingGreigeRepository>();
            services.AddTransient<ISewingIEDRepository, SewingIEDRepository>();
            services.AddTransient<ISewingEfficiencyProfileRepository, SewingEfficiencyProfileRepository>();
            services.AddTransient<ISewingBundleRepository, SewingBundleRepository>();
            services.AddTransient<ISewingMachineEfficiencyProfileRepository, SewingMachineEfficiencyProfileRepository>();
            services.AddTransient<ISewingComponentRepository, SewingComponentRepository>();
            services.AddTransient<ISewingComponentGroupRepository, SewingComponentGroupRepository>();
            services.AddTransient<ISewingSubcategoryEfficiencyRepository, SewingSubcategoryEfficiencyRepository>();
            services.AddTransient<ISewingFileRepository, SewingFileRepository>();
            services.AddTransient<IDyeingFileRepository, DyeingFileRepository>();
            services.AddTransient<IKnittingFileRepository, KnittingFileRepository>();
            services.AddTransient<IWeavingFileRepository, WeavingFileRepository>();
            services.AddTransient<IWeavingReportSettingRepository, WeavingReportSettingRepository>();
            services.AddTransient<IWeavingReportSettingDetailRepository, WeavingReportSettingDetailRepository>();
            services.AddTransient<IWeavingOperationRepository, WeavingOperationRepository>();
            services.AddTransient<IWeavingOperationInputArticleRepository, WeavingOperationInputArticleRepository>();
            services.AddTransient<ISewingRateRepository, SewingRateRepository>();
            services.AddTransient<IRecipeCategoryRepository, RecipeCategoryRepository>();
            services.AddTransient<ILiquorRatioRepository, LiquorRatioRepository>();
        }
    }
}