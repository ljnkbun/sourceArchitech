using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class StripScheduleConfiguration : BaseConfiguration<StripSchedule>
    {
        public override void Configure(EntityTypeBuilder<StripSchedule> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ProfileEfficiencyValue).HasColumnType("decimal(28,8)");
            builder.Property(e => e.OrderEfficiencyValue).HasColumnType("decimal(28,8)");
            builder.Property(e => e.StripEfficiencyValue).HasColumnType("decimal(28,8)");
            builder.Property(e => e.FromDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            builder.Property(e => e.ToDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.Gauge).HasMaxLength(250);
        }
    }
}
