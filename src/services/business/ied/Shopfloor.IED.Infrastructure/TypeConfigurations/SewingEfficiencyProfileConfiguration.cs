using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingEfficiencyProfileConfiguration : BaseConfiguration<SewingEfficiencyProfile>
    {
        public override void Configure(EntityTypeBuilder<SewingEfficiencyProfile> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name).HasMaxLength(250);
            builder.Property(e => e.PersonalAllowance).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MachineDelay).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Contingency).HasColumnType("decimal(28,8)");
        }
    }
}