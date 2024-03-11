using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Services;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Master.Infrastructure.TypeConfigurations;

namespace Shopfloor.Master.Infrastructure.Contexts
{
    public partial class MasterContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public MasterContext(DbContextOptions<MasterContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = _dateTime.Now;
                        entry.Entity.CreatedUserId = _authenticatedUser.UserId;

                        entry.Entity.ModifiedDate = _dateTime.Now;
                        entry.Entity.ModifiedUserId = _authenticatedUser.UserId;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = _dateTime.Now;
                        entry.Entity.ModifiedUserId = _authenticatedUser.UserId;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ProductGroupUOM> ProductGroupUOMs { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<MaterialType> MaterialTypes { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<ColorCard> ColorCards { get; set; }
        public virtual DbSet<SizeOrWidthRange> SizeOrWidthRanges { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<PricePer> PricePers { get; set; }
        public virtual DbSet<ColorDefinition> ColorDefinitions { get; set; }
        public virtual DbSet<CompanyCurrency> CompanyCurrencies { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<FabricContent> FabricContents { get; set; }
        public virtual DbSet<Structure> Structures { get; set; }
        public virtual DbSet<SpinningMethod> SpinningMethods { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Pattern> Patterns { get; set; }
        public virtual DbSet<Origin> Origins { get; set; }
        public virtual DbSet<CropSeason> CropSeasons { get; set; }
        public virtual DbSet<Staple> Staples { get; set; }
        public virtual DbSet<Strength> Strengths { get; set; }
        public virtual DbSet<Micronaire> Micronaires { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Twist> Twists { get; set; }
        public virtual DbSet<Construction> Constructions { get; set; }
        public virtual DbSet<UOMConversion> UOMConversions { get; set; }
        public virtual DbSet<UOM> UOMs { get; set; }
        public virtual DbSet<Count> Counts { get; set; }
        public virtual DbSet<FiberType> FiberTypes { get; set; }
        public virtual DbSet<FabricWidth> FabricWidths { get; set; }
        public virtual DbSet<SpinningProcess> SpinningProcesses { get; set; }
        public virtual DbSet<CountType> CountTypes { get; set; }
        public virtual DbSet<YarnComposition> YarnCompositions { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<BuyerType> BuyerTypes { get; set; }
        public virtual DbSet<SupplierType> SupplierTypes { get; set; }
        public virtual DbSet<PaymentTerm> PaymentTerms { get; set; }
        public virtual DbSet<DeliveryTerm> DeliveryTerms { get; set; }
        public virtual DbSet<Port> Ports { get; set; }
        public virtual DbSet<ShipmentTerm> ShipmentTerms { get; set; }
        public virtual DbSet<SubCategoryGroup> SubCategoryGroups { get; set; }
        public virtual DbSet<AccountGroup> AccountGroups { get; set; }
        public virtual DbSet<GroupName> GroupNames { get; set; }
        public virtual DbSet<Gauge> Gauges { get; set; }
        public virtual DbSet<MachineType> MachineTypes { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleBaseColor> ArticleBaseColors { get; set; }
        public virtual DbSet<ArticleBaseSize> ArticleBaseSizes { get; set; }
        public virtual DbSet<ArticleFlexField> ArticleFlexFields { get; set; }
        public virtual DbSet<Process> Processes { get; set; }
        public virtual DbSet<OperationLibrary> OperationLibraries { get; set; }
        public virtual DbSet<SubOperationLibrary> SubOperationLibraries { get; set; }
        public virtual DbSet<Factory> Factorys { get; set; }
        public virtual DbSet<CategoryMapMaterialType> CategoryMapMaterialTypes { get; set; }
        public virtual DbSet<MaterialTypeMapProductGroup> MaterialTypeMapProductGroups { get; set; }
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<Line> Lines { get; set; }
        public virtual DbSet<Holiday> Holidaies { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Calendar> Calendars { get; set; }
        public virtual DbSet<CalendarDetail> CalendarDetails { get; set; }
        public virtual DbSet<PlanningGroup> PlanningGroups { get; set; }
        public virtual DbSet<PlanningGroupFactory> PlanningGroupFactorys { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductGroupUOMConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductGroupConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PricePerConfiguration());
            modelBuilder.ApplyConfiguration(new ColorDefinitionConfiguration());
            modelBuilder.ApplyConfiguration(new ColorCardConfiguration());
            modelBuilder.ApplyConfiguration(new SizeOrWidthRangeConfiguration());
            modelBuilder.ApplyConfiguration(new ThemeConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyCurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
            modelBuilder.ApplyConfiguration(new GenderConfiguration());
            modelBuilder.ApplyConfiguration(new FabricContentConfiguration());
            modelBuilder.ApplyConfiguration(new StructureConfiguration());
            modelBuilder.ApplyConfiguration(new SpinningMethodConfiguration());
            modelBuilder.ApplyConfiguration(new CertificateConfiguration());
            modelBuilder.ApplyConfiguration(new DivisionConfiguration());
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new PatternConfiguration());
            modelBuilder.ApplyConfiguration(new OriginConfiguration());
            modelBuilder.ApplyConfiguration(new CropSeasonConfiguration());
            modelBuilder.ApplyConfiguration(new StapleConfiguration());
            modelBuilder.ApplyConfiguration(new StrengthConfiguration());
            modelBuilder.ApplyConfiguration(new MicronaireConfiguration());
            modelBuilder.ApplyConfiguration(new GradeConfiguration());
            modelBuilder.ApplyConfiguration(new TwistConfiguration());
            modelBuilder.ApplyConfiguration(new ConstructionConfiguration());
            modelBuilder.ApplyConfiguration(new UOMConversionConfiguration());
            modelBuilder.ApplyConfiguration(new UOMConfiguration());
            modelBuilder.ApplyConfiguration(new CountConfiguration());
            modelBuilder.ApplyConfiguration(new FiberTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FabricWidthConfiguration());
            modelBuilder.ApplyConfiguration(new SpinningProcessConfiguration());
            modelBuilder.ApplyConfiguration(new CountTypeConfiguration());
            modelBuilder.ApplyConfiguration(new YarnCompositionConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new BuyerTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PaymentTermConfiguration());
            modelBuilder.ApplyConfiguration(new DeliveryTermConfiguration());
            modelBuilder.ApplyConfiguration(new PortConfiguration());
            modelBuilder.ApplyConfiguration(new ShipmentTermConfiguration());
            modelBuilder.ApplyConfiguration(new SubCategoryGroupConfiguration());
            modelBuilder.ApplyConfiguration(new AccountGroupConfiguration());
            modelBuilder.ApplyConfiguration(new GroupNameConfiguration());
            modelBuilder.ApplyConfiguration(new GaugeConfiguration());
            modelBuilder.ApplyConfiguration(new MachineTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleBaseColorConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleBaseSizeConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleFlexFieldConfiguration());
            modelBuilder.ApplyConfiguration(new ProcessConfiguration());
            modelBuilder.ApplyConfiguration(new OperationLibraryConfiguration());
            modelBuilder.ApplyConfiguration(new SubOperationLibraryConfiguration());
            modelBuilder.ApplyConfiguration(new FactoryConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryMapMaterialTypeConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialTypeMapProductGroupConfiguration());
            modelBuilder.ApplyConfiguration(new MachineConfiguration());
            modelBuilder.ApplyConfiguration(new LineConfiguration());
            modelBuilder.ApplyConfiguration(new HolidayConfiguration());
            modelBuilder.ApplyConfiguration(new BuyerConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
           
            modelBuilder.ApplyConfiguration(new CalendarConfiguration());
            modelBuilder.ApplyConfiguration(new CalendarDetailConfiguration());
            modelBuilder.ApplyConfiguration(new PlanningGroupConfiguration());
            modelBuilder.ApplyConfiguration(new PlanningGroupFactoryConfiguration());

        }
    }
}
