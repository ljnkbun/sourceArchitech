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
            builder.Property(e => e.Note).HasMaxLength(1000);
            builder.Property(e => e.UOM).HasMaxLength(100);
            builder.Property(e => e.Shade).HasMaxLength(100);
            builder.Property(e => e.OC).HasMaxLength(500);
            builder.Property(e => e.LotNo).HasMaxLength(500);
            builder.Property(e => e.Meter).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Unit).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Yard).HasColumnType("decimal(28,8)");
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

