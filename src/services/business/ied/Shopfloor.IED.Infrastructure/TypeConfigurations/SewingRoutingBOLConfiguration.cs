using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingRoutingBOLConfiguration : BaseConfiguration<SewingRoutingBOL>
    {
        public override void Configure(EntityTypeBuilder<SewingRoutingBOL> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.Freq).HasColumnType("varchar(50)");
            builder.Property(e => e.MachineTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ManualTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.BundleTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.TotalTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.SMV).HasColumnType("decimal(28,8)");
            builder.Property(e => e.TotalSMV).HasColumnType("decimal(28,8)");

            builder.HasOne(e => e.SewingOperationLib)
                .WithMany(e => e.SewingRoutingBOLs)
                .HasForeignKey(e => e.SewingOperationLibId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.SewingFeatureLib)
                .WithMany(e => e.SewingRoutingBOLs)
                .HasForeignKey(e => e.SewingFeatureLibId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.SewingRouting)
                .WithMany(e => e.SewingRoutingBOLs)
                .HasForeignKey(e => e.SewingRoutingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
