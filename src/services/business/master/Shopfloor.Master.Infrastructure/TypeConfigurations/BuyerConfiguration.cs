using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class BuyerConfiguration : BaseConfiguration<Buyer>
    {
        public override void Configure(EntityTypeBuilder<Buyer> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.WFXBuyerId).HasColumnType("varchar(50)");
            builder.Property(e => e.Name).HasMaxLength(500);
        }
    }
}