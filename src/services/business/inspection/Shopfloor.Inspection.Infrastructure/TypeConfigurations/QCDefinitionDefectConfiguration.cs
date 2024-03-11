using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class QCDefinitionDefectConfiguration : BaseConfiguration<QCDefinitionDefect>
    {
        public override void Configure(EntityTypeBuilder<QCDefinitionDefect> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.QCDefinitionId).HasColumnType("int");
            builder.Property(e => e.QCDefectId).HasColumnType("int");
            builder.HasOne(s => s.QCDefinition)
                  .WithMany(g => g.QCDefinitionDefects)
                  .HasForeignKey(s => s.QCDefinitionId)
                  .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.QCDefect)
                .WithMany(g => g.QCDefinitionDefects)
                .HasForeignKey(s => s.QCDefectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
