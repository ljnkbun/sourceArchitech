using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class FormulaFieldConfiguration : BaseConfiguration<FormulaField>
    {
        public override void Configure(EntityTypeBuilder<FormulaField> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.FieldName).HasMaxLength(500);
            builder.Property(e => e.ProcessCode).HasMaxLength(200);
        }
    }
}
