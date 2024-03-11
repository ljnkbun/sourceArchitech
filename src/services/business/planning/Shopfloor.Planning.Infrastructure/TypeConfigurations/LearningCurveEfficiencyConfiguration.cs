using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class LearningCurveEfficiencyConfiguration : BaseMasterConfiguration<LearningCurveEfficiency>
    {
        public override void Configure(EntityTypeBuilder<LearningCurveEfficiency> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.Description).HasMaxLength(200);
        }
    }
}
