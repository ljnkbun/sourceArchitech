using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class ArticleBaseColorConfiguration : BaseConfiguration<ArticleBaseColor>
    {
        public override void Configure(EntityTypeBuilder<ArticleBaseColor> builder)
        {
            builder.Property(e => e.ColorCode).HasMaxLength(50);
            builder.Property(e => e.ColorName).HasMaxLength(50);
            builder.HasOne(e => e.Article)
                .WithMany(e => e.BaseColorList)
                .HasForeignKey(e => e.ArticleId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
