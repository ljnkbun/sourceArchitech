using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingOperationLibBOLConfiguration : BaseConfiguration<SewingOperationLibBOL>
    {
        public override void Configure(EntityTypeBuilder<SewingOperationLibBOL> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.Freq).HasColumnType("varchar(50)");
            builder.Property(e => e.ManualTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MachineTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.BundleTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.BundleTime).HasColumnType("decimal(28,8)");
            builder.Property(e => e.TotalTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Allowance).HasColumnType("decimal(28,8)");

            builder.HasOne(e => e.SewingOperationLib)
                .WithMany(e => e.SewingOperationLibBOLs)
                .HasForeignKey(e => e.SewingOperationLibId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.SewingTaskLib)
                .WithMany(e => e.SewingOperationLibBOLs)
                .HasForeignKey(e => e.SewingTaskLibId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
