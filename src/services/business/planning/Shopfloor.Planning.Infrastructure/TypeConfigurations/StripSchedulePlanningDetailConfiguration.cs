using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class StripSchedulePlanningDetailConfiguration : BaseConfiguration<StripSchedulePlanningDetail>
    {
        public override void Configure(EntityTypeBuilder<StripSchedulePlanningDetail> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.StandardCapacity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ActualCapacity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ReceivedCapacity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WorkingHours).HasColumnType("decimal(3,1)");
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.Date).HasColumnType("datetime").HasDefaultValueSql("(getdate())");

            builder.HasOne(e => e.StripSchedule)
                .WithMany(e => e.StripSchedulePlanningDetails)
                .HasForeignKey(e => e.StripScheduleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
