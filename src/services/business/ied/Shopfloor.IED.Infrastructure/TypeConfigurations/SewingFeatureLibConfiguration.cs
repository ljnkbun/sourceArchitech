using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingFeatureLibConfiguration : BaseMasterConfiguration<SewingFeatureLib>
    {
        public override void Configure(EntityTypeBuilder<SewingFeatureLib> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(500);
            builder.Property(e => e.BuyerCode).IsRequired().HasMaxLength(100);
            builder.Property(e => e.BuyerName).IsRequired().HasMaxLength(250);
            builder.Property(e => e.SubCategoryCode).IsRequired().HasMaxLength(100);
            builder.Property(e => e.SubCategoryName).IsRequired().HasMaxLength(250);
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            builder.Property(e => e.LabourCost).HasColumnType("decimal(28,8)");
            builder.Property(e => e.AllowedTime).HasColumnType("decimal(28,8)");
            builder.Property(e => e.TotalSMV).HasColumnType("decimal(28,8)");

            builder.HasOne(e => e.FolderTree)
                .WithMany(e => e.SewingFeatureLibs)
                .HasForeignKey(e => e.FolderTreeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.SewingComponent)
                .WithMany(e => e.SewingFeatureLibs)
                .HasForeignKey(e => e.SewingComponentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
