using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class ArticleBaseSizeConfiguration : BaseConfiguration<ArticleBaseSize>
    {
        public override void Configure(EntityTypeBuilder<ArticleBaseSize> builder)
        {
            builder.Property(e => e.SizeCode).HasMaxLength(50);
            builder.Property(e => e.SizeName).HasMaxLength(50);
            builder.HasOne(e => e.Article)
                .WithMany(e => e.BaseSizeList)
                .HasForeignKey(e => e.ArticleId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
