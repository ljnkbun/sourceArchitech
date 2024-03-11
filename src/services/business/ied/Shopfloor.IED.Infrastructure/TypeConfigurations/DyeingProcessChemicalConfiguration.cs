using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class DyeingProcessChemicalConfiguration : BaseConfiguration<DyeingProcessChemical>
    {
        public override void Configure(EntityTypeBuilder<DyeingProcessChemical> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ChemicalCode).HasMaxLength(250);

            builder.Property(e => e.ChemicalName).HasMaxLength(250);

            builder.Property(e => e.SubCategoryCode).HasMaxLength(100);

            builder.Property(e => e.SubCategoryName).HasMaxLength(250);

            builder.Property(e => e.Unit).HasMaxLength(250);

            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");
        }
    }
}