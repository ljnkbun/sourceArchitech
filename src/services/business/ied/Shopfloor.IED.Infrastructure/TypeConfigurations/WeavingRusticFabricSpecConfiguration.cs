using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class WeavingRusticFabricSpecConfiguration : BaseConfiguration<WeavingRusticFabricSpec>
    {
        public override void Configure(EntityTypeBuilder<WeavingRusticFabricSpec> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ContentWeaveStyle).IsRequired().HasMaxLength(50);
            builder.Property(e => e.MarginWeaveStyle).IsRequired().HasMaxLength(50);
            builder.Property(e => e.MachineType).IsRequired().HasMaxLength(250);
            builder.Property(e => e.HarnessFrameMWS).HasColumnType("decimal(28,8)");
            builder.Property(e => e.HarnessFrameCWS).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WeightGM).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WeightGM2).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WarpShrinkage).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WeftShrinkage).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RPM).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ReedCount).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ReedWidth).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WarpDensity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WeftDensity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.GreigeWidth).HasColumnType("decimal(28,8)");
            builder.Property(e => e.SettingWeftDensity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            builder.HasOne(e => e.WeavingIED)
                .WithOne(e => e.WeavingRusticFabricSpec)
                .HasForeignKey<WeavingRusticFabricSpec>(e => e.WeavingIEDId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
