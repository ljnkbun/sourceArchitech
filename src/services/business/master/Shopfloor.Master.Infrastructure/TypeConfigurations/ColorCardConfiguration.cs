using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class ColorCardConfiguration : BaseMasterConfiguration<ColorCard>
    {
        public override void Configure(EntityTypeBuilder<ColorCard> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.GroupId);
            builder.Property(e => e.Reference).HasMaxLength(200);
            builder.Property(e => e.BuyerCode).HasMaxLength(200);
            builder.Property(e => e.BuyerName).HasMaxLength(500);
            builder.Property(e => e.SelectColor).HasMaxLength(200);
            builder.Property(e => e.PictureURL).HasMaxLength(500);
        }
    }
}
