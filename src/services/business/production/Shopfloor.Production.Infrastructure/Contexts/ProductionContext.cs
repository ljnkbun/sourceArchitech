using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Services;
using Shopfloor.Production.Domain.Entities;
using Shopfloor.Production.Infrastructure.TypeConfigurations;

namespace Shopfloor.Production.Infrastructure.Contexts
{
    public partial class ProductionContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public ProductionContext(DbContextOptions<ProductionContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
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
        public virtual DbSet<InspectionBySize> InspectionBySizes { get; set; }
        public virtual DbSet<ProductionOutput> ProductionOutputs { get; set; }
        public virtual DbSet<DefectCapturing> DefectCapturings { get; set; }
        public virtual DbSet<DefectCapturingStandard> DefectCapturingStandards { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<DefectCapturing4Points> DefectCapturing4Points { get; set; }
        public virtual DbSet<DefectCapturing100Points> DefectCapturing100Points { get; set; }
        public virtual DbSet<Measurement> Measurements { get; set; }
        public virtual DbSet<FPPOOutput> FPPOOutputs { get; set; }
        public virtual DbSet<FPPOOutputDetail> FPPOOutputDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InspectionBySizeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductionOutputConfiguration());
            modelBuilder.ApplyConfiguration(new DefectCapturingConfiguration());
            modelBuilder.ApplyConfiguration(new DefectCapturingStandardConfiguration());
            modelBuilder.ApplyConfiguration(new AttachmentConfiguration());
            modelBuilder.ApplyConfiguration(new DefectCapturing4PointsConfiguration());
            modelBuilder.ApplyConfiguration(new DefectCapturing100PointsConfiguration());
            modelBuilder.ApplyConfiguration(new MeasurementConfiguration());

            modelBuilder.ApplyConfiguration(new FPPOOutputConfiguration());
            modelBuilder.ApplyConfiguration(new FPPOOutputDetailConfiguration());
        }
    }
}
