using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class StripScheduleDetailCaptureConfiguration : BaseConfiguration<StripScheduleDetailCapture>
    {
        public override void Configure(EntityTypeBuilder<StripScheduleDetailCapture> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Color).HasMaxLength(200);
            builder.Property(e => e.Size).HasMaxLength(200);
            builder.Property(e => e.UOM).HasMaxLength(200);

            builder.HasOne(e => e.StripScheduleCapture)
                .WithMany(e => e.StripScheduleDetailCaptures)
                .HasForeignKey(e => e.StripScheduleCaptureId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
