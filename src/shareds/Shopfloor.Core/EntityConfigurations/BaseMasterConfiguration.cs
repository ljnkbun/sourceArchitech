using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Core.EntityConfigurations
{
    public class BaseMasterConfiguration<T> : BaseConfiguration<T> where T : BaseMasterEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).IsRequired();
            builder.HasIndex(e => e.Code).IsUnique();
        }
    }
}
