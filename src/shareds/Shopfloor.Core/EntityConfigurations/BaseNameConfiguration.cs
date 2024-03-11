using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.Models.Entities;

namespace Shopfloor.Core.EntityConfigurations
{
    public class BaseNameConfiguration<T> : BaseConfiguration<T> where T : BaseNameEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name).IsRequired();
            builder.HasIndex(e => e.Name).IsUnique();
        }
    }
}
