using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class LearningCurveDetailEfficiencyConfiguration : BaseMasterConfiguration<LearningCurveDetailEfficiency>
    {
        public override void Configure(EntityTypeBuilder<LearningCurveDetailEfficiency> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.EfficiencyValue).HasColumnType("decimal(28,8)");

            builder.HasOne(e => e.LearningCurveEfficiency)
                    .WithMany(e => e.LearningCurveDetailEfficiencies)
                    .HasForeignKey(e => e.LearningCurveEfficiencyId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
