using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class FourPointsSystemConfiguration : BaseMasterConfiguration<FourPointsSystem>
    {
        public override void Configure(EntityTypeBuilder<FourPointsSystem> builder)
        {
            base.Configure(builder);
            
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.ProductGroup).HasMaxLength(100);

        }
    }
}
