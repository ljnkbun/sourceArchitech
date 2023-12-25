using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class DyeingTBRequestConfiguration : BaseConfiguration<DyeingTBRequest>
    {
        public override void Configure(EntityTypeBuilder<DyeingTBRequest> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.RequestNo).HasColumnType("varchar(50)");
            builder.Property(e => e.StyleRef).HasMaxLength(250);
            builder.Property(e => e.Remark).HasMaxLength(500);
            builder.Property(e => e.Buyer).HasMaxLength(250);
            builder.Property(e => e.BuyerRef).HasMaxLength(250);
        }
    }
}