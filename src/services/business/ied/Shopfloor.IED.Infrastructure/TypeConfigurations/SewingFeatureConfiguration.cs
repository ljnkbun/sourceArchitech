using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingFeatureConfiguration : BaseConfiguration<SewingFeature>
    {
        public override void Configure(EntityTypeBuilder<SewingFeature> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            builder.Property(e => e.LabourCost).HasColumnType("decimal(28,8)");
            builder.Property(e => e.AllowedTime).HasColumnType("decimal(28,8)");
            builder.Property(e => e.TotalSMV).HasColumnType("decimal(28,8)");
        }
    }
}
