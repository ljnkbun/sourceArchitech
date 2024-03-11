using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class PlanningGroupConfiguration : BaseMasterConfiguration<PlanningGroup>
    {
        public override void Configure(EntityTypeBuilder<PlanningGroup> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.HasOne(e => e.Process)
                .WithMany(e => e.PlanningGroups)
                .HasForeignKey(e => e.ProcessId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.Calendar)
                .WithMany(e => e.PlanningGroups)
                .HasForeignKey(e => e.CalendarId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
