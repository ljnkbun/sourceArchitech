using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class CompanyCurrencyConfiguration : BaseMasterConfiguration<CompanyCurrency>
    {
        public override void Configure(EntityTypeBuilder<CompanyCurrency> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.RateExchange).HasMaxLength(500);
            builder.Property(e => e.Symbol).HasMaxLength(500);
            builder.Property(e => e.ValidFrom).HasColumnType("datetime").HasDefaultValueSql("(getdate())");
        }
    }
}
