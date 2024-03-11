using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingMacroLibConfiguration : BaseConfiguration<SewingMacroLib>
    {
        public override void Configure(EntityTypeBuilder<SewingMacroLib> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            builder.Property(e => e.ManualTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MachineTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.BundleTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.TotalBasicMinutes).HasColumnType("decimal(28,8)");
            builder.Property(e => e.NoneMachineTime).HasColumnType("decimal(28,8)");

            builder.HasOne(e => e.FolderTree)
                .WithMany(e => e.SewingMacroLibs)
                .HasForeignKey(e => e.FolderTreeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(e => e.SewingComponentGroup)
                .WithMany(e => e.SewingMacroLibs)
                .HasForeignKey(e => e.SewingComponentGroupId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
