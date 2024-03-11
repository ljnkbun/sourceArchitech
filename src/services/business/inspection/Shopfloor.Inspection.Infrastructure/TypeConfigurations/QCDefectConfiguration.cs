using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class QCDefectConfiguration : BaseMasterConfiguration<QCDefect>
    {
        public override void Configure(EntityTypeBuilder<QCDefect> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.QCDefecTypeId).HasColumnType("int");
            builder.Property(e => e.ParrentId).HasColumnType("int");
            builder.Property(e => e.NameEN).HasMaxLength(500);
            builder.Property(e => e.DivisonId).HasColumnType("int");
            builder.Property(e => e.DivisonName).HasMaxLength(500);
            builder.Property(e => e.ProcessId).HasColumnType("int");
            builder.Property(e => e.ProcessName).HasMaxLength(500);
            builder.Property(e => e.CategoryId).HasColumnType("int");
            builder.Property(e => e.CategoryName).HasMaxLength(500);
            builder.Property(e => e.SubCategoryId).HasMaxLength(500);
            builder.Property(e => e.SubCategoryName).HasMaxLength(500);
            builder.Property(e => e.Level).HasColumnType("int");
            builder.Property(e => e.InspectionType).HasColumnType("tinyint");
            builder.HasOne(s => s.QCDefectType)
                .WithMany(g => g.QCDefects)
                .HasForeignKey(s => s.QCDefecTypeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
