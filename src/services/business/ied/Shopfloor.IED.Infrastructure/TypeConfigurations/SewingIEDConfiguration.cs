using MathNet.Numerics.Distributions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingIEDConfiguration : BaseConfiguration<SewingIED>
    {
        public override void Configure(EntityTypeBuilder<SewingIED> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.RequestNo).HasColumnType("varchar(50)");
            builder.Property(e => e.Buyer).HasMaxLength(250);
            builder.Property(e => e.StyleRef).HasMaxLength(250);
            builder.Property(e => e.ProductGroup).HasMaxLength(250);
            builder.Property(e => e.SubCategory).HasMaxLength(250);
            builder.Property(e => e.ArticleCode).HasMaxLength(200);
            builder.Property(e => e.ArticleName).HasMaxLength(500);
            builder.Property(e => e.SMV).HasColumnType("decimal(28,8)");
            builder.Property(e => e.AllowedTime).HasColumnType("decimal(28,8)");
            builder.Property(e => e.FactoryTime).HasColumnType("decimal(28,8)");
            builder.Property(e => e.LabourCostOp).HasColumnType("decimal(28,8)");
            builder.Property(e => e.LabourCostFactory).HasColumnType("decimal(28,8)");
            builder.Property(e => e.FactoryOverheadAgainstLabourPercent).HasColumnType("decimal(28,8)");
            builder.Property(e => e.LabourCostFactoryIncludingOverhead).HasColumnType("decimal(28,8)");
            builder.Property(e => e.AnalysisUser).HasMaxLength(100);
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");

            builder.HasOne(e => e.RequestArticleOutput)
                .WithOne(e => e.SewingIED)
                .HasForeignKey<SewingIED>(e => e.RequestArticleOutputId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
