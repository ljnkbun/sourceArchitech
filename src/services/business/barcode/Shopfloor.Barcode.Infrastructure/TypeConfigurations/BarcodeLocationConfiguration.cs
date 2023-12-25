using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Barcode.Infrastructure.TypeConfigurations
{
    public class BarcodeLocationConfiguration : BaseConfiguration<BarcodeLocation>
    {
        public override void Configure(EntityTypeBuilder<BarcodeLocation> builder)
        {
            base.Configure(builder);

            builder.HasOne(s => s.Location)
                .WithMany(g => g.BarcodeLocations)
                 .HasForeignKey(s => s.LocationId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.ArticleBarcode)
                .WithMany(g => g.BarcodeLocations)
                 .HasForeignKey(s => s.ArticleBarcodeId)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
