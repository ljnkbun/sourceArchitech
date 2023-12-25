using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class FabricWidthConfiguration : BaseMasterConfiguration<FabricWidth>
    {
        public override void Configure(EntityTypeBuilder<FabricWidth> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.SortOrder);
            builder.Property(e => e.Inseam).HasMaxLength(200);
        }
    }
}
