using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Barcode.Infrastructure.TypeConfigurations
{
    public class WfxPOArticleHistoryConfiguration : BaseConfiguration<WfxPOArticleHistory>
    {
        public override void Configure(EntityTypeBuilder<WfxPOArticleHistory> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RemainQuantity).HasColumnType("decimal(28,8)");


            builder.HasOne(s => s.ImportDetail)
              .WithMany(g => g.WfxPOArticleHistories)
              .HasForeignKey(s => s.ImportDetailId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.WfxPOArticle)
              .WithMany(g => g.WfxPOArticleHistories)
              .HasForeignKey(s => s.WfxPOArticlelId)
              .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
