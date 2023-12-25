using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class DyeingTBRCValueConfiguration : BaseConfiguration<DyeingTBRCValue>
    {
        public override void Configure(EntityTypeBuilder<DyeingTBRCValue> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Value).HasColumnType("decimal(28,8)");
            builder.HasOne(s => s.DyeingTBRVersion)
                .WithMany(g => g.DyeingTBRCValues)
                .HasForeignKey(s => s.DyeingTBRVersionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}