using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Infrastructure.TypeConfigurations
{
    public class MaterialRequestDynamicColumnConfiguration : BaseConfiguration<MaterialRequestDynamicColumn>
    {
        public override void Configure(EntityTypeBuilder<MaterialRequestDynamicColumn> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Value).HasMaxLength(500);

            builder.HasOne(s => s.DynamicColumn)
                .WithMany(g => g.MaterialRequestDynamicColumns)
                .HasForeignKey(s => s.DynamicColumnId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.MaterialRequest)
                .WithMany(g => g.DynamicColumns)
                .HasForeignKey(s => s.MaterialRequestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}