using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class FourPointsSystemDetailConfiguration : BaseConfiguration<FourPointsSystemDetail>
    {
        public override void Configure(EntityTypeBuilder<FourPointsSystemDetail> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.From).HasColumnType("decimal(28,8)");
            builder.Property(e => e.To).HasColumnType("decimal(28,8)");
            builder.Property(e => e.GradeType).HasColumnType("tinyint");
           
        }
    }
}
