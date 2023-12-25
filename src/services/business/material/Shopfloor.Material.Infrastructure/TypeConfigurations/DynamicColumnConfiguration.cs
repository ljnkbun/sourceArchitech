using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Infrastructure.TypeConfigurations
{
    public class DynamicColumnConfiguration : BaseConfiguration<DynamicColumn>
    {
        public override void Configure(EntityTypeBuilder<DynamicColumn> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasColumnType("varchar(200)");
            builder.Property(e => e.CategoryCode).HasColumnType("varchar(200)");
            builder.Property(e => e.Name).HasMaxLength(500);
        }
    }
}