using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Barcode.Infrastructure.TypeConfigurations
{
    public class WfxGDNConfiguration : BaseConfiguration<WfxGDN>
    {
        public override void Configure(EntityTypeBuilder<WfxGDN> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.WFXArticleCode).HasMaxLength(100);
            builder.Property(e => e.WFXArticleName).HasMaxLength(500);
            builder.Property(e => e.GDNType).HasMaxLength(100);
            builder.Property(e => e.GDNNum).HasMaxLength(100);
            builder.Property(e => e.WareHouse).HasMaxLength(500);
            builder.Property(e => e.ParentRollBarcode).HasMaxLength(100);
            builder.Property(e => e.ColorCode).HasMaxLength(100);
            builder.Property(e => e.ColorName).HasMaxLength(500);
            builder.Property(e => e.FPPOOCNUm).HasMaxLength(500);
            builder.Property(e => e.GDINum).HasMaxLength(100);
            builder.Property(e => e.GDNCreationDate).HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
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
            builder.Property(e => e.RollUnits).HasColumnType("decimal(28,8)");
        }
    }

}
