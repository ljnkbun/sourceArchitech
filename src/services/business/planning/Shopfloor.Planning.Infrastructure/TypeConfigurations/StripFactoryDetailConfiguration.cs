using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class StripFactoryDetailConfiguration : BaseConfiguration<StripFactoryDetail>
    {
        public override void Configure(EntityTypeBuilder<StripFactoryDetail> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RemainingQuantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Color).HasMaxLength(200);
            builder.Property(e => e.Size).HasMaxLength(200);
            builder.Property(e => e.UOM).HasMaxLength(200);
            builder.Property(e => e.TypePORDetail).HasColumnType("tinyint");

            builder.HasOne(s => s.StripFactory)
                   .WithMany(g => g.StripFactoryDetails)
                   .HasForeignKey(s => s.StripFactoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
