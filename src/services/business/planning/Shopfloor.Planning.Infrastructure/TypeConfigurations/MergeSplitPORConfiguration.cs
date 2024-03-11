using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class MergeSplitPORConfiguration : BaseConfiguration<MergeSplitPOR>
    {
        public override void Configure(EntityTypeBuilder<MergeSplitPOR> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");

            builder.HasOne(s => s.FromPOR)
                .WithMany(g => g.FromMergeSplitPORs)
                .HasForeignKey(s => s.FromPORId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.ToPOR)
                .WithMany(g => g.ToMergeSplitPORs)
                .HasForeignKey(s => s.ToPORId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
