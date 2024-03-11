using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingComponentGroupConfiguration : BaseMasterConfiguration<SewingComponentGroup>
    {
        public override void Configure(EntityTypeBuilder<SewingComponentGroup> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(100);
            builder.Property(e => e.Name).HasMaxLength(250);
        }
    }
}
