using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class MachineConfiguration : BaseMasterConfiguration<Machine>
    {
        public override void Configure(EntityTypeBuilder<Machine> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.SerialNo).HasMaxLength(200);
            builder.Property(e => e.Remarks).HasMaxLength(200);
            builder.Property(e => e.Gauge).HasMaxLength(250);
            builder.Property(e => e.MachineDiameter).HasMaxLength(250);

            builder.HasOne(e => e.Factory)
                .WithMany(e => e.Machines)
                .HasForeignKey(e => e.FactoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Process)
                .WithMany(e => e.Machines)
                .HasForeignKey(e => e.ProcessId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
