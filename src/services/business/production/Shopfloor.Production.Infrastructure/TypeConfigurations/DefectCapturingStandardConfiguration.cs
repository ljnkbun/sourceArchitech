using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Infrastructure.TypeConfigurations
{
    public class DefectCapturingStandardConfiguration : BaseConfiguration<DefectCapturingStandard>
    {
        public override void Configure(EntityTypeBuilder<DefectCapturingStandard> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Remark).HasMaxLength(100);
            builder.Property(e => e.RootCauseIds).HasMaxLength(500);
            builder.Property(e => e.CorrectiveActionIds).HasMaxLength(500);
            builder.Property(e => e.PersonInChargeIds).HasMaxLength(500);

            builder.HasOne(s => s.ProductionOutput)
                .WithMany(g => g.DefectCapturingStandards)
                .HasForeignKey(s => s.ProductionOutputId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
