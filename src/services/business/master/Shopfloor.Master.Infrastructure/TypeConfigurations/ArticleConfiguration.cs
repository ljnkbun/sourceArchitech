using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class ArticleConfiguration : BaseConfiguration<Article>
    {
        public override void Configure(EntityTypeBuilder<Article> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ArticleCode).HasMaxLength(200);
            builder.Property(e => e.ArticleName).HasMaxLength(500);
            builder.Property(e => e.Category).HasMaxLength(200);
            builder.Property(e => e.MaterialType).HasMaxLength(200);
            builder.Property(e => e.ProductGroup).HasMaxLength(200);
            builder.Property(e => e.ProductSubCategory).HasMaxLength(200);
            builder.Property(e => e.ArticleDesc).HasMaxLength(500);
            builder.Property(e => e.OurContact).HasMaxLength(500);
            builder.Property(e => e.PurchaseUOM).HasMaxLength(500);
            builder.Property(e => e.StoringUOM).HasMaxLength(500);
            builder.Property(e => e.ConsumptionUOM).HasMaxLength(500);
            builder.Property(e => e.ColorCard).HasMaxLength(500);
            builder.Property(e => e.SizeWidthRange).HasMaxLength(500);
            builder.Property(e => e.Buyer).HasMaxLength(500);
            builder.Property(e => e.RestrictedItem).HasMaxLength(500);
            builder.Property(e => e.Supplier).HasMaxLength(500);
            builder.Property(e => e.Brand).HasMaxLength(500);
            builder.Property(e => e.BuyingCurrencyCode).HasMaxLength(500);
            builder.Property(e => e.PricePer).HasMaxLength(500);
            builder.Property(e => e.FabricMaterial).HasMaxLength(500);
            builder.Property(e => e.DivisionName).HasMaxLength(500);
            builder.Property(e => e.Season).HasMaxLength(500);
            builder.Property(e => e.BuyerStyleRef).HasMaxLength(500);
            builder.Property(e => e.ColorDefinition).HasMaxLength(500);
            builder.Property(e => e.SellingPriceCurrency).HasMaxLength(500);
            builder.Property(e => e.BuyerDepartmentName).HasMaxLength(500);
            builder.Property(e => e.HSCode).HasMaxLength(500);
            builder.Property(e => e.StyleType).HasMaxLength(500);
            builder.Property(e => e.Reference).HasMaxLength(500);
            builder.Property(e => e.ModelNo).HasMaxLength(500);
            builder.Property(e => e.MYear).HasMaxLength(500);
            builder.Property(e => e.PackingTypeName).HasMaxLength(500);
            builder.Property(e => e.StockTypeName).HasMaxLength(500);
            builder.Property(e => e.Gender).HasMaxLength(100);
            builder.Property(e => e.PerSizeCons).HasMaxLength(500);
            builder.Property(e => e.ReOrderLevel).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MinimumQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MaximumQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.BuyingPrice).HasColumnType("decimal(28,8)");
            builder.Property(e => e.OrderQtyMultiple).HasColumnType("decimal(28,8)");
            builder.Property(e => e.SAM).HasColumnType("decimal(28,8)");
            builder.Property(e => e.SellingPrice).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MinimumOrderQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RequirementMultiple).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ServiceCode).HasMaxLength(200);
            builder.Property(e => e.ServiceName).HasMaxLength(500);
        }
    }
}
