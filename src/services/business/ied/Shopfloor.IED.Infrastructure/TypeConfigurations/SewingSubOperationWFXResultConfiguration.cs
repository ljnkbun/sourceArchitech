using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingSubOperationWFXReaultConfiguration : BaseConfiguration<SewingSubOperationWFXResult>
    {
        public override void Configure(EntityTypeBuilder<SewingSubOperationWFXResult> builder)
        {
            base.Configure(builder);
            builder.HasIndex(e => new { e.SewingSubOperationWFXId, e.TMUType }).IsUnique();
            builder.Property(e => e.TMU).IsRequired().HasColumnType("decimal(28,8)");
            builder.Property(e => e.BasicMunite).IsRequired().HasColumnType("decimal(28,8)");
            builder.Property(e => e.PersonalAllowance).IsRequired().HasColumnType("decimal(28,8)");
            builder.Property(e => e.MachineDelay).IsRequired().HasColumnType("decimal(28,8)");
            builder.Property(e => e.Total).IsRequired().HasColumnType("decimal(28,8)");
            builder.Property(e => e.Contingency).IsRequired().HasColumnType("decimal(28,8)");
            builder.Property(e => e.SMV).IsRequired().HasColumnType("decimal(28,8)");
            builder.Property(e => e.Cost).IsRequired().HasColumnType("decimal(28,8)");
        }
    }
}
