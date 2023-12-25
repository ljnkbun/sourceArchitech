using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class DCTemplateDetailConfiguration : BaseConfiguration<DCTemplateDetail>
    {
        public override void Configure(EntityTypeBuilder<DCTemplateDetail> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ChemicalCode).HasColumnType("varchar(50)");
            builder.Property(e => e.ChemicalName).HasMaxLength(250);
            builder.Property(e => e.Unit).HasMaxLength(500);
            builder.Property(e => e.Value).HasColumnType("decimal(28,8)");
            builder.HasOne(s => s.DcTemplateTask)
                .WithMany(g => g.DcTemplateDetails)
                .HasForeignKey(s => s.DCTemplateTaskId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}