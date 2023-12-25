using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class ProcessTemplateItemConfiguration : BaseConfiguration<ProcessTemplateItem>
    {
        public override void Configure(EntityTypeBuilder<ProcessTemplateItem> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");

            builder.HasOne(e => e.ProcessTemplate)
                .WithMany(e => e.ProcessTemplateItems)
                .HasForeignKey(e => e.ProcessTemplateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
