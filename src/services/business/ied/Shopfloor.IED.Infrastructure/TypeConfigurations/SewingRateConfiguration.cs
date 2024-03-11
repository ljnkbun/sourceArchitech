using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingRateConfiguration : BaseConfiguration<SewingRate>
    {
        public override void Configure(EntityTypeBuilder<SewingRate> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ExpectedQtyFrom).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ExpectedQtyTo).HasColumnType("decimal(28,8)");
            builder.Property(e => e.EfficiencyRate).HasColumnType("decimal(28,8)");
            builder.Property(e => e.CMRate).HasColumnType("decimal(28,9)");
        }
    }
}
