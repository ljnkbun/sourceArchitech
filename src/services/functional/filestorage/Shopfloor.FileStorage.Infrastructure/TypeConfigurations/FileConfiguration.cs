using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.FileStorage.Infrastructure.TypeConfigurations
{
    public class FileConfiguration : BaseConfiguration<Domain.Entities.File>
    {
        public override void Configure(EntityTypeBuilder<Domain.Entities.File> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.Folder).HasMaxLength(200);
            builder.Property(e => e.Extension).HasMaxLength(100);
            builder.Property(e => e.Size).HasColumnType("bigint");
        }
    }
}
