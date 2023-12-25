using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class UOMConfiguration : BaseMasterConfiguration<UOM>
    {
        public override void Configure(EntityTypeBuilder<UOM> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.Action).HasMaxLength(500);
        }
    }
}
