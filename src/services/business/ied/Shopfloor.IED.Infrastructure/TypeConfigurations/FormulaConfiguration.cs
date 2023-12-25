using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class FormulaConfiguration : BaseMasterConfiguration<Formula>
    {
        public override void Configure(EntityTypeBuilder<Formula> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.Expression).HasMaxLength(500);
            builder.Property(e => e.ProcessCode).HasMaxLength(200);
        }
    }
}
