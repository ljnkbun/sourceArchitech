using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;


namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class PORDetailConfiguration : BaseConfiguration<PORDetail>
    {
        public override void Configure(EntityTypeBuilder<PORDetail> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Color).HasMaxLength(250);
            builder.Property(e => e.Size).HasMaxLength(200);
            builder.Property(e => e.OrderedQuantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.RemainingQuantity).HasColumnType("decimal(28,8)");
            builder.Property(e => e.TypePORDetail).HasColumnType("tinyint");
            builder.HasOne(s => s.POR)
                 .WithMany(g => g.PORDetails)
                 .HasForeignKey(s => s.PORId)
                 .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
