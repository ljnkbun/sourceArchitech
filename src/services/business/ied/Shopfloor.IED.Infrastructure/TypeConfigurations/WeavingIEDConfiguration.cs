using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class WeavingIEDConfiguration : BaseConfiguration<WeavingIED>
    {
        public override void Configure(EntityTypeBuilder<WeavingIED> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.RequestNo).HasMaxLength(100);
            builder.Property(e => e.Comment).HasMaxLength(250);
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");
        }
    }
}
