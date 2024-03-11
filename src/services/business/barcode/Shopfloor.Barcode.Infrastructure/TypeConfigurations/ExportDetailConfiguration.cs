using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Barcode.Infrastructure.TypeConfigurations
{
    public class ExportDetailConfiguration : BaseMasterConfiguration<ExportDetail>
    {
        public override void Configure(EntityTypeBuilder<ExportDetail> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(100);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.ArticleCode).HasMaxLength(100);
            builder.Property(e => e.ArticleName).HasMaxLength(500);
            builder.Property(e => e.Note).HasMaxLength(1000);
            builder.Property(e => e.UOM).HasMaxLength(100);
            builder.Property(e => e.Shade).HasMaxLength(100);
            builder.Property(e => e.InternalShade).HasMaxLength(100);
            builder.Property(e => e.OC).HasMaxLength(500);
            builder.Property(e => e.Location).HasMaxLength(500);
            builder.Property(e => e.BuyerStyleRef).HasMaxLength(500);
            builder.Property(e => e.ColorCode).HasMaxLength(100);
            builder.Property(e => e.SizeCode).HasMaxLength(100);
            builder.Property(e => e.Grade).HasMaxLength(100);
            builder.Property(e => e.FPPOOCNUm).HasMaxLength(500);
            builder.Property(e => e.ParentBarcode).HasMaxLength(100);
            builder.Property(e => e.Barcode).HasMaxLength(100);
            builder.Property(e => e.No).HasMaxLength(100);
            builder.Property(e => e.OCRefNum).HasMaxLength(500);
            builder.Property(e => e.WareHouse).HasMaxLength(500);
            builder.Property(e => e.LotNo).HasMaxLength(500);
            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RemainQuantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WeightPerCone).HasColumnType("decimal(28,8)");
            builder.Property(e => e.NumberOfCone).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Status).HasColumnType("tinyint");

            builder.HasOne(s => s.ExportArticle)
                 .WithMany(g => g.ExportDetails)
                 .HasForeignKey(s => s.ExportArticleId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.ArticleBarcode)
                 .WithMany(g => g.ExportDetails)
                 .HasForeignKey(p => p.ArticleBarcodeId)
                 .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

