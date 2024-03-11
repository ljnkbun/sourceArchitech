using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Master.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class HolidayConfiguration : BaseConfiguration<Holiday>
    {
        public override void Configure(EntityTypeBuilder<Holiday> builder)
        {
            base.Configure(builder);
            			builder.Property(e => e.Description).HasMaxLength(500);
        }
    }
}
