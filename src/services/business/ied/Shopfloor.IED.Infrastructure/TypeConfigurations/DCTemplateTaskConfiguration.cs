using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class DCTemplateTaskConfiguration : BaseConfiguration<DCTemplateTask>
    {
        public override void Configure(EntityTypeBuilder<DCTemplateTask> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.TaskCode).HasColumnType("varchar(50)");
            builder.Property(e => e.TaskName).HasMaxLength(250);
            builder.Property(e => e.Temperature).HasColumnType("varchar(50)");
            builder.HasOne(s => s.DCTemplate)
                .WithMany(g => g.DCTemplateTasks)
                .HasForeignKey(s => s.DCTemplateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}