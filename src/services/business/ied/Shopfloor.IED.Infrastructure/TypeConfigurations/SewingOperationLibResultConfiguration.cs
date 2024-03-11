using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingOperationLibResultConfiguration : BaseConfiguration<SewingOperationLibResult>
    {
        public override void Configure(EntityTypeBuilder<SewingOperationLibResult> builder)
        {
            base.Configure(builder);
            builder.HasIndex(e => new { e.SewingOperationLibId, e.Type }).IsUnique();
            builder.Property(e => e.TMU).IsRequired().HasColumnType("decimal(28,8)");
            builder.Property(e => e.BasicMinute).IsRequired().HasColumnType("decimal(28,8)");
            builder.Property(e => e.PersonalAllowance).IsRequired().HasColumnType("decimal(28,8)");
            builder.Property(e => e.MachineDelay).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Total).IsRequired().HasColumnType("decimal(28,8)");
            builder.Property(e => e.Contingency).IsRequired().HasColumnType("decimal(28,8)");
            builder.Property(e => e.SMV).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Cost).HasColumnType("decimal(28,8)");

            builder.HasOne(e => e.SewingOperationLib)
                .WithMany(e => e.SewingOperationLibResults)
                .HasForeignKey(e => e.SewingOperationLibId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
