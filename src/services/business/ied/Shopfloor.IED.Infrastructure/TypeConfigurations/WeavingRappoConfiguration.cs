using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class WeavingRappoConfiguration : BaseConfiguration<WeavingRappo>
    {
        public override void Configure(EntityTypeBuilder<WeavingRappo> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            builder.HasOne(e => e.WeavingIED)
                .WithOne(e => e.WeavingRappo)
                .HasForeignKey<WeavingRappo>(e => e.WeavingIEDId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
