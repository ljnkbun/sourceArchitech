using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class ProblemRootCauseConfiguration : BaseConfiguration<ProblemRootCause>
    {
        public override void Configure(EntityTypeBuilder<ProblemRootCause> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.NameVN).HasMaxLength(500);
            builder.Property(e => e.NameEN).HasMaxLength(500);
            builder.Property(e => e.DivisonId).HasColumnType("int");
            builder.Property(e => e.DivisonName).HasMaxLength(500);
            builder.Property(e => e.ProcessId).HasColumnType("int");
            builder.Property(e => e.ProcessName).HasMaxLength(500);
            builder.Property(e => e.CategoryId).HasColumnType("int");
            builder.Property(e => e.CategoryName).HasMaxLength(500);
            builder.Property(e => e.SubCategoryId).HasColumnType("int");
            builder.Property(e => e.SubCategoryName).HasMaxLength(500);

        }
    }
}
