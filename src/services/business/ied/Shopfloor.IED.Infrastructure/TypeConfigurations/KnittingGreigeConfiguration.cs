using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class KnittingGreigeConfiguration : BaseConfiguration<KnittingGreige>
    {
        public override void Configure(EntityTypeBuilder<KnittingGreige> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Width).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WidthLossRate).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WeightGM).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WeightGMLossRate).HasColumnType("decimal(28,8)");
            builder.Property(e => e.VerticalDensity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.VerticalDensityLossRate).HasColumnType("decimal(28,8)");
            builder.Property(e => e.HorizontalDensity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.HorizontalDensityLossRate).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WrapShrinkage).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WeftShrinkage).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Feeder).HasColumnType("decimal(28,8)");
            builder.Property(e => e.UsedFeeder).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Needle).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RappoLength).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MachineDiameter).HasColumnType("decimal(28,8)");
            builder.Property(e => e.WeightKg).HasColumnType("decimal(28,8)");

            builder.HasOne(e => e.KnittingIED)
               .WithMany(e => e.KnittingGreiges)
               .HasForeignKey(e => e.KnittingIEDId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.KnittingBodyType)
               .WithMany(e => e.KnittingGreiges)
               .HasForeignKey(e => e.KnittingBodyTypeId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.KnittingType)
               .WithMany(e => e.KnittingGreiges)
               .HasForeignKey(e => e.KnittingTypeId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.KnittingShrinkage)
               .WithMany(e => e.KnittingGreiges)
               .HasForeignKey(e => e.KnittingShrinkageId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
