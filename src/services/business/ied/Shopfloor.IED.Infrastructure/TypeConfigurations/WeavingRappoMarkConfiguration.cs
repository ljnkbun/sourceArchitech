using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class WeavingRappoMarkConfiguration : BaseConfiguration<WeavingRappoMark>
    {
        public override void Configure(EntityTypeBuilder<WeavingRappoMark> builder)
        {
            base.Configure(builder);
            builder.HasOne(e => e.WeavingRappo)
                .WithMany(e => e.WeavingRappoMarks)
                .HasForeignKey(e => e.WeavingRappoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
