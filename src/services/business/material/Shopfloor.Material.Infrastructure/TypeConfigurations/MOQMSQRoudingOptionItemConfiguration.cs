using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Infrastructure.TypeConfigurations
{
    public class MOQMSQRoudingOptionItemConfiguration : BaseConfiguration<MOQMSQRoudingOptionItem>
    {
        public override void Configure(EntityTypeBuilder<MOQMSQRoudingOptionItem> builder)
        {
            base.Configure(builder);

            builder.HasOne(s => s.MaterialRequest)
                .WithMany(g => g.MoqmsqRoudingOptionItems)
                .HasForeignKey(s => s.MaterialRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.From).HasColumnType("decimal(28,8)");

            builder.Property(e => e.To).HasColumnType("decimal(28,8)");

            builder.Property(e => e.Qty).HasColumnType("decimal(28,8)");

            builder.Property(e => e.Type).HasMaxLength(500);
        }
    }
}