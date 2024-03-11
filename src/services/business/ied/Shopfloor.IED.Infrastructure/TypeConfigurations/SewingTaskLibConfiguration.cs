using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingTaskLibConfiguration : BaseConfiguration<SewingTaskLib>
    {
        public override void Configure(EntityTypeBuilder<SewingTaskLib> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.MachineName).HasMaxLength(250);
            builder.Property(e => e.BundleTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MachineTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ManualTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.TotalTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.BundleTime).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");

            builder.HasOne(e => e.SewingMachineEfficiencyProfile)
               .WithMany(e => e.SewingTaskLibs)
               .HasForeignKey(e => e.SewingMachineEfficiencyProfileId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.SewingBundle)
               .WithMany(e => e.SewingTaskLibs)
               .HasForeignKey(e => e.SewingBundleId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
