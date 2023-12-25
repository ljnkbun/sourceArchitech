using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class CategoryMapMaterialTypeConfiguration : BaseConfiguration<CategoryMapMaterialType>
    {
        public override void Configure(EntityTypeBuilder<CategoryMapMaterialType> builder)
        {
            base.Configure(builder);

            builder.HasOne(e => e.Category)
                .WithMany(e => e.CategoryMapMaterialTypes)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            builder.HasOne(e => e.MaterialType)
                .WithMany(e => e.CategoryMapMaterialTypes)
                .HasForeignKey(e => e.MaterialTypeId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
