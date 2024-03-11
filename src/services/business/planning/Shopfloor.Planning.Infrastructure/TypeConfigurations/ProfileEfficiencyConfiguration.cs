using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class ProfileEfficiencyConfiguration : BaseMasterConfiguration<ProfileEfficiency>
    {
        public override void Configure(EntityTypeBuilder<ProfileEfficiency> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.CategoryCode).HasMaxLength(200);
            builder.Property(e => e.CategoryName).HasMaxLength(500);
            builder.Property(e => e.ProductGroupCode).HasMaxLength(200);
            builder.Property(e => e.ProductGroupName).HasMaxLength(500);
        }
    }
}
