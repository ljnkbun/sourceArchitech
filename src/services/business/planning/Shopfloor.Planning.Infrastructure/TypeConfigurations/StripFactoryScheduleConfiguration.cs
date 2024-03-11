using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class StripFactoryScheduleConfiguration : BaseConfiguration<StripFactorySchedule>
    {
        public override void Configure(EntityTypeBuilder<StripFactorySchedule> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.StripFactoryId).HasColumnType("int");
            builder.Property(e => e.StripScheduleId).HasColumnType("int");

            builder.HasOne(s => s.StripFactory)
                 .WithMany(g => g.StripFactorySchedules)
                 .HasForeignKey(s => s.StripFactoryId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.StripSchedule)
                 .WithMany(g => g.StripFactorySchedules)
                 .HasForeignKey(s => s.StripScheduleId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
