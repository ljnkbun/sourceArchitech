using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class KnittingFileConfiguration : BaseConfiguration<KnittingFile>
    {
        public override void Configure(EntityTypeBuilder<KnittingFile> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.FileName).HasMaxLength(250);
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.FileId).HasMaxLength(100);

            builder.HasOne(e => e.KnittingIED)
                .WithMany(e => e.KnittingFiles)
                .HasForeignKey(e => e.KnittingIEDId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
