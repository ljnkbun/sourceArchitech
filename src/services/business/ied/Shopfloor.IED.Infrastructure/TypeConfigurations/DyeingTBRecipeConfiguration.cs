using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class DyeingTBRecipeConfiguration : BaseConfiguration<DyeingTBRecipe>
    {
        public override void Configure(EntityTypeBuilder<DyeingTBRecipe> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.TBRecipeNo).HasMaxLength(50);
            builder.Property(e => e.TBRecipeName).HasMaxLength(500);
            builder.Property(e => e.TemplateName).HasMaxLength(250);
            builder.Property(e => e.TCFNo).HasMaxLength(250);
            builder.Property(e => e.Buyer).HasMaxLength(250);
            builder.Property(e => e.BuyerRef).HasMaxLength(250);
            builder.Property(e => e.GarmentStyleRef).HasMaxLength(250);
            builder.Property(e => e.Color).HasMaxLength(250);
            builder.Property(e => e.Concentration).HasMaxLength(250);
            builder.HasOne(s => s.DyeingTBMaterialColor)
                .WithOne(g => g.DyeingTBRecipe)
                .HasForeignKey<DyeingTBRecipe>(d => d.DyeingTBMaterialColorId);
        }
    }
}