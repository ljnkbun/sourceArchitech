using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Infrastructure.TypeConfigurations
{
    public class MeasurementConfiguration : BaseConfiguration<Measurement>
    {
        public override void Configure(EntityTypeBuilder<Measurement> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ErrorCode).HasMaxLength(100);
            builder.Property(e => e.ErrorName).HasMaxLength(500);
            builder.Property(e => e.RootCauseIds).HasMaxLength(500);
            builder.Property(e => e.CorrectActionIds).HasMaxLength(500);
            builder.Property(e => e.PersonInChargeIds).HasMaxLength(500);

            builder.HasOne(s => s.ProductionOutput)
                .WithMany(g => g.Measurements)
                .HasForeignKey(s => s.ProductionOutputId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
