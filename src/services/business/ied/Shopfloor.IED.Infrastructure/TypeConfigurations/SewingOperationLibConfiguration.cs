using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingOperationLibConfiguration : BaseMasterConfiguration<SewingOperationLib>
    {
        public override void Configure(EntityTypeBuilder<SewingOperationLib> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(500);
            builder.Property(e => e.SubCategoryCode).IsRequired().HasMaxLength(100);
            builder.Property(e => e.SubCategoryName).IsRequired().HasMaxLength(250);
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            builder.Property(e => e.ManualTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MachineTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.BundleTMU).HasColumnType("decimal(28,8)");
            builder.Property(e => e.PersonalAllowance).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MachineDelay).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Contingency).HasColumnType("decimal(28,8)");
            builder.Property(e => e.TotalSMV).HasColumnType("decimal(28,8)");
            builder.Property(e => e.NoneMachineTime).HasColumnType("decimal(28,8)");
            builder.Property(e => e.LabourCost).HasColumnType("decimal(28,8)");

            builder.HasOne(e => e.FolderTree)
                .WithMany(e => e.SewingOperationLibs)
                .HasForeignKey(e => e.FolderTreeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.SewingComponent)
                .WithMany(e => e.SewingOperationLibs)
                .HasForeignKey(e => e.SewingComponentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
