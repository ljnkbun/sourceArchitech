using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class RecipeChemicalConfiguration : BaseConfiguration<RecipeChemical>
    {
        public override void Configure(EntityTypeBuilder<RecipeChemical> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ChemicalCode).HasColumnType("varchar(50)");
            builder.Property(e => e.ChemicalName).HasMaxLength(250);
            builder.Property(e => e.ChemicalSubcategory).HasMaxLength(250);
            builder.Property(e => e.Unit).HasMaxLength(250);
            builder.Property(e => e.Value).HasColumnType("decimal(28,8)");
            builder.HasOne(s => s.RecipeTask)
                .WithMany(g => g.RecipeChemicals)
                .HasForeignKey(s => s.RecipeTaskId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}