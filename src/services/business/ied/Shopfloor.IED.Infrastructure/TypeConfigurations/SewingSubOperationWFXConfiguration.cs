using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingSubOperationWFXConfiguration : BaseConfiguration<SewingSubOperationWFX>
    {
        public override void Configure(EntityTypeBuilder<SewingSubOperationWFX> builder)
        {
            base.Configure(builder);
            
            builder.Property(e => e.WFXProcessCode).IsRequired().HasMaxLength(50);
            builder.Property(e => e.WFXProcessName).IsRequired().HasMaxLength(250);
            builder.Property(e => e.BundleTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ManualTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MachineTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.TotalSMV).HasColumnType("decimal(28,8)");
            builder.Property(e => e.NonMachineTime).HasColumnType("decimal(28,8)");
            builder.Property(e => e.LabourCost).HasColumnType("decimal(28,8)");
            builder.Property(e => e.QuatityPoints).HasMaxLength(250);
            builder.Property(e => e.QualityComments).HasMaxLength(500);
            builder.Property(e => e.Freq).HasMaxLength(50);
            builder.Property(e => e.Effort).HasColumnType("decimal(28,8)");
            builder.Property(e => e.AllowedTime).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");
        }
    }
}
