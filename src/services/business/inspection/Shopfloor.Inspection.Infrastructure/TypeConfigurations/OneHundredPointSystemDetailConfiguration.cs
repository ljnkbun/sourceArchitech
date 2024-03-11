using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class OneHundredPointSystemDetailConfiguration : BaseConfiguration<OneHundredPointSystemDetail>
    {
        public override void Configure(EntityTypeBuilder<OneHundredPointSystemDetail> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.FromKg).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ToKg).HasColumnType("decimal(28,8)");
            builder.Property(e => e.FromDefect).HasColumnType("int");
            builder.Property(e => e.ToDefect).HasColumnType("int");
            builder.Property(e => e.Point).HasColumnType("tinyint");
           
        }
    }
}
