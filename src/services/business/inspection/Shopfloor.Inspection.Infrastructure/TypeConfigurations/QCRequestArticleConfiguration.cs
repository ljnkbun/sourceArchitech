using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Shopfloor.Core.Extensions.Objects;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class QCRequestArticleConfiguration : BaseConfiguration<QCRequestArticle>
    {
        public override void Configure(EntityTypeBuilder<QCRequestArticle> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.QCRequestId).HasColumnType("int");
            builder.Property(e => e.ArticleCode).HasMaxLength(200);
            builder.Property(e => e.ArticleName).HasMaxLength(500);
            builder.Property(e => e.ColorCode).HasMaxLength(200);
            builder.Property(e => e.ColorName).HasMaxLength(500);
            builder.Property(e => e.SizeCode).HasMaxLength(200);
            builder.Property(e => e.SizeName).HasMaxLength(500);
            builder.Property(e => e.Shade).HasMaxLength(200);
            builder.Property(e => e.Lot).HasMaxLength(200);
            builder.Property(e => e.StyleNo).HasMaxLength(200);
            builder.Property(e => e.StyleName).HasMaxLength(200);
            builder.Property(e => e.Season).HasMaxLength(200);
            builder.Property(e => e.Buyer).HasMaxLength(200);
            builder.Property(e => e.FPONo).HasMaxLength(100);
            builder.Property(e => e.Location).HasMaxLength(200);
            builder.Property(e => e.UOM).HasMaxLength(50);
            builder.Property(e => e.OCNo).HasMaxLength(100);
            builder.Property(e => e.GRNNo).HasMaxLength(100);
            builder.Property(e => e.PONo).HasMaxLength(100);
            builder.Property(e => e.RequestedQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.QCReleasedQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.GRNQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.JobOrderNo).HasMaxLength(100);
            builder.Property(e => e.BatchNo).HasMaxLength(100);
            builder.Property(e => e.Line).HasMaxLength(200);
            builder.Property(e => e.Machine).HasMaxLength(200);
            builder.Property(e => e.PlannedQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MadeQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.BalanceQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WeightKg).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WidghtKg).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Length).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RollQty).HasColumnType("decimal(28,8)");
            builder.HasOne(s => s.QCRequest)
            .WithMany(g => g.QCRequestArticles)
            .HasForeignKey(s => s.QCRequestId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
