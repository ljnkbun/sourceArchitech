using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class WeavingRoutingConfiguration : BaseConfiguration<WeavingRouting>
    {
        public override void Configure(EntityTypeBuilder<WeavingRouting> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.WeavingProcess).IsRequired().HasMaxLength(100);
            builder.Property(e => e.WeavingOperation).IsRequired().HasMaxLength(100);
            builder.Property(e => e.MachineType).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            builder.HasOne(e => e.WeavingArticle)
                .WithMany(e => e.WeavingRoutings)
                .HasForeignKey(e => e.WeavingArticleId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
