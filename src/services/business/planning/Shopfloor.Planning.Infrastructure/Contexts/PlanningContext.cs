using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Models.Entities;
using Shopfloor.Core.Services;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Planning.Infrastructure.TypeConfigurations;

namespace Shopfloor.Planning.Infrastructure.Contexts
{
    public partial class PlanningContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public PlanningContext(DbContextOptions<PlanningContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
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
        public virtual DbSet<OrderEfficiency> OrderEfficiencies { get; set; }
        public virtual DbSet<LearningCurveEfficiency> LearningCurveEfficiencies { get; set; }
        public virtual DbSet<LearningCurveDetailEfficiency> LearningCurveDetailEfficiencies { get; set; }
        public virtual DbSet<ProfileEfficiency> ProfileEfficiencies { get; set; }
        public virtual DbSet<ProfileEfficiencyDetail> ProfileEfficiencyDetails { get; set; }
        public virtual DbSet<MergeSplitPOR> MergeSplitPORs { get; set; }
        public virtual DbSet<POR> PORs { get; set; }
        public virtual DbSet<PORDetail> PORDetails { get; set; }
        public virtual DbSet<CapacityColor> CapacityColors { get; set; }
        public virtual DbSet<FactoryCapacity> FactoryCapacities { get; set; }
        public virtual DbSet<StripFactory> StripFactories { get; set; }
        public virtual DbSet<StripSchedule> StripSchedules { get; set; }
        public virtual DbSet<StripScheduleCapture> StripScheduleCaptures { get; set; }
        public virtual DbSet<StripFactorySchedule> StripFactorySchedules { get; set; }
        public virtual DbSet<StripScheduleDetail> StripScheduleDetails { get; set; }
        public virtual DbSet<StripScheduleDetailCapture> StripScheduleDetailCaptures { get; set; }
        public virtual DbSet<StripSchedulePlanningDetail> StripSchedulePlanningDetails { get; set; }
        public virtual DbSet<StripSchedulePlanningDetailCapture> StripSchedulePlanningDetailCaptures { get; set; }
        public virtual DbSet<MergeSplitPorDetail> MergeSplitPorDetails { get; set; }
        public virtual DbSet<StripFactoryDetail> StripFactoryDetails { get; set; }
        public virtual DbSet<StripFactoryScheduleDetail> StripFactoryScheduleDetails { get; set; }
        public virtual DbSet<LineMachineCapacity> LineMachineCapacities { get; set; }
        public virtual DbSet<FPPO> FPPOs { get; set; }
        public virtual DbSet<FPPODetail> FPPODetails { get; set; }
		public virtual DbSet<CriticalPart> CriticalParts { get; set; }
		public virtual DbSet<AutoIncrement> AutoIncrements { get; set; }
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AutoIncrementMappingConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEfficiencyConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileEfficiencyConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileEfficiencyDetailConfiguration());
            modelBuilder.ApplyConfiguration(new LearningCurveEfficiencyConfiguration());
            modelBuilder.ApplyConfiguration(new LearningCurveDetailEfficiencyConfiguration());
            modelBuilder.ApplyConfiguration(new CapacityColorConfiguration());
            modelBuilder.ApplyConfiguration(new FactoryCapacityConfiguration());
            modelBuilder.ApplyConfiguration(new PORConfiguration());
            modelBuilder.ApplyConfiguration(new PORDetailConfiguration());
            modelBuilder.ApplyConfiguration(new MergeSplitPORConfiguration());
            modelBuilder.ApplyConfiguration(new StripFactoryConfiguration());
            modelBuilder.ApplyConfiguration(new StripScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new StripScheduleCaptureConfiguration());
            modelBuilder.ApplyConfiguration(new StripScheduleDetailConfiguration());
            modelBuilder.ApplyConfiguration(new StripScheduleDetailCaptureConfiguration());
            modelBuilder.ApplyConfiguration(new StripSchedulePlanningDetailConfiguration());
            modelBuilder.ApplyConfiguration(new StripSchedulePlanningDetailCaptureConfiguration());
            modelBuilder.ApplyConfiguration(new StripFactoryScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new MergeSplitPorDetailConfiguration());
            modelBuilder.ApplyConfiguration(new StripFactoryDetailConfiguration());
            modelBuilder.ApplyConfiguration(new StripFactoryScheduleDetailConfiguration());
            modelBuilder.ApplyConfiguration(new LineMachineCapacityConfiguration());
            modelBuilder.ApplyConfiguration(new FPPOConfiguration());
            modelBuilder.ApplyConfiguration(new FPPODetailConfiguration());
			modelBuilder.ApplyConfiguration(new CriticalPartConfiguration());
		}
    }
}
