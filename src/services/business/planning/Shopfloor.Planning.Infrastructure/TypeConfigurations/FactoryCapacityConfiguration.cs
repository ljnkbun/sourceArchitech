using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Planning.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class FactoryCapacityConfiguration : BaseConfiguration<FactoryCapacity>
    {
        public override void Configure(EntityTypeBuilder<FactoryCapacity> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.FactoryId).HasColumnType("int");
            builder.Property(e => e.FactoryName).HasMaxLength(200);
            builder.Property(e => e.Standingcapacity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ActualCapacity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Percent).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ColorCode).HasMaxLength(200);
            builder.Property(e => e.Date).HasColumnType("datetime");
        }
    }
}
