using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class TestGroupConfiguration : BaseMasterConfiguration<TestGroup>
    {
        public override void Configure(EntityTypeBuilder<TestGroup> builder)
        {
            base.Configure(builder);
            
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.Buyer).HasMaxLength(500);
			builder.Property(e => e.Category).HasMaxLength(500);
			builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.GroupType).HasColumnType("tinyint");
            builder.Property(e => e.Mandatory).HasColumnType("bit");
        }
    }
}
