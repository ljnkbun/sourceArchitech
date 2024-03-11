using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class DyeingIEDConfiguration : BaseConfiguration<DyeingIED>
    {
        public override void Configure(EntityTypeBuilder<DyeingIED> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.RequestNo).HasColumnType("varchar(50)");

            builder.Property(e => e.ArticleCode).HasMaxLength(100);

            builder.Property(e => e.ArticleName).HasMaxLength(250);

            builder.Property(e => e.ProductGroup).HasMaxLength(250);

            builder.Property(e => e.SubCategory).HasMaxLength(250);

            builder.Property(e => e.Buyer).HasMaxLength(250);

            builder.Property(e => e.Color).HasMaxLength(250);

            builder.Property(e => e.ColorRef).HasMaxLength(250);
            builder.Property(e => e.AnalysisUser).HasMaxLength(100);
            builder.Property(e => e.TCFNo).HasMaxLength(250);
            builder.Property(e => e.InputMaterialName).HasMaxLength(250);

            builder.HasOne(s => s.RequestArticleOutput)
                .WithOne(g => g.DyeingIED)
                .HasForeignKey<DyeingIED>(s => s.RequestArticleOutputId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Recipe)
                .WithMany(g => g.DyeingIEDs)
                .HasForeignKey(s => s.RecipeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.RequestType)
                .WithMany(g => g.DyeingIEDs)
                .HasForeignKey(s => s.RequestTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}