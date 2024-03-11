using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class WeavingFileConfiguration : BaseConfiguration<WeavingFile>
    {
        public override void Configure(EntityTypeBuilder<WeavingFile> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.FileName).HasMaxLength(250);
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.FileId).HasMaxLength(100);

            builder.HasOne(e => e.WeavingIED)
                .WithMany(e => e.WeavingFiles)
                .HasForeignKey(e => e.WeavingIEDId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
