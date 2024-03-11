using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class QCDefectTypeConfiguration : BaseMasterConfiguration<QCDefectType>
    {
        public override void Configure(EntityTypeBuilder<QCDefectType> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);

        }
    }
}
