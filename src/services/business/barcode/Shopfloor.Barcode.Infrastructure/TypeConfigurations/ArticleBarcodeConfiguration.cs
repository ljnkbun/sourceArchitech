using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Barcode.Infrastructure.TypeConfigurations
{
    public class ArticleBarcodeConfiguration : BaseConfiguration<ArticleBarcode>
    {
        public override void Configure(EntityTypeBuilder<ArticleBarcode> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Barcode).HasMaxLength(500);
            builder.HasIndex(e => e.Barcode).IsUnique();
            builder.Property(e => e.ArticleCode).HasMaxLength(100);
            builder.Property(e => e.ArticleName).HasMaxLength(500);
            builder.Property(e => e.SupplierName).HasMaxLength(500);
            builder.Property(e => e.PONo).HasMaxLength(500);
            builder.Property(e => e.Note).HasMaxLength(1000);
            builder.Property(e => e.ArticleUOM).HasMaxLength(100);
            builder.Property(e => e.BarcodeUOM).HasMaxLength(100);
            builder.Property(e => e.Shade).HasMaxLength(100);
            builder.Property(e => e.FromId).HasMaxLength(1000);
            builder.Property(e => e.ToId).HasMaxLength(1000);
            builder.Property(e => e.Color).HasMaxLength(100);
            builder.Property(e => e.Grade).HasMaxLength(100);
            builder.Property(e => e.Size).HasMaxLength(100);
            builder.Property(e => e.OC).HasMaxLength(500);
            builder.Property(e => e.Location).HasMaxLength(500);
            builder.Property(e => e.LotNo).HasMaxLength(500);
            builder.Property(e => e.Site).HasMaxLength(500);
            builder.Property(e => e.Category).HasMaxLength(100);
            builder.Property(e => e.SubCategory).HasMaxLength(100);
            builder.Property(e => e.GroupCode).HasMaxLength(100);
            builder.Property(e => e.OrderRefNum).HasMaxLength(500);
            builder.Property(e => e.GDINum).HasMaxLength(100);
            builder.Property(e => e.FPPOOCNUm).HasMaxLength(100);
            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RemainQuantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.NumberOfCone).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WeightPerCone).HasColumnType("decimal(28,8)");
            builder.Property(e => e.OKQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.BGroupQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.FPPOQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RejectQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Balance).HasColumnType("decimal(28,8)");
            builder.Property(e => e.UpdatedToDate).HasColumnType("decimal(28,8)");
        }
    }
}
