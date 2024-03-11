using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class OrderEfficiencyConfiguration : BaseConfiguration<OrderEfficiency>
    {
        public override void Configure(EntityTypeBuilder<OrderEfficiency> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.OCNo).HasMaxLength(250);
            builder.Property(e => e.EfficiencyValue).HasColumnType("decimal(6,2)");
        }
    }
}
