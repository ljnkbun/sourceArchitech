using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Infrastructure.TypeConfigurations
{
    public class PriceListDetailSizeConfiguration : BaseConfiguration<PriceListDetailSize>
    {
        public override void Configure(EntityTypeBuilder<PriceListDetailSize> builder)
        {
            base.Configure(builder);

            builder.HasOne(s => s.PriceListDetail)
                .WithMany(g => g.PriceListDetailSizes)
                .HasForeignKey(s => s.PriceListDetailId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
        }
    }
}