using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class LiquorRatioConfiguration : BaseConfiguration<LiquorRatio>
    {
        public override void Configure(EntityTypeBuilder<LiquorRatio> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Value).HasColumnType("decimal(28,8)");
        }
    }
}
