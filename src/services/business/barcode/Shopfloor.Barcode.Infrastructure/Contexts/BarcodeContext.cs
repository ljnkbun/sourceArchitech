using Microsoft.EntityFrameworkCore;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Barcode.Infrastructure.TypeConfigurations;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Services;

namespace Shopfloor.Barcode.Infrastructure.Contexts
{
    public partial class BarcodeContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public BarcodeContext(DbContextOptions<BarcodeContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
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

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<ArticleBarcode> ArticleBarcodes { get; set; }
        public virtual DbSet<ArticleBarcodeHistory> ArticleBarcodeHistories { get; set; }
        public virtual DbSet<BarcodeLocation> BarcodeLocations { get; set; }
        public virtual DbSet<Import> Imports { get; set; }
        public virtual DbSet<ImportArticle> ImportArticles { get; set; }
        public virtual DbSet<ImportDetail> ImportDetails { get; set; }

        public virtual DbSet<Export> Exports { get; set; }
        public virtual DbSet<ExportArticle> ExportArticles { get; set; }
        public virtual DbSet<ExportDetail> ExportDetails { get; set; }

        public virtual DbSet<WfxPOArticle> WfxPOArticles { get; set; }
        public virtual DbSet<WfxPOArticleHistory> WfxPOArticleHistories { get; set; }
        public virtual DbSet<WfxGDI> WfxGDIs { get; set; }
        public virtual DbSet<WfxGDIHistory> WfxGDIHistories { get; set; }
        public virtual DbSet<WfxGDN> WfxGDNs { get; set; }
        public virtual DbSet<WfxGDNHistory> WfxGDNHistories { get; set; }
        public virtual DbSet<AppVersion> AppVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleBarcodeConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleBarcodeHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new BarcodeLocationConfiguration());
            modelBuilder.ApplyConfiguration(new ImportArticleConfiguration());
            modelBuilder.ApplyConfiguration(new ImportConfiguaration());
            modelBuilder.ApplyConfiguration(new ImportDetailConfiguration());

            modelBuilder.ApplyConfiguration(new ExportConfiguration());
            modelBuilder.ApplyConfiguration(new ExportArticleConfiguration());
            modelBuilder.ApplyConfiguration(new ExportDetailConfiguration());

            modelBuilder.ApplyConfiguration(new WfxPOArticleConfiguration());
            modelBuilder.ApplyConfiguration(new WfxPOArticleHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new WfxGDIConfiguration());
            modelBuilder.ApplyConfiguration(new WfxGDIHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new WfxGDNConfiguration());
            modelBuilder.ApplyConfiguration(new WfxGDNHistoryConfiguration());
            modelBuilder.ApplyConfiguration(new AppVersionConfiguration());
        }
    }
}