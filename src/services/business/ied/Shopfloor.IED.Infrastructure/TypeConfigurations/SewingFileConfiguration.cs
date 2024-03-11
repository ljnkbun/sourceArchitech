using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingFileConfiguration : BaseConfiguration<SewingFile>
    {
        public override void Configure(EntityTypeBuilder<SewingFile> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.FileName).HasMaxLength(250);
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.FileId).HasMaxLength(100);

            builder.HasOne(e => e.SewingIED)
                .WithMany(e => e.SewingFiles)
                .HasForeignKey(e => e.SewingIEDId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
