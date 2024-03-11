using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class InspectionBySizeConfiguration : BaseConfiguration<InspectionBySize>
    {
        public override void Configure(EntityTypeBuilder<InspectionBySize> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ColorCode).HasMaxLength(200);
            builder.Property(e => e.ColorName).HasMaxLength(500);
            builder.Property(e => e.SizeCode).HasMaxLength(200);
            builder.Property(e => e.SizeName).HasMaxLength(500);
            builder.Property(e => e.Shade).HasMaxLength(200);
            builder.Property(e => e.Lot).HasMaxLength(200);
            builder.Property(e => e.GRNQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.PreInspectedQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.LotQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.InspectionQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ActualQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.NoOfDefect).HasColumnType("int");
            builder.Property(e => e.OKQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.BGroupQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.BGroupUsable).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RejectedQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ExcessShortageQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ReasonforBGroup).HasMaxLength(500);
            builder.HasOne(s => s.Inspection)
             .WithMany(g => g.InspectionBySizes)
             .HasForeignKey(s => s.InspectionId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
