using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Infrastructure.TypeConfigurations
{
    public class PriceListConfiguration : BaseConfiguration<PriceList>
    {
        public override void Configure(EntityTypeBuilder<PriceList> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.RequestNo).HasColumnType("varchar(50)");
            builder.Property(e => e.SupplierName).HasMaxLength(500);
            builder.Property(e => e.CategoryName).HasMaxLength(500);
            builder.Property(e => e.ApproveUserId).HasMaxLength(200);
            builder.Property(e => e.ApproveName).HasMaxLength(200);
            builder.Property(e => e.SupplierCode).HasColumnType("varchar(200)");
            builder.Property(e => e.CategoryCode).HasColumnType("varchar(200)");
        }
    }
}