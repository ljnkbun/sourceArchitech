using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class ProductGroupUOMConfiguration : BaseConfiguration<ProductGroupUOM>
    {
        public override void Configure(EntityTypeBuilder<ProductGroupUOM> builder)
        {
            base.Configure(builder);

            builder.HasOne(e => e.ProductGroup)
                .WithMany(e => e.ProductGroupUOMs)
                .HasForeignKey(e => e.ProductGroupId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            builder.HasOne(e => e.UOM)
                .WithMany(e => e.ProductGroupUOMs)
                .HasForeignKey(e => e.UOMId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}