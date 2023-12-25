using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingFeatureLibBOLConfiguration : BaseConfiguration<SewingFeatureLibBOL>
    {
        public override void Configure(EntityTypeBuilder<SewingFeatureLibBOL> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Freq).HasColumnType("decimal(28,8)");
            builder.Property(e => e.SMV).HasColumnType("decimal(28,8)");
            builder.Property(e => e.AllowedTime).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RPM).HasColumnType("decimal(28,8)");

            builder.HasOne(e => e.SewingOperationLib)
                .WithMany(e => e.SewingFeatureLibBOLs)
                .HasForeignKey(e => e.SewingOperationLibId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.SewingFeatureLib)
                .WithMany(e => e.SewingFeatureLibBOLs)
                .HasForeignKey(e => e.SewingFeatureLibId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
