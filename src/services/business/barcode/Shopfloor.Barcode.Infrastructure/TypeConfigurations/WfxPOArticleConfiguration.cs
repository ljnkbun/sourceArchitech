using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Barcode.Infrastructure.TypeConfigurations
{
    public class WfxPOArticleConfiguration : BaseConfiguration<WfxPOArticle>
    {
        public override void Configure(EntityTypeBuilder<WfxPOArticle> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ArticleCode).HasMaxLength(100);
            builder.Property(e => e.ArticleName).HasMaxLength(500);
            builder.Property(e => e.PONo).HasMaxLength(100);
            builder.Property(e => e.ColorCode).HasMaxLength(100);
            builder.Property(e => e.ColorName).HasMaxLength(500);
            builder.Property(e => e.SizeCode).HasMaxLength(100);
            builder.Property(e => e.SizeName).HasMaxLength(500);
            builder.Property(e => e.OrderRefNum).HasMaxLength(100);
            builder.Property(e => e.POStatus).HasMaxLength(100);
            builder.Property(e => e.POCreationDate).HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(e => e.LastRevisedDate).HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(e => e.PPYDGDate).HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(e => e.InHouseDate).HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(e => e.PurchaseOfficer).HasMaxLength(100);
            builder.Property(e => e.ShipmentTerm).HasMaxLength(100);
            builder.Property(e => e.PaymentTerm).HasMaxLength(100);
            builder.Property(e => e.DeliveryTerms).HasMaxLength(100);
            builder.Property(e => e.OCFactory).HasMaxLength(500);
            builder.Property(e => e.FactorySite).HasMaxLength(500);
            builder.Property(e => e.SizeCode).HasMaxLength(500);
            builder.Property(e => e.UOM).HasMaxLength(500);
            builder.Property(e => e.ShipToAddress).HasMaxLength(500);
            builder.Property(e => e.ProductSubCat).HasMaxLength(500);
            builder.Property(e => e.RMPOCreationMonth).HasMaxLength(500);
            builder.Property(e => e.Traceable).HasMaxLength(500);
            builder.Property(e => e.MemberCompanyName).HasMaxLength(500);
            builder.Property(e => e.Supplier).HasMaxLength(500);
            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ETD).HasMaxLength(100);
            builder.Property(e => e.ETA).HasMaxLength(100);
            builder.Property(e => e.OrderID).HasMaxLength(100);

        }
    }
}
