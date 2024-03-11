using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;


namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class CriticalPartConfiguration : BaseConfiguration<CriticalPart>
    {
        public override void Configure(EntityTypeBuilder<CriticalPart> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Color).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(250);
        }
    }
}
