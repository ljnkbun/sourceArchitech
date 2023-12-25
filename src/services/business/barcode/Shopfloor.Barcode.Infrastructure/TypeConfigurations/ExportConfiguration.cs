using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Barcode.Infrastructure.TypeConfigurations
{
    public class ExportConfiguration : BaseMasterConfiguration<Export>
    {
        public override void Configure(EntityTypeBuilder<Export> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(100);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.Note).HasMaxLength(1000);
            builder.Property(e => e.Status).HasColumnType("tinyint");


        }
    }
}
