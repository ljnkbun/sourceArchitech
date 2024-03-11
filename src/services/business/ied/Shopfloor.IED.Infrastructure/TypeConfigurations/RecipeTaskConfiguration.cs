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

            builder.Property(e => e.DyeingOperationName).HasMaxLength(250);
            builder.Property(e => e.DyeingProcessName).HasMaxLength(250);
            builder.Property(e => e.MachineName).HasMaxLength(250);
            builder.Property(e => e.MachineCode).HasColumnType("varchar(100)");
            builder.Property(e => e.DyeingOperationCode).HasColumnType("varchar(100)");
            builder.Property(e => e.DyeingProcessCode).HasColumnType("varchar(100)");
            builder.Property(e => e.Time).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Temperature).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Ratio).HasDefaultValue(0).HasColumnType("decimal(28,8)");
            builder.HasOne(s => s.Recipe)
                .WithMany(g => g.RecipeTasks)
                .HasForeignKey(s => s.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}