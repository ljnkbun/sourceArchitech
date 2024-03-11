using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class WeavingRoutingConfiguration : BaseConfiguration<WeavingRouting>
    {
        public override void Configure(EntityTypeBuilder<WeavingRouting> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.WeavingProcess).IsRequired().HasMaxLength(100);
            builder.Property(e => e.WeavingProcessCode).HasColumnType("varchar(100)");
            builder.HasOne(e => e.WeavingIED)
                .WithMany(e => e.WeavingRoutings)
                .HasForeignKey(e => e.WeavingIEDId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}