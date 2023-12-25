using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.Article.Infrastructure.TypeConfigurations
{
    public class WeavingArticleConfiguration : BaseConfiguration<WeavingArticle>
    {
        public override void Configure(EntityTypeBuilder<WeavingArticle> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ArticleId).IsRequired();
            builder.Property(e => e.ArticleCode).IsRequired().HasMaxLength(100);
            builder.Property(e => e.ArticleName).IsRequired().HasMaxLength(250);
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");
        }
    }
}
