using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingMachineEfficiencyProfileConfiguration : BaseConfiguration<SewingMachineEfficiencyProfile>
    {
        public override void Configure(EntityTypeBuilder<SewingMachineEfficiencyProfile> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.MachineName).HasMaxLength(250);
        }
    }
}