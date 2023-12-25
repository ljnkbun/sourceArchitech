using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Infrastructure.TypeConfigurations
{
    public class SupplierProductCategoryConfiguration : BaseConfiguration<SupplierProductCategory>
    {
        public override void Configure(EntityTypeBuilder<SupplierProductCategory> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Code).HasColumnType("varchar(200)");

            builder.Property(e => e.Name).HasMaxLength(500);

            builder.HasOne(s => s.Supplier)
                .WithMany(g => g.SupplierProductCategories)
                .HasForeignKey(s => s.SupplierId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}