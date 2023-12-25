using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class DyeingTBRVersionConfiguration : BaseConfiguration<DyeingTBRVersion>
    {
        public override void Configure(EntityTypeBuilder<DyeingTBRVersion> builder)
        {
            base.Configure(builder);
            builder.HasOne(s => s.DyeingTBRecipe)
                .WithMany(g => g.DyeingTBRVersions)
                .HasForeignKey(s => s.DyeingTBRecipeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}