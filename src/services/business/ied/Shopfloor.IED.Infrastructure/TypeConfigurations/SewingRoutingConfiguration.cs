using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingRoutingConfiguration : BaseConfiguration<SewingRouting>
    {
        public override void Configure(EntityTypeBuilder<SewingRouting> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.WFXProcessCode).HasMaxLength(50);
            builder.Property(e => e.WFXProcessName).HasMaxLength(250);
            builder.Property(e => e.WFXOperationCode).HasMaxLength(50);
            builder.Property(e => e.WFXOperationName).HasMaxLength(250);
            builder.Property(e => e.SMV).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");

            builder.HasOne(e => e.SewingIED)
                .WithMany(e => e.SewingRoutings)
                .HasForeignKey(e => e.SewingIEDId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
