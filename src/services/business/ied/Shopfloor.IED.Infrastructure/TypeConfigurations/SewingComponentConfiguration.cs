using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingComponentConfiguration : BaseMasterConfiguration<SewingComponent>
    {
        public override void Configure(EntityTypeBuilder<SewingComponent> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(100);
            builder.Property(e => e.Name).HasMaxLength(250);
        }
    }
}
