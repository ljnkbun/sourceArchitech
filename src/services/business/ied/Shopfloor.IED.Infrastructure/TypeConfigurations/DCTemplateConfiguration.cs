using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class DCTemplateConfiguration : BaseConfiguration<DCTemplate>
    {
        public override void Configure(EntityTypeBuilder<DCTemplate> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasColumnType("varchar(50)");
            builder.Property(e => e.Name).HasMaxLength(250);
        }
    }
}