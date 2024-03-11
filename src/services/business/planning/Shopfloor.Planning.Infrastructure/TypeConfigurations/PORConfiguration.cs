using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class PORConfiguration : BaseConfiguration<POR>
    {
        public override void Configure(EntityTypeBuilder<POR> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.OCNo).HasMaxLength(250);
            builder.Property(e => e.PORNo).HasMaxLength(250);
            builder.Property(e => e.DivisionName).HasMaxLength(250);
            builder.Property(e => e.ArticleName).HasMaxLength(250);
            builder.Property(e => e.ArticleCode).HasMaxLength(250);
            builder.Property(e => e.Category).HasMaxLength(250);
            builder.Property(e => e.SubCategory).HasMaxLength(250);
            builder.Property(e => e.Buyer).HasMaxLength(250);
            builder.Property(e => e.ProductGroup).HasMaxLength(250);
            builder.Property(e => e.BOMNo).HasMaxLength(250);
            builder.Property(e => e.DeliveryDate).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
            builder.Property(e => e.OCStatus).HasDefaultValueSql("0");
            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RemainingQuantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ProcessName).HasMaxLength(250);
            builder.Property(e => e.Type).HasMaxLength(250);
            builder.Property(e => e.Status).HasColumnType("tinyint");
            builder.Property(e => e.OCStatus).HasColumnType("tinyint");
            builder.Property(e => e.TypePOR).HasColumnType("tinyint");
            builder.Property(e => e.UOM).HasMaxLength(250);
            builder.Property(e => e.JobOrderNo).HasMaxLength(250);
        }
    }
}
