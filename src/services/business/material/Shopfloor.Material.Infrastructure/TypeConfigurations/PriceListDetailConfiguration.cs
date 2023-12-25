using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Infrastructure.TypeConfigurations
{
    public class PriceListDetailConfiguration : BaseConfiguration<PriceListDetail>
    {
        public override void Configure(EntityTypeBuilder<PriceListDetail> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.MaterialCode).HasMaxLength(200);
            builder.Property(e => e.Uom).HasMaxLength(200);
            builder.Property(e => e.ArticleName).HasMaxLength(500);
            builder.Property(e => e.DeliveryTerm).HasMaxLength(200);
            builder.Property(e => e.Price).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Currency).HasMaxLength(200);
            builder.Property(e => e.DeliveryTerm).HasMaxLength(200);
            builder.HasOne(s => s.PriceList)
                .WithMany(g => g.PriceListDetails)
                .HasForeignKey(s => s.PriceListId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}