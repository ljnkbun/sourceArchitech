using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class DyeingTBMaterialColorConfiguration : BaseConfiguration<DyeingTBMaterialColor>
    {
        public override void Configure(EntityTypeBuilder<DyeingTBMaterialColor> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Color).HasMaxLength(250);
            builder.Property(e => e.Pantone).HasMaxLength(500);
            builder.HasOne(s => s.DyeingTBMaterial)
                .WithMany(g => g.DyeingTBMaterialColors)
                .HasForeignKey(s => s.DyeingTBMaterialId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}