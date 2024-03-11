using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class InspectionMesurementConfiguration : BaseConfiguration<InspectionMesurement>
    {
        public override void Configure(EntityTypeBuilder<InspectionMesurement> builder)
        {
            base.Configure(builder);
             builder.Property(e => e.Minor).HasColumnType("int");
			 builder.Property(e => e.Major).HasColumnType("int");
			 builder.Property(e => e.Critial).HasColumnType("int");
			 builder.Property(e => e.ProblemRootCauseId).HasColumnType("int");
			 builder.Property(e => e.ProblemCorrectiveActionId).HasColumnType("int");
			 builder.Property(e => e.ProblemTimelineId).HasColumnType("int");
			 builder.Property(e => e.PersonInChargeId).HasColumnType("int");
            builder.HasOne(s => s.Inspection)
            .WithMany(g => g.InspectionMesurements)
            .HasForeignKey(s => s.InspectionId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
