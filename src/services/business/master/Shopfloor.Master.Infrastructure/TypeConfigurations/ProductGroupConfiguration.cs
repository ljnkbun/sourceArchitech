using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class ProductGroupConfiguration : BaseMasterConfiguration<ProductGroup>
    {
        public override void Configure(EntityTypeBuilder<ProductGroup> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);

            builder.HasOne(e => e.Category)
                .WithMany(e => e.ProductGroups)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
