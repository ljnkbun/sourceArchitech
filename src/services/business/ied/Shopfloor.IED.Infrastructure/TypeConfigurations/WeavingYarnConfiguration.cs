using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class WeavingYarnConfiguration : BaseConfiguration<WeavingYarn>
    {
        public override void Configure(EntityTypeBuilder<WeavingYarn> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.YarnCode).IsRequired().HasMaxLength(100);
            builder.Property(e => e.YarnName).IsRequired().HasMaxLength(250);
            builder.Property(e => e.YarnInRappo).HasColumnType("decimal(28,8)");
            builder.Property(e => e.YarnRatio).HasColumnType("decimal(28,8)");
            builder.Property(e => e.SizingRatio).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ScaleRatio).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ScrapRatio).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Weight).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            builder.HasOne(e => e.WeavingArticle)
                .WithMany(e => e.WeavingYarns)
                .HasForeignKey(e => e.WeavingArticleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
