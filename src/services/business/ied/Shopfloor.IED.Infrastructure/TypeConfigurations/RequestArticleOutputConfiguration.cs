using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class RequestArticleOutputConfiguration : BaseConfiguration<RequestArticleOutput>
    {
        public override void Configure(EntityTypeBuilder<RequestArticleOutput> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ArticleCode).IsRequired().HasMaxLength(200);
            builder.Property(e => e.ArticleName).IsRequired().HasMaxLength(500);
            builder.Property(e => e.Color).IsRequired().HasMaxLength(200);
            builder.Property(e => e.BaseColorList).IsRequired().HasMaxLength(2000);

            builder.HasOne(e => e.RequestDivisionProcess)
                .WithMany(e => e.RequestArticleOutputs)
                .HasForeignKey(e => e.RequestDivisionProcessId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
