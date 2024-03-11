using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingBundleConfiguration : BaseConfiguration<SewingBundle>
    {
        public override void Configure(EntityTypeBuilder<SewingBundle> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasColumnType("varchar(100)");
            builder.Property(e => e.Name).HasMaxLength(250);
            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");
        }
    }
}