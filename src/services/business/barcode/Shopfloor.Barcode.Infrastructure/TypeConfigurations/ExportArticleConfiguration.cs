﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Barcode.Infrastructure.TypeConfigurations
{
    public class ExportArticleConfiguration : BaseMasterConfiguration<ExportArticle>
    {
        public override void Configure(EntityTypeBuilder<ExportArticle> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(100);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.Buyer).HasMaxLength(500);
            builder.Property(e => e.Color).HasMaxLength(100);
            builder.Property(e => e.Size).HasMaxLength(100);
            builder.Property(e => e.LotNo).HasMaxLength(500);
            builder.Property(e => e.SummaryOC).HasMaxLength(500);
            builder.Property(e => e.DeliveryOC).HasMaxLength(500);
            builder.Property(e => e.GDINo).HasMaxLength(100);
            builder.Property(e => e.GDIType).HasMaxLength(100);
            builder.Property(e => e.FromSite).HasMaxLength(500);
            builder.Property(e => e.Note).HasMaxLength(1000);
            builder.Property(e => e.Status).HasColumnType("tinyint");
            builder.Property(e => e.UOM).HasMaxLength(100);
            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");

            builder.HasOne(s => s.Export)
                .WithMany(g => g.ExportArticles)
                .HasForeignKey(s => s.ExportId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
