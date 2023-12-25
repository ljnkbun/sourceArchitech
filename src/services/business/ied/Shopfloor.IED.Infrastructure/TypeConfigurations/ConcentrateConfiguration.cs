using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class ConcentrateConfiguration : BaseMasterConfiguration<Concentrate>
    {
        public override void Configure(EntityTypeBuilder<Concentrate> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
        }
    }
}
