using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class CapacityColorConfiguration : BaseConfiguration<CapacityColor>
    {
        public override void Configure(EntityTypeBuilder<CapacityColor> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Color).HasMaxLength(200);
            builder.Property(e => e.FromRange).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ToRange).HasColumnType("decimal(28,8)");
        }
    }
}
