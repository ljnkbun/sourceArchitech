using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class SubCategoryConfiguration : BaseMasterConfiguration<SubCategory>
    {
        public override void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.ExciseTarrifNo).HasMaxLength(500);

            builder.HasOne(e => e.ProductGroup)
                .WithMany(e => e.SubCategories)
                .HasForeignKey(e => e.ProductGroupId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            builder.HasOne(e => e.SubCategoryGroup)
                .WithMany(e => e.SubCategories)
                .HasForeignKey(e => e.SubCategoryGroupId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
