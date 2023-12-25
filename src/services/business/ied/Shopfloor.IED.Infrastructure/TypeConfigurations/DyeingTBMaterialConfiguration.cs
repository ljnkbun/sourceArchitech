using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class DyeingTBMaterialConfiguration : BaseConfiguration<DyeingTBMaterial>
    {
        public override void Configure(EntityTypeBuilder<DyeingTBMaterial> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ArticleCode).HasColumnType("varchar(50)");
            builder.Property(e => e.ArticleId).HasMaxLength(250);
            builder.Property(e => e.ArticleName).HasMaxLength(500);
            builder.Property(e => e.MaterialType).HasMaxLength(250);
            builder.Property(e => e.FabricContent).HasMaxLength(500);
            builder.Property(e => e.Lights).HasMaxLength(500);
            builder.HasOne(s => s.DyeingTBRequest)
                .WithMany(g => g.DyeingTBMaterials)
                .HasForeignKey(s => s.DyeingTBRequestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}