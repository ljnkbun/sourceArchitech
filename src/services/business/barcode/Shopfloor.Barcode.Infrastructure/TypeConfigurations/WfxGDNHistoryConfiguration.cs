using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Barcode.Infrastructure.TypeConfigurations
{
    public class WfxGDNHistoryConfiguration : BaseConfiguration<WfxGDNHistory>
    {
        public override void Configure(EntityTypeBuilder<WfxGDNHistory> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RemainQuantity).HasColumnType("decimal(28,8)");

            builder.HasOne(s => s.ExportDetail)
              .WithMany(g => g.WfxGDNHistories)
              .HasForeignKey(s => s.ExportDetailId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.WfxGDN)
              .WithMany(g => g.WfxGDNHistories)
              .HasForeignKey(s => s.WfxGDNId)
              .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
