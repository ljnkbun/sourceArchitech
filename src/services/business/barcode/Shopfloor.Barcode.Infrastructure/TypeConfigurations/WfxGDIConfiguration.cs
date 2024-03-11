using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Barcode.Infrastructure.TypeConfigurations
{
    public class WfxGDIConfiguration : BaseConfiguration<WfxGDI>
    {
        public override void Configure(EntityTypeBuilder<WfxGDI> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ArticleCode).HasMaxLength(100);
            builder.Property(e => e.ArticleName).HasMaxLength(500);
            builder.Property(e => e.GDIType).HasMaxLength(100);
            builder.Property(e => e.WareHouse).HasMaxLength(500);
            builder.Property(e => e.ParentRollBarcode).HasMaxLength(100);
            builder.Property(e => e.BuyerStyleRef).HasMaxLength(500);
            builder.Property(e => e.ColorCode).HasMaxLength(100);
            builder.Property(e => e.ColorName).HasMaxLength(500);
            builder.Property(e => e.FPPOOCNUm).HasMaxLength(500);
            builder.Property(e => e.GDICreationDate).HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(e => e.OrderCreationDate).HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(e => e.GDINum).HasMaxLength(100);
            builder.Property(e => e.InternalShade).HasMaxLength(100);
            builder.Property(e => e.Location).HasMaxLength(500);
            builder.Property(e => e.OrderRefNum).HasMaxLength(500);
            builder.Property(e => e.RollBarcode).HasMaxLength(100);
            builder.Property(e => e.RollNo).HasMaxLength(500);
            builder.Property(e => e.RollOCRefNum).HasMaxLength(500);
            builder.Property(e => e.Shade).HasMaxLength(100);
            builder.Property(e => e.SizeCode).HasMaxLength(100);
            builder.Property(e => e.SizeName).HasMaxLength(500);
            builder.Property(e => e.UOM).HasMaxLength(100);
            builder.Property(e => e.GDIPendingUnits).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RollUnits).HasColumnType("decimal(28,8)");
        }
    }

}
