using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Infrastructure.TypeConfigurations
{
    public class PriceListDetailColorConfiguration : BaseConfiguration<PriceListDetailColor>
    {
        public override void Configure(EntityTypeBuilder<PriceListDetailColor> builder)
        {
            base.Configure(builder);

            builder.HasOne(s => s.PriceListDetail)
                .WithMany(g => g.PriceListDetailColors)
                .HasForeignKey(s => s.PriceListDetailId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
        }
    }
}