using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Infrastructure.TypeConfigurations
{
    public class DynamicColumnContentConfiguration : BaseConfiguration<DynamicColumnContent>
    {
        public override void Configure(EntityTypeBuilder<DynamicColumnContent> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Code).HasColumnType("varchar(200)");

            builder.Property(e => e.Content).HasMaxLength(500);

            builder.HasOne(s => s.DynamicColumn)
                .WithMany(g => g.DynamicColumnContents)
                .HasForeignKey(s => s.DynamicColumnId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}