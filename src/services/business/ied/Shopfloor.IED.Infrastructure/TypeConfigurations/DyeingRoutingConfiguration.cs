using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class DyeingRoutingConfiguration : BaseConfiguration<DyeingRouting>
    {
        public override void Configure(EntityTypeBuilder<DyeingRouting> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.DyeingProcess).HasMaxLength(250);

            builder.Property(e => e.DyeingOperation).HasMaxLength(250);

            builder.Property(e => e.MachineCode).HasMaxLength(250);

            builder.Property(e => e.MachineName).HasMaxLength(250);

            builder.Property(e => e.DyeingProcessCode).HasColumnType("varchar(100)");

            builder.Property(e => e.DyeingOperationCode).HasColumnType("varchar(100)");

            builder.Property(e => e.Efficiency).HasColumnType("decimal(28,8)");

            builder.Property(e => e.MachineTime).HasColumnType("decimal(28,8)");

            builder.Property(e => e.Temperature).HasColumnType("decimal(28,8)");

            builder.Property(e => e.OperationTime).HasColumnType("decimal(28,8)");

            builder.HasOne(s => s.DyeingIED)
                .WithMany(g => g.DyeingRoutings)
                .HasForeignKey(s => s.DyeingIEDId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}