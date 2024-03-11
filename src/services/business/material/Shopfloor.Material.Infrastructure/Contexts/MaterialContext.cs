using Microsoft.EntityFrameworkCore;

using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Services;
using Shopfloor.Material.Domain.Entities;
using Shopfloor.Material.Infrastructure.TypeConfigurations;

namespace Shopfloor.Material.Infrastructure.Contexts
{
    public partial class MaterialContext : DbContext
    {
        private readonly IDateTimeService _dateTime;

        private readonly IAuthenticatedUserService _authenticatedUser;

        public MaterialContext(DbContextOptions<MaterialContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
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

        public virtual DbSet<AutoIncrement> AutoIncrements { get; set; }
        public virtual DbSet<MaterialRequest> MaterialRequests { get; set; }
        public virtual DbSet<FabricComposition> FabricCompositions { get; set; }
        public virtual DbSet<MOQMSQRoudingOptionItem> MOQMSQRoudingOptionItems { get; set; }
        public virtual DbSet<SupplierWisePurchaseOption> SupplierWisePurchaseOptions { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<BuyerProductCategory> BuyerProductCategoryMappings { get; set; }
        public virtual DbSet<PriceListDetailSize> PriceListDetailSizes { get; set; }
        public virtual DbSet<PriceListDetailColor> PriceListDetailColors { get; set; }
        public virtual DbSet<PriceList> PriceLists { get; set; }
        public virtual DbSet<SupplierProductCategory> SupplierProductCategories { get; set; }
        public virtual DbSet<DynamicColumn> DynamicColumns { get; set; }
        public virtual DbSet<DynamicColumnContent> DynamicColumnContents { get; set; }
        public virtual DbSet<MaterialRequestDynamicColumn> MaterialRequestDynamicColumns { get; set; }
        public virtual DbSet<MaterialRequestFile> MaterialRequestFiles { get; set; }
        public virtual DbSet<SupplierFile> SupplierFiles { get; set; }
        public virtual DbSet<BuyerFile> BuyerFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutoIncrementConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialRequestConfiguration());
            modelBuilder.ApplyConfiguration(new FabricCompositionConfiguration());
            modelBuilder.ApplyConfiguration(new MOQMSQRoudingOptionItemConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierWisePurchaseOptionConfiguration());
            modelBuilder.ApplyConfiguration(new BuyerConfiguration());
            modelBuilder.ApplyConfiguration(new BuyerProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new PriceListDetailColorConfiguration());
            modelBuilder.ApplyConfiguration(new PriceListDetailSizeConfiguration());
            modelBuilder.ApplyConfiguration(new PriceListDetailConfiguration());
            modelBuilder.ApplyConfiguration(new PriceListConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new DynamicColumnConfiguration());
            modelBuilder.ApplyConfiguration(new DynamicColumnContentConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialRequestDynamicColumnConfiguration());
            modelBuilder.ApplyConfiguration(new MaterialRequestFileConfiguration());
            modelBuilder.ApplyConfiguration(new BuyerFileConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierFileConfiguration());
        }
    }
}