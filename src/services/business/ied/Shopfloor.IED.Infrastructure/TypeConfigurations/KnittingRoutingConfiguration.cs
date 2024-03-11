using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class KnittingRoutingConfiguration : BaseConfiguration<KnittingRouting>
    {
        public override void Configure(EntityTypeBuilder<KnittingRouting> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.KnittingProcess).IsRequired().HasMaxLength(100);
            builder.Property(e => e.KnittingOperation).IsRequired().HasMaxLength(100);
            builder.Property(e => e.MachineTypeName).IsRequired().HasMaxLength(100);
            builder.Property(e => e.KnittingProcessCode).HasColumnType("varchar(100)");
            builder.Property(e => e.KnittingOperationCode).HasColumnType("varchar(100)");
            builder.HasOne(e => e.KnittingIED)
               .WithMany(e => e.KnittingRoutings)
               .HasForeignKey(e => e.KnittingIEDId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
