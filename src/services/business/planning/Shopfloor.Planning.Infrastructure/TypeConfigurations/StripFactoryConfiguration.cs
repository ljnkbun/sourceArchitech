using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class StripFactoryConfiguration : BaseConfiguration<StripFactory>
    {
        public override void Configure(EntityTypeBuilder<StripFactory> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.PlanningGroupFactoryId).HasColumnType("int");
            builder.Property(e => e.PORId).HasColumnType("int");
            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.StartDate).HasColumnType("datetime");
            builder.Property(e => e.EndDate).HasColumnType("datetime");
            builder.Property(e => e.IsAllocated).HasColumnType("bit");
        }
    }
}
