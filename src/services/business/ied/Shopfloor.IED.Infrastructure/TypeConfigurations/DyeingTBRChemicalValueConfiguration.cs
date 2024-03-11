using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class DyeingTBRChemicalValueConfiguration : BaseConfiguration<DyeingTBRChemicalValue>
    {
        public override void Configure(EntityTypeBuilder<DyeingTBRChemicalValue> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Value).HasColumnType("decimal(28,8)");
            builder.HasOne(s => s.DyeingTbrChemical)
                .WithMany(g => g.DyeingTBRChemicalValues)
                .HasForeignKey(s => s.DyeingTBRChemicalId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}