using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class AttachmentConfiguration : BaseConfiguration<Attachment>
    {
        public override void Configure(EntityTypeBuilder<Attachment> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.FileName).HasMaxLength(500).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.FileId).HasMaxLength(200).IsRequired();
            builder.Property(e => e.FileType).HasColumnType("tinyint");
            builder.HasOne(s => s.Inspection)
               .WithMany(g => g.Attachments)
               .HasForeignKey(s => s.InspectionId)
               .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.Inpection100PointSys)
               .WithMany(g => g.Attachments)
               .HasForeignKey(s => s.Inpection100PointSysId)
               .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.Inpection4PointSys)
               .WithMany(g => g.Attachments)
               .HasForeignKey(s => s.Inpection4PointSysId)
               .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.InpectionTCStandard)
               .WithMany(g => g.Attachments)
               .HasForeignKey(s => s.InpectionTCStandardId)
               .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
