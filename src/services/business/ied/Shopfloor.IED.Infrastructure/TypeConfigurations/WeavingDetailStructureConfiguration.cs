using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class WeavingDetailStructureConfiguration : BaseConfiguration<WeavingDetailStructure>
    {
        public override void Configure(EntityTypeBuilder<WeavingDetailStructure> builder)
        {
            base.Configure(builder);
            builder.HasOne(e => e.WeavingIED)
                .WithMany(e => e.WeavingDetailStructures)
                .HasForeignKey(e => e.WeavingIEDId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
