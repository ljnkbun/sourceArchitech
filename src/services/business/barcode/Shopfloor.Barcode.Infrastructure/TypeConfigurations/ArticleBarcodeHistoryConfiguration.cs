using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Barcode.Infrastructure.TypeConfigurations
{
    public class ArticleBarcodeHistoryConfiguration : BaseConfiguration<ArticleBarcodeHistory>
    {
        public override void Configure(EntityTypeBuilder<ArticleBarcodeHistory> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.FromId).HasColumnType("int");
            builder.Property(e => e.ToId).HasColumnType("int");
            builder.Property(e => e.MergeSplitType).HasColumnType("tinyint");
        }
    }
}
