using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Infrastructure.TypeConfigurations
{
    public class InspectionBySizeConfiguration : BaseConfiguration<InspectionBySize>
    {
        public override void Configure(EntityTypeBuilder<InspectionBySize> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.BGroupQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.OKQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.CaptureMeter).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WarpDensity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RejectQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.CuttingWidth).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Length).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MadeQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WeftDensity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Weight).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Remark).HasMaxLength(100);

            builder.HasOne(s => s.ProductionOutput)
                .WithMany(g => g.InspectionBySizes)
                .HasForeignKey(s => s.ProductionOutputId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
