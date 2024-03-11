using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Infrastructure.TypeConfigurations
{
    public class AttachmentConfiguration : BaseConfiguration<Attachment>
    {
        public override void Configure(EntityTypeBuilder<Attachment> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.FileId).HasMaxLength(100);
            builder.Property(e => e.FileName).HasMaxLength(500);
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.FileType).HasColumnType("tinyint");

            builder.HasOne(s => s.ProductionOutput)
               .WithOne(g => g.Attachment)
               .HasForeignKey<Attachment>(s => s.ProductionOutputId);

            builder.HasOne(s => s.DefectCapturing4Points)
               .WithOne(g => g.Attachment)
               .HasForeignKey<Attachment>(s => s.DefectCapturing4PointsId);

            builder.HasOne(s => s.DefectCapturing100Points)
               .WithOne(g => g.Attachment)
               .HasForeignKey<Attachment>(s => s.DefectCapturing100PointsId);

            builder.HasOne(s => s.DefectCapturingStandard)
               .WithOne(g => g.Attachment)
               .HasForeignKey<Attachment>(s => s.DefectCapturingStandardId);

        }
    }
}
