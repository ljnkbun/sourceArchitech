using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class QCDefinitionConfiguration : BaseMasterConfiguration<QCDefinition>
    {
        public override void Configure(EntityTypeBuilder<QCDefinition> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.Buyer).HasMaxLength(500);
            builder.Property(e => e.Category).HasMaxLength(500);
            builder.Property(e => e.AcceptanceValue).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ConversionId).HasColumnType("int");
            builder.HasOne(s => s.Conversion)
            .WithMany(g => g.QCDefinitions)
            .HasForeignKey(s => s.ConversionId)
            .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.QCType)
            .WithMany(g => g.QCDefinitions)
            .HasForeignKey(s => s.QCTypeId)
            .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.AQLVersion)
             .WithMany(g => g.QCDefinitions)
             .HasForeignKey(s => s.AQLVersionId)
             .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.FourPointsSystem)
            .WithMany(g => g.QCDefinitions)
            .HasForeignKey(s => s.FourPointsSystemId)
            .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(s => s.OneHundredPointSystem)
            .WithMany(g => g.QCDefinitions)
            .HasForeignKey(s => s.OneHundredPointSystemId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
