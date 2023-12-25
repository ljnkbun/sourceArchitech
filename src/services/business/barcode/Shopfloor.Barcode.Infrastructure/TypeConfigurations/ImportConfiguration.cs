using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Barcode.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;

namespace Shopfloor.Barcode.Infrastructure.TypeConfigurations
{
    public class ImportConfiguaration : BaseMasterConfiguration<Import>
    {
        public override void Configure(EntityTypeBuilder<Import> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.Note).HasMaxLength(500);
            builder.Property(e => e.Status).HasColumnType("tinyint");
            builder.Property(e => e.Type).HasColumnType("tinyint");
        }
    }
}
