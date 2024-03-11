using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class InspectionDefectCapturingTCStandardConfiguration : BaseConfiguration<InspectionDefectCapturingTCStandard>
    {
        public override void Configure(EntityTypeBuilder<InspectionDefectCapturingTCStandard> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.InpectionTCStandardId).HasColumnType("int");
            builder.Property(e => e.QCDefectId).HasColumnType("int");
            builder.Property(e => e.Defect).HasColumnType("int");
            builder.Property(e => e.AttachmentId).HasColumnType("int");
            builder.Property(e => e.Remark).HasMaxLength(500);
            builder.Property(e => e.ProblemRootCauseId).HasColumnType("int");
            builder.Property(e => e.ProblemCorrectiveActionId).HasColumnType("int");
            builder.Property(e => e.ProblemTimelineId).HasColumnType("int");
            builder.Property(e => e.PersonInChargeId).HasColumnType("int");
            builder.HasOne(s => s.InpectionTCStandard)
            .WithMany(g => g.InspectionDefectCapturingTCStandards)
            .HasForeignKey(s => s.InpectionTCStandardId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
