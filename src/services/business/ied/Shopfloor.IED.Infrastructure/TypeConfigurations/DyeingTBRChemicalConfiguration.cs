using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class DyeingTBRChemicalConfiguration : BaseConfiguration<DyeingTBRChemical>
    {
        public override void Configure(EntityTypeBuilder<DyeingTBRChemical> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Unit).HasColumnType("varchar(50)");
            builder.Property(e => e.ChemicalName).HasMaxLength(500);
            builder.Property(e => e.ChemicalCode).HasColumnType("varchar(20)");
            builder.HasOne(s => s.DyeingTBRTask)
                .WithMany(g => g.DyeingTBTaskChemicals)
                .HasForeignKey(s => s.DyeingTBRTaskId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}