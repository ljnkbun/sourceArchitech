using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Infrastructure.TypeConfigurations
{
    public class FPPOOutputDetailConfiguration : BaseConfiguration<FPPOOutputDetail>
    {
        public override void Configure(EntityTypeBuilder<FPPOOutputDetail> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Color).HasMaxLength(100);
            builder.Property(e => e.Size).HasMaxLength(100);
            builder.Property(e => e.PlannedQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MadeQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.BalanceQty).HasColumnType("decimal(28,8)");

            builder.HasOne(s => s.FPPOOutput)
                 .WithMany(g => g.FPPODetails)
                 .HasForeignKey(s => s.FPPOOutputId)
                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
