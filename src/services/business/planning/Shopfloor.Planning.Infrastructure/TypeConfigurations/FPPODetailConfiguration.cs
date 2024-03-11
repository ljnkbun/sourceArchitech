using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;


namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class FPPODetailConfiguration : BaseConfiguration<FPPODetail>
    {
        public override void Configure(EntityTypeBuilder<FPPODetail> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Color).HasMaxLength(50);
            builder.Property(e => e.Size).HasMaxLength(50);
            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");
            builder.HasOne(s => s.FPPO)
                 .WithMany(g => g.FPPODetails)
                 .HasForeignKey(s => s.FPPOId)
                 .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
