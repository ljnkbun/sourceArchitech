using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class LineMachineCapacityConfiguration : BaseConfiguration<LineMachineCapacity>
    {
        public override void Configure(EntityTypeBuilder<LineMachineCapacity> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.MachineId).HasColumnType("int");
            builder.Property(e => e.MachineName).HasMaxLength(200);
            builder.Property(e => e.LineId).HasColumnType("int");
            builder.Property(e => e.LineName).HasMaxLength(200);
            builder.Property(e => e.Standingcapacity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WorkingHours).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Date).HasColumnType("datetime");
        }
    }
}
