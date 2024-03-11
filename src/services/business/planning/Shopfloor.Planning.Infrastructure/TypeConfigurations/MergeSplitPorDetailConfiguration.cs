using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class MergeSplitPorDetailConfiguration : BaseConfiguration<MergeSplitPorDetail>
    {
        public override void Configure(EntityTypeBuilder<MergeSplitPorDetail> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Quantity).HasColumnType("decimal(28,8)");

            builder.HasOne(s => s.FromPorDetail)
                .WithMany(g => g.FromMergeSplitPorDetails)
                .HasForeignKey(s => s.FromPorDetailId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.ToPorDetail)
                .WithMany(g => g.ToMergeSplitPorDetails)
                .HasForeignKey(s => s.ToPorDetailId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
