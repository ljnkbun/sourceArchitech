using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Barcode.Infrastructure.TypeConfigurations
{
    public class ImportDetailConfiguration : BaseConfiguration<ImportDetail>
    {
        public override void Configure(EntityTypeBuilder<ImportDetail> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Status).HasColumnType("tinyint");
            builder.Property(e => e.Color).HasMaxLength(50);
            builder.Property(e => e.PONo).HasMaxLength(50);
            builder.Property(e => e.Size).HasMaxLength(50);
            builder.Property(e => e.UOM).HasMaxLength(50);
            builder.Property(e => e.OC).HasMaxLength(50);
            builder.Property(e => e.Shade).HasMaxLength(50);
            builder.Property(e => e.Grade).HasMaxLength(50);
            builder.Property(e => e.NumberOfCone).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WeightPerCone).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Note).HasMaxLength(250);
            builder.Property(e => e.ArticleName).HasMaxLength(100);
            builder.Property(e => e.ArticleCode).HasMaxLength(50);
            builder.Property(e => e.Unit).HasMaxLength(50);
            builder.Property(e => e.Location).HasMaxLength(500);
            builder.Property(e => e.LotNo).HasMaxLength(500);
            builder.Property(e => e.Site).HasMaxLength(500);
            builder.HasOne(s => s.ImportArticle)
                .WithMany(g => g.ImportDetails)
                .HasForeignKey(s => s.ImportArticleId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.ArticleBarcode)
              .WithMany(g => g.ImportDetails)
              .HasForeignKey(s => s.AriticleBarcodeId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
