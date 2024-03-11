using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class KnittingIEDConfiguration : BaseConfiguration<KnittingIED>
    {
        public override void Configure(EntityTypeBuilder<KnittingIED> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.RequestNo).HasColumnType("varchar(50)");
            builder.Property(e => e.ArticleCode).HasMaxLength(250);
            builder.Property(e => e.ArticleName).HasMaxLength(250);
            builder.Property(e => e.ProductGroup).HasMaxLength(250);
            builder.Property(e => e.SubCategory).HasMaxLength(250);
            builder.Property(e => e.Buyer).HasMaxLength(250);
            builder.Property(e => e.AnalysisUser).HasMaxLength(100);
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            builder.HasOne(e => e.RequestArticleOutput)
               .WithOne(e => e.KnittingIED)
               .HasForeignKey<KnittingIED>(e => e.RequestArticleOutputId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
