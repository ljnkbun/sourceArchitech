using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class RecipeConfiguration : BaseConfiguration<Recipe>
    {
        public override void Configure(EntityTypeBuilder<Recipe> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.RecipeNo).HasColumnType("varchar(100)");
            builder.Property(e => e.TCFNO).HasMaxLength(250);
            builder.Property(e => e.Style).HasMaxLength(250);
            builder.Property(e => e.FabricCode).HasMaxLength(250);
            builder.Property(e => e.FabricName).HasMaxLength(250);
            builder.Property(e => e.Color).HasMaxLength(250);
            builder.Property(e => e.LotNo).HasMaxLength(250);
            builder.Property(e => e.RollKg).HasMaxLength(250);
            builder.Property(e => e.Speed).HasMaxLength(250);
            builder.Property(e => e.NozzleA).HasMaxLength(250);
            builder.Property(e => e.NozzleB).HasMaxLength(250);
            builder.Property(e => e.Method).HasMaxLength(250);
            builder.Property(e => e.LAB).HasMaxLength(250);
            builder.Property(e => e.InCharge).HasMaxLength(250);
            builder.Property(e => e.Manager).HasMaxLength(250);
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.HasOne(s => s.DyeingTBRecipe)
                .WithOne(g => g.Recipe)
                .HasForeignKey<Recipe>(s => s.DyeingTBRecipeId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}