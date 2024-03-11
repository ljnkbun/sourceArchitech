using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class WeavingOperationInputArticleConfiguration : BaseConfiguration<WeavingOperationInputArticle>
    {
        public override void Configure(EntityTypeBuilder<WeavingOperationInputArticle> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.WFXArticleId).IsRequired();
            builder.Property(e => e.ArticleCode).IsRequired().HasMaxLength(250);
            builder.Property(e => e.ArticleName).IsRequired().HasMaxLength(250);
            builder.HasOne(e => e.WeavingOperation)
                .WithMany(e => e.WeavingOperationInputArticles)
                .HasForeignKey(e => e.WeavingOperationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}