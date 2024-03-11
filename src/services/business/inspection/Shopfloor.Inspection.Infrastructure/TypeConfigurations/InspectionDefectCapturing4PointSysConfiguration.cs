using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class InspectionDefectCapturing4PointSysConfiguration : BaseConfiguration<InspectionDefectCapturing4PointSys>
    {
        public override void Configure(EntityTypeBuilder<InspectionDefectCapturing4PointSys> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Inpection4PointSysId).HasColumnType("int");
            builder.Property(e => e.QCDefectId).HasColumnType("int");
            builder.Property(e => e.DefectQtyOne).HasColumnType("int");
            builder.Property(e => e.DefectQtyTwo).HasColumnType("int");
            builder.Property(e => e.DefectQtyThree).HasColumnType("int");
            builder.Property(e => e.DefectQtyFour).HasColumnType("int");
            builder.Property(e => e.MinorOne).HasColumnType("int");
            builder.Property(e => e.MinorTwo).HasColumnType("int");
            builder.Property(e => e.MinorThree).HasColumnType("int");
            builder.Property(e => e.MinorFour).HasColumnType("int");
            builder.Property(e => e.MajorOne).HasColumnType("int");
            builder.Property(e => e.MajorTwo).HasColumnType("int");
            builder.Property(e => e.MajorThree).HasColumnType("int");
            builder.Property(e => e.MajorFour).HasColumnType("int");
            builder.Property(e => e.ProblemRootCauseId).HasColumnType("int");
            builder.Property(e => e.ProblemCorrectiveActionId).HasColumnType("int");
            builder.Property(e => e.ProblemTimelineId).HasColumnType("int");
            builder.Property(e => e.PersonInChargeId).HasColumnType("int");
            builder.Property(e => e.AttachmentId).HasColumnType("int");
            builder.Property(e => e.Remark).HasMaxLength(500);
            builder.HasOne(s => s.Inpection4PointSys)
            .WithMany(g => g.InspectionDefectCapturing4PointSyss)
            .HasForeignKey(s => s.Inpection4PointSysId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
