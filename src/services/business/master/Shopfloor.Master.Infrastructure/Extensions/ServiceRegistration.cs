using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shopfloor.Core.Helpers;
using Shopfloor.Master.Application.Services.Wfxs;
using Shopfloor.Master.Domain.Interfaces;
using Shopfloor.Master.Infrastructure.Contexts;
using Shopfloor.Master.Infrastructure.Repositories;
using Shopfloor.Master.Infrastructure.Services.Wfxs;

namespace Shopfloor.Master.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                services.AddDbContext<MasterContext>(options => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(MasterContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
                          .EnableSensitiveDataLogging());
            }
            else
            {
                services.AddDbContext<MasterContext>(options => options.UseSqlServer(
                    Environment.GetEnvironmentVariable("ConnectionString"),
                    b => b.MigrationsAssembly(typeof(MasterContext).Assembly.FullName)
                          .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));
            }

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IProductGroupRepository, ProductGroupRepository>();
            services.AddTransient<IMaterialTypeRepository, MaterialTypeRepository>();
            services.AddTransient<ISubCategoryRepository, SubCategoryRepository>();
            services.AddTransient<IColorCardRepository, ColorCardRepository>();
            services.AddTransient<ISizeOrWidthRangeRepository, SizeOrWidthRangeRepository>();
            services.AddTransient<IPricePerRepository, PricePerRepository>();
            services.AddTransient<IColorDefinitionRepository, ColorDefinitionRepository>();
            services.AddTransient<IThemeRepository, ThemeRepository>();
            services.AddTransient<ICompanyCurrencyRepository, CompanyCurrencyRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<IFabricContentRepository, FabricContentRepository>();
            services.AddTransient<IStructureRepository, StructureRepository>();
            services.AddTransient<ISpinningMethodRepository, SpinningMethodRepository>();
            services.AddTransient<ICertificateRepository, CertificateRepository>();
            services.AddTransient<IPatternRepository, PatternRepository>();
            services.AddTransient<IConstructionRepository, ConstructionRepository>();
            services.AddTransient<IOriginRepository, OriginRepository>();
            services.AddTransient<ICropSeasonRepository, CropSeasonRepository>();
            services.AddTransient<IStapleRepository, StapleRepository>();
            services.AddTransient<IStrengthRepository, StrengthRepository>();
            services.AddTransient<IMicronaireRepository, MicronaireRepository>();
            services.AddTransient<IUOMConversionRepository, UOMConversionRepository>();
            services.AddTransient<IUOMRepository, UOMRepository>();
            services.AddTransient<ISpinningProcessRepository, SpinningProcessRepository>();

            services.AddTransient<ICountRepository, CountRepository>();
            services.AddTransient<IGradeRepository, GradeRepository>();
            services.AddTransient<ITwistRepository, TwistRepository>();
            services.AddTransient<IDivisionRepository, DivisionRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IFiberTypeRepository, FiberTypeRepository>();
            services.AddTransient<IFabricWidthRepository, FabricWidthRepository>();
            services.AddTransient<ICountTypeRepository, CountTypeRepository>();
            services.AddTransient<IYarnCompositionRepository, YarnCompositionRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IBuyerTypeRepository, BuyerTypeRepository>();
            services.AddTransient<ISupplierTypeRepository, SupplierTypeRepository>();
            services.AddTransient<IPaymentTermRepository, PaymentTermRepository>();
            services.AddTransient<IDeliveryTermRepository, DeliveryTermRepository>();
            services.AddTransient<IPortRepository, PortRepository>();
            services.AddTransient<IShipmentTermRepository, ShipmentTermRepository>();
            services.AddTransient<ISubCategoryGroupRepository, SubCategoryGroupRepository>();
            services.AddTransient<IAccountGroupRepository, AccountGroupRepository>();
            services.AddTransient<IGroupNameRepository, GroupNameRepository>();
            services.AddTransient<IProcessRepository, ProcessRepository>();
            services.AddTransient<IGaugeRepository, GaugeRepository>();
            services.AddTransient<IMachineTypeRepository, MachineTypeRepository>();
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<IArticleBaseColorRepository, ArticleBaseColorRepository>();
            services.AddTransient<IArticleBaseSizeRepository, ArticleBaseSizeRepository>();
            services.AddTransient<IArticleFlexFieldRepository, ArticleFlexFieldRepository>();
            services.AddTransient<IProcessLibraryRepository, ProcessLibraryRepository>();
            services.AddTransient<IOperationLibraryRepository, OperationLibraryRepository>();
            services.AddTransient<ISubOperationLibraryRepository, SubOperationLibraryRepository>();
            services.AddTransient<IFactoryRepository, FactoryRepository>();
            services.AddTransient<ICategoryMapMaterialTypeRepository, CategoryMapMaterialTypeRepository>();
            services.AddTransient<IMaterialTypeMapProductGroupRepository, MaterialTypeMapProductGroupRepository>();

            services.AddTransient<IRestClientHelper, RestClientHelper>();
            services.AddTransient<IWfxMasterDataService, WfxMasterDataService>();
            services.AddHttpClient<IWfxMasterDataService, WfxMasterDataService>((x) =>
            {
                string apiUrl = configuration["WfxApiSettings:Uri"];
                x.BaseAddress = new Uri(apiUrl);
            });

            services.AddTransient<IWfxArticleRequestService, WfxArticleRequestService>();
        }
    }
}
