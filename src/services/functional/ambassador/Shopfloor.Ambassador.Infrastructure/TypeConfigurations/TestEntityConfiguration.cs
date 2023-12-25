using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Ambassador.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Ambassador.Infrastructure.TypeConfigurations
{
    public class TestEntityConfiguration : BaseConfiguration<TestEntity>
    {
        public override void Configure(EntityTypeBuilder<TestEntity> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Property01).HasMaxLength(500);
            builder.Property(e => e.Property02).HasMaxLength(500);
            builder.Property(e => e.Type).HasColumnType("tinyint");
        }
    }
}
