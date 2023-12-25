using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Infrastructure.TypeConfigurations
{
    public class FabricCompositionConfiguration : BaseConfiguration<FabricComposition>
    {
        public override void Configure(EntityTypeBuilder<FabricComposition> builder)
        {
            base.Configure(builder);

            builder.HasOne(s => s.MaterialRequest)
                .WithMany(g => g.FabricCompositions)
                .HasForeignKey(s => s.MaterialRequestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Percentage).HasColumnType("decimal(28,8)");

            builder.Property(e => e.ContentNameDesc).HasMaxLength(500);
        }
    }
}