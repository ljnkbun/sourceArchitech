using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class MaterialTypeMapProductGroupConfiguration : BaseConfiguration<MaterialTypeMapProductGroup>
    {
        public override void Configure(EntityTypeBuilder<MaterialTypeMapProductGroup> builder)
        {
            base.Configure(builder);


            builder.HasOne(e => e.MaterialType)
                .WithMany(e => e.MaterialTypeMapProductGroups)
                .HasForeignKey(e => e.MaterialTypeId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            builder.HasOne(e => e.ProductGroup)
                .WithMany(e => e.MaterialTypeMapProductGroups)
                .HasForeignKey(e => e.ProductGroupId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
