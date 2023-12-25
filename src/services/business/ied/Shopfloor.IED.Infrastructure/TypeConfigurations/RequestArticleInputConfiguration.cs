using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class RequestArticleInputConfiguration : BaseConfiguration<RequestArticleInput>
    {
        public override void Configure(EntityTypeBuilder<RequestArticleInput> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ArticleCode).IsRequired().HasMaxLength(200);
            builder.Property(e => e.ArticleName).IsRequired().HasMaxLength(500);

            builder.HasOne(e => e.RequestArticleOutput)
                .WithMany(e => e.RequestArticleInputs)
                .HasForeignKey(e => e.RequestArticleOutputId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
