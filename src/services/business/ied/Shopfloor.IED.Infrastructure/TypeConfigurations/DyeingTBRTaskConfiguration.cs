using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class DyeingTBRTaskConfiguration : BaseConfiguration<DyeingTBRTask>
    {
        public override void Configure(EntityTypeBuilder<DyeingTBRTask> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.DyeingOperationName).HasMaxLength(200);
            builder.Property(e => e.DyeingProcessName).HasMaxLength(200);
            builder.Property(e => e.MachineCode).HasColumnType("varchar(50)");
            builder.Property(e => e.MachineName).HasMaxLength(200);
            builder.Property(e => e.Temperature).HasColumnType("decimal(28,8)");
            builder.HasOne(s => s.DyeingTBRecipe)
                .WithMany(g => g.DyeingTBRTasks)
                .HasForeignKey(s => s.DyeingTBRecipeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}