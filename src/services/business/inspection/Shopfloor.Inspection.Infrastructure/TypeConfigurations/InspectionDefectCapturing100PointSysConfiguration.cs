using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class InspectionDefectCapturing100PointSysConfiguration : BaseConfiguration<InspectionDefectCapturing100PointSys>
    {
        public override void Configure(EntityTypeBuilder<InspectionDefectCapturing100PointSys> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Inpection100PointSysId).HasColumnType("int");
            builder.Property(e => e.QCDefectId).HasColumnType("int");
            builder.Property(e => e.Minor).HasColumnType("int");
            builder.Property(e => e.Major).HasColumnType("int");
            builder.Property(e => e.Critial).HasColumnType("int");
            builder.Property(e => e.AttachmentId).HasColumnType("int");
            builder.Property(e => e.ProblemRootCauseId).HasColumnType("int");
            builder.Property(e => e.ProblemCorrectiveActionId).HasColumnType("int");
            builder.Property(e => e.ProblemTimelineId).HasColumnType("int");
            builder.Property(e => e.PersonInChargeId).HasColumnType("int");
            builder.Property(e => e.Remark).HasMaxLength(500);
            builder.HasOne(s => s.Inpection100PointSys)
           .WithMany(g => g.InspectionDefectCapturing100PointSyss)
           .HasForeignKey(s => s.Inpection100PointSysId)
           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
