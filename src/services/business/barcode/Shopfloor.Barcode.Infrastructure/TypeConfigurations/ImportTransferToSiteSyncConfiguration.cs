using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Barcode.Infrastructure.TypeConfigurations
{
    public class ImportTransferToSiteSyncConfiguration : BaseConfiguration<ImportTransferToSiteSync>
    {
        public override void Configure(EntityTypeBuilder<ImportTransferToSiteSync> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ArticleCode).HasMaxLength(50);
            builder.Property(e => e.ArticleName).HasMaxLength(250);
            builder.Property(e => e.GDNNo).HasMaxLength(50);
            builder.Property(e => e.FromSite).HasMaxLength(100);
            builder.Property(e => e.ToSite).HasMaxLength(100);
            builder.Property(e => e.Color).HasMaxLength(50);
            builder.Property(e => e.Size).HasMaxLength(50);
            builder.Property(e => e.UOM).HasMaxLength(50);
            builder.Property(e => e.StoringUOM).HasMaxLength(50);
            builder.Property(e => e.OC).HasMaxLength(50);
            builder.Property(e => e.LotNo).HasMaxLength(50);
            builder.Property(e => e.Qty).HasColumnType("decimal(28,8)");
        }
    }
}
