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
            builder.Property(e => e.BackgroundType).IsRequired().HasMaxLength(50);
            builder.Property(e => e.BorderType).IsRequired().HasMaxLength(50);
            builder.Property(e => e.MachineType).IsRequired().HasMaxLength(250);
            builder.Property(e => e.BackgroundLoomFrame).HasColumnType("decimal(28,8)");
            builder.Property(e => e.BackgroundLoomFrame).HasColumnType("decimal(28,8)");
            builder.Property(e => e.BorderLoomFrame).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WeightGM).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WeightGM2).HasColumnType("decimal(28,8)");
            builder.Property(e => e.VerticalShrinkage).HasColumnType("decimal(28,8)");
            builder.Property(e => e.HorizontalShrinkage).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RPM).HasColumnType("decimal(28,8)");
            builder.Property(e => e.CombNum).HasColumnType("decimal(28,8)");
            builder.Property(e => e.CombSize).HasColumnType("decimal(28,8)");
            builder.Property(e => e.VerticalDensity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.HorizontalDensity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RusticSize).HasColumnType("decimal(28,8)");
            builder.Property(e => e.HorizontalDensitySetting).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            builder.HasOne(e => e.WeavingArticle)
                .WithMany(e => e.WeavingRusticFabricSpecs)
                .HasForeignKey(e => e.WeavingArticleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
