using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class AutoIncrementMappingConfiguration : BaseConfiguration<AutoIncrement>
    {
        public override void Configure(EntityTypeBuilder<AutoIncrement> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Separate).HasColumnType("varchar(10)");
            builder.Property(e => e.IndexFormat).HasColumnType("varchar(10)");
            builder.Property(e => e.InputValue).HasColumnType("varchar(100)");
        }
    }
}