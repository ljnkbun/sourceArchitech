using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Barcode.Infrastructure.TypeConfigurations
{
    public class AppVersionConfiguration : BaseConfiguration<AppVersion>
    {
        public override void Configure(EntityTypeBuilder<AppVersion> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name).HasMaxLength(500);
        }
    }
}