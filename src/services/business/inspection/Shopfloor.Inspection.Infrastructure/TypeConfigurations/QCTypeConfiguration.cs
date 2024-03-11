using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class QCTypeConfiguration : BaseMasterConfiguration<QCType>
    {
        public override void Configure(EntityTypeBuilder<QCType> builder)
        {
            base.Configure(builder);
            
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.QCScreenType).HasColumnType("tinyint");
     
        }
    }
}
