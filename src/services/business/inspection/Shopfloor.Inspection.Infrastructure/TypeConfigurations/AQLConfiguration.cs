using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class AQLConfiguration : BaseConfiguration<AQL>
    {
        public override void Configure(EntityTypeBuilder<AQL> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.AQLVersionId).HasColumnType("int");
            builder.Property(e => e.LotSizeFrom).HasColumnType("int");
            builder.Property(e => e.LotSizeTo).HasColumnType("int");
            builder.Property(e => e.SampleSize).HasColumnType("int");
            builder.Property(e => e.Accept).HasColumnType("int");
            builder.Property(e => e.Reject).HasColumnType("int");
            builder.HasOne(s => s.AQLVersion)
            .WithMany(g => g.AQLs)
            .HasForeignKey(s => s.AQLVersionId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
