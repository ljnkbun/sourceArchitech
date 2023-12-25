using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class ArticleFlexFieldConfiguration : BaseConfiguration<ArticleFlexField>
    {
        public override void Configure(EntityTypeBuilder<ArticleFlexField> builder)
        {
            builder.Property(e => e.AttributeName).HasMaxLength(250);
            builder.Property(e => e.AttributeValue).HasMaxLength(500);
            builder.HasOne(e => e.Article)
                .WithMany(e => e.FlexFieldList)
                .HasForeignKey(e => e.ArticleId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
