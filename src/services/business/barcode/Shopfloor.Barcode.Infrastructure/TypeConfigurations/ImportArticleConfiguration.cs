using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Barcode.Infrastructure.TypeConfigurations
{
    public class ImportArticleConfiguration : BaseConfiguration<ImportArticle>
    {
        public override void Configure(EntityTypeBuilder<ImportArticle> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ArticleCode).HasMaxLength(50);
            builder.Property(e => e.ArticleName).HasMaxLength(100);
            builder.Property(e => e.PONo).HasMaxLength(100);
            builder.Property(e => e.GDNNumber).HasMaxLength(50);
            builder.Property(e => e.SupplierName).HasMaxLength(100);
            builder.Property(e => e.OrderRefNum).HasMaxLength(50);
            builder.Property(e => e.FromSite).HasMaxLength(100);
            builder.Property(e => e.ToSite).HasMaxLength(100);
            builder.Property(e => e.GDNType).HasMaxLength(100);
            builder.Property(e => e.Warehouse).HasMaxLength(500);
            builder.Property(e => e.ColorCode).HasMaxLength(50);
            builder.Property(e => e.ColorName).HasMaxLength(100);
            builder.Property(e => e.SizeCode).HasMaxLength(50);
            builder.Property(e => e.UOM).HasMaxLength(50);
            builder.Property(e => e.OCNum).HasMaxLength(50);
            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Status).HasColumnType("tinyint");
            builder.HasOne(s => s.Import)
              .WithMany(g => g.ImportArticles)
              .HasForeignKey(s => s.ImportId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
