using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class RecipeTaskConfiguration : BaseConfiguration<RecipeTask>
    {
        public override void Configure(EntityTypeBuilder<RecipeTask> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.DyeingOpreation).HasMaxLength(250);
            builder.Property(e => e.MachineType).HasMaxLength(250);
            builder.Property(e => e.Temperature).HasColumnType("decimal(28,8)");
            builder.HasOne(s => s.Recipe)
                .WithMany(g => g.RecipeTasks)
                .HasForeignKey(s => s.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}