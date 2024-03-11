using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class InspectionDefectError100PointSysConfiguration : BaseConfiguration<InspectionDefectError100PointSys>
    {
        public override void Configure(EntityTypeBuilder<InspectionDefectError100PointSys> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.InspectionDefectCapturing100PointSysId).HasColumnType("int");
            builder.Property(e => e.From).HasColumnType("decimal(28,8)");
            builder.Property(e => e.To).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ErrorType).HasColumnType("tinyint");
            builder.HasOne(s => s.InspectionDefectCapturing100PointSys)
              .WithMany(g => g.InspectionDefectError100PointSyss)
              .HasForeignKey(s => s.InspectionDefectCapturing100PointSysId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
