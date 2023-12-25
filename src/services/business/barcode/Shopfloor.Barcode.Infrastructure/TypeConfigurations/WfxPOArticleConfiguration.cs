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
            builder.Property(e => e.BuyerStyleNum).HasMaxLength(100);
            builder.Property(e => e.ColorCode).HasMaxLength(100);
            builder.Property(e => e.ColorName).HasMaxLength(500);
            builder.Property(e => e.ExecutionType).HasMaxLength(100);
            builder.Property(e => e.InternalLotNo).HasMaxLength(500);
            builder.Property(e => e.MaterialType).HasMaxLength(100);
            builder.Property(e => e.OCNum).HasMaxLength(100);
            builder.Property(e => e.OrderCompany).HasMaxLength(500);
            builder.Property(e => e.OrderCreationDate).HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(e => e.OrderRefNum).HasMaxLength(100);
            builder.Property(e => e.OrderType).HasMaxLength(100);
            builder.Property(e => e.StyleCode).HasMaxLength(100);
            builder.Property(e => e.OrderType).HasMaxLength(100);
            builder.Property(e => e.SupplierRef).HasMaxLength(500);
        }
    }
}
