using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Infrastructure.TypeConfigurations
{
    public class ProductionOutputConfiguration : BaseConfiguration<ProductionOutput>
    {
        public override void Configure(EntityTypeBuilder<ProductionOutput> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.InputDate).HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(e => e.WFXExportDate).HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(e => e.Status).HasColumnType("tinyint");
            builder.Property(e => e.WFXExportStatus).HasColumnType("tinyint");
            builder.Property(e => e.Code).HasMaxLength(100);
            builder.Property(e => e.Remarks).HasMaxLength(100);
            builder.Property(e => e.Grade).HasMaxLength(100);
            builder.Property(e => e.Remark).HasMaxLength(100);
            builder.Property(e => e.StockMovementNo).HasMaxLength(100);


        }
    }
}
