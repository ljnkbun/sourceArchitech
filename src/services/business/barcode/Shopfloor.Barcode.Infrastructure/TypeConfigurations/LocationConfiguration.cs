using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Barcode.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Barcode.Infrastructure.TypeConfigurations
{
    public class LocationConfiguration : BaseMasterConfiguration<Location>
    {
        public override void Configure(EntityTypeBuilder<Location> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.Barcode).HasMaxLength(500);
            builder.Property(e => e.LevelLocation).HasColumnType("tinyint");
        }
    }
}
