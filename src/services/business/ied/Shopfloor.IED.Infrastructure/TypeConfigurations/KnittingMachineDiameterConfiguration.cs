using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class KnittingMachineDiameterConfiguration : BaseConfiguration<KnittingMachineDiameter>
    {
        public override void Configure(EntityTypeBuilder<KnittingMachineDiameter> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(500);
        }
    }
}
