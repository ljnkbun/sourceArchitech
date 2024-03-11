using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class StripScheduleDetailConfiguration : BaseConfiguration<StripScheduleDetail>
    {
        public override void Configure(EntityTypeBuilder<StripScheduleDetail> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Color).HasMaxLength(200);
            builder.Property(e => e.Size).HasMaxLength(200);
            builder.Property(e => e.UOM).HasMaxLength(200);

            builder.HasOne(e => e.StripSchedule)
                .WithMany(e => e.StripScheduleDetails)
                .HasForeignKey(e => e.StripScheduleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
