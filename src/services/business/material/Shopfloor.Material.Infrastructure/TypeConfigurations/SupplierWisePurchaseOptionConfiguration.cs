using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Infrastructure.TypeConfigurations
{
    public class SupplierWisePurchaseOptionConfiguration : BaseConfiguration<SupplierWisePurchaseOption>
    {
        public override void Configure(EntityTypeBuilder<SupplierWisePurchaseOption> builder)
        {
            base.Configure(builder);

            builder.HasOne(s => s.MaterialRequest)
                .WithMany(g => g.SupplierWisePurchaseOptions)
                .HasForeignKey(s => s.MaterialRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Moq).HasMaxLength(500);
            builder.Property(e => e.MoqRoundingTypeId).HasMaxLength(500);
            builder.Property(e => e.SupplierId).HasMaxLength(500);
            builder.Property(e => e.MoqSurChargeValue).HasMaxLength(500);
            builder.Property(e => e.MoqSurchargeCurrency).HasMaxLength(500);
            builder.Property(e => e.Color).HasMaxLength(500);
            builder.Property(e => e.Size).HasMaxLength(500);
            builder.Property(e => e.Mcq).HasMaxLength(500);
            builder.Property(e => e.McqSurchargeValue).HasMaxLength(500);
            builder.Property(e => e.McqSurchargeCurrency).HasMaxLength(500);
        }
    }
}