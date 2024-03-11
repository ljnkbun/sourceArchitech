using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Services;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Inspection.Infrastructure.TypeConfigurations;

namespace Shopfloor.Inspection.Infrastructure.Contexts
{
    public partial class InspectionContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public InspectionContext(DbContextOptions<InspectionContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
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
        public virtual DbSet<Shopfloor.Inspection.Domain.Entities.Inspection> Inspections { get; set; }
        public virtual DbSet<InspectionDefectCapturing> InspectionDefectCapturings { get; set; }
        public virtual DbSet<InspectionMesurement> InspectionMesurements { get; set; }
        public virtual DbSet<InspectionBySize> InspectionBySizes { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<AQLVersion> AQLVersions { get; set; }
        public virtual DbSet<AQL> AQLs { get; set; }
        public virtual DbSet<FabricWeight> FabricWeights { get; set; }
        public virtual DbSet<OneHundredPointSystem> OneHundredPointSystems { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<TestGroup> TestGroups { get; set; }
        public virtual DbSet<Conversion> Conversions { get; set; }
        public virtual DbSet<QCRequest> QCRequests { get; set; }
        public virtual DbSet<QCRequestArticle> QCRequestArticles { get; set; }
        public virtual DbSet<QCDefectType> QCDefectTypes { get; set; }
        public virtual DbSet<QCDefinition> QCDefinitions { get; set; }
        public virtual DbSet<QCDefect> QCDefects { get; set; }
        public virtual DbSet<QCDefinitionDefect> QCDefinitionDefects { get; set; }
        public virtual DbSet<ProblemTimeline> ProblemTimelines { get; set; }
        public virtual DbSet<ProblemCorrectiveAction> ProblemCorrectiveActions { get; set; }
        public virtual DbSet<ProblemRootCause> ProblemRootCauses { get; set; }
        public virtual DbSet<ZoneType> ZoneTypes { get; set; }
        public virtual DbSet<Inpection100PointSys> Inpection100PointSyss { get; set; }
        public virtual DbSet<InspectionDefectCapturing100PointSys> InspectionDefectCapturing100PointSyss { get; set; }
        public virtual DbSet<InspectionDefectError100PointSys> InspectionDefectError100PointSyss { get; set; }
        public virtual DbSet<Inpection4PointSys> Inpection4PointSyss { get; set; }
        public virtual DbSet<InspectionDefectCapturing4PointSys> InspectionDefectCapturing4PointSyss { get; set; }
        public virtual DbSet<InspectionDefectError4PointSys> InspectionDefectError4PointSyss { get; set; }
        public virtual DbSet<InpectionTCStandard> InpectionTCStandards { get; set; }
        public virtual DbSet<InspectionDefectCapturingTCStandard> InspectionDefectCapturingTCStandards { get; set; }
        public virtual DbSet<QCType> QCTypes { get; set; }
        public virtual DbSet<FourPointsSystem> FourPointsSystems { get; set; }
        public virtual DbSet<FourPointsSystemDetail> FourPointsSystemDetails { get; set; }
        public virtual DbSet<OneHundredPointSystemDetail> OneHundredPointSystemDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InspectionBySizeConfiguration());
            modelBuilder.ApplyConfiguration(new InspectionMesurementConfiguration());
            modelBuilder.ApplyConfiguration(new InspectionConfiguration());
            modelBuilder.ApplyConfiguration(new InspectionDefectCapturingConfiguration());
            modelBuilder.ApplyConfiguration(new AttachmentConfiguration());
            modelBuilder.ApplyConfiguration(new AQLVersionConfiguration());
            modelBuilder.ApplyConfiguration(new AQLConfiguration());
            modelBuilder.ApplyConfiguration(new FabricWeightConfiguration());
            modelBuilder.ApplyConfiguration(new OneHundredPointSystemConfiguration());
            modelBuilder.ApplyConfiguration(new TestConfiguration());
            modelBuilder.ApplyConfiguration(new TestGroupConfiguration());
            modelBuilder.ApplyConfiguration(new ConversionConfiguration());
            modelBuilder.ApplyConfiguration(new QCRequestConfiguration());
            modelBuilder.ApplyConfiguration(new QCRequestArticleConfiguration());
            modelBuilder.ApplyConfiguration(new QCDefectTypeConfiguration());
            modelBuilder.ApplyConfiguration(new QCDefectConfiguration());
            modelBuilder.ApplyConfiguration(new QCDefinitionConfiguration());
            modelBuilder.ApplyConfiguration(new QCDefinitionDefectConfiguration());
            modelBuilder.ApplyConfiguration(new ProblemTimelineConfiguration());
            modelBuilder.ApplyConfiguration(new ProblemCorrectiveActionConfiguration());
            modelBuilder.ApplyConfiguration(new ProblemRootCauseConfiguration());
            modelBuilder.ApplyConfiguration(new ZoneTypeConfiguration());
            modelBuilder.ApplyConfiguration(new InpectionTCStandardConfiguration());
            modelBuilder.ApplyConfiguration(new InspectionDefectCapturingTCStandardConfiguration());
            modelBuilder.ApplyConfiguration(new Inpection100PointSysConfiguration());
            modelBuilder.ApplyConfiguration(new InspectionDefectCapturing100PointSysConfiguration());
            modelBuilder.ApplyConfiguration(new InspectionDefectError100PointSysConfiguration());
            modelBuilder.ApplyConfiguration(new Inpection4PointSysConfiguration());
            modelBuilder.ApplyConfiguration(new InspectionDefectCapturing4PointSysConfiguration());
            modelBuilder.ApplyConfiguration(new InspectionDefectError4PointSysConfiguration());
            modelBuilder.ApplyConfiguration(new QCTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FourPointsSystemConfiguration());
            modelBuilder.ApplyConfiguration(new FourPointsSystemDetailConfiguration());
            modelBuilder.ApplyConfiguration(new OneHundredPointSystemConfiguration());
            modelBuilder.ApplyConfiguration(new OneHundredPointSystemDetailConfiguration());
        }
    }
}
