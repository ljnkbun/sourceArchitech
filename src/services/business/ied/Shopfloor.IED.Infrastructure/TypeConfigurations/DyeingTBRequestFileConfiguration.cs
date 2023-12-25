using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class DyeingTBRequestFileConfiguration : BaseConfiguration<DyeingTBRequestFile>
    {
        public override void Configure(EntityTypeBuilder<DyeingTBRequestFile> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.FileName).HasMaxLength(250);
            builder.Property(e => e.FileId).HasColumnType("varchar(50)");
            builder.HasOne(s => s.DyeingTBRequest)
                .WithMany(g => g.DyeingTBRequestFiles)
                .HasForeignKey(s => s.DyeingTBRequestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}