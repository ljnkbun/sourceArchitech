using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class StripFactoryScheduleDetailConfiguration : BaseConfiguration<StripFactoryScheduleDetail>
    {
        public override void Configure(EntityTypeBuilder<StripFactoryScheduleDetail> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");

            builder.HasOne(s => s.StripFactorySchedule)
                     .WithMany(g => g.StripFactoryScheduleDetails)
                     .HasForeignKey(s => s.StripFactoryScheduleId)
                     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
