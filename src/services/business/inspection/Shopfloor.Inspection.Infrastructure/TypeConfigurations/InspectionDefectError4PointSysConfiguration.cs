using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class InspectionDefectError4PointSysConfiguration : BaseConfiguration<InspectionDefectError4PointSys>
    {
        public override void Configure(EntityTypeBuilder<InspectionDefectError4PointSys> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.InspectionDefectCapturing4PointSysId).HasColumnType("int");
            builder.Property(e => e.From).HasColumnType("decimal(28,8)");
            builder.Property(e => e.To).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ErrorType).HasColumnType("tinyint");
            builder.HasOne(s => s.InspectionDefectCapturing4PointSys)
              .WithMany(g => g.InspectionDefectError4PointSyss)
              .HasForeignKey(s => s.InspectionDefectCapturing4PointSysId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
