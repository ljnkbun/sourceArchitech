using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Infrastructure.TypeConfigurations
{
    public class DefectCapturingConfiguration : BaseConfiguration<DefectCapturing>
    {
        public override void Configure(EntityTypeBuilder<DefectCapturing> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.ErrorCode).HasMaxLength(100);
            builder.Property(e => e.ErrorName).HasMaxLength(500);
            builder.Property(e => e.RootCauseName).HasMaxLength(500);
            builder.Property(e => e.RootCauseIds).HasMaxLength(500);
            builder.Property(e => e.CorrectActionIds).HasMaxLength(500);
            builder.Property(e => e.PersonInChargeIds).HasMaxLength(500);
            builder.Property(e => e.CorrectActionName).HasMaxLength(500);
            builder.Property(e => e.PersonInChargeName).HasMaxLength(500);
            builder.Property(e => e.IsLongError).HasColumnType("tinyint");
            builder.Property(e => e.LongErrorFrom).HasColumnType("decimal(28,8)");
            builder.Property(e => e.LongErrorTo).HasColumnType("decimal(28,8)");

            builder.HasOne(s => s.ProductionOutput)
                .WithMany(g => g.DefectCapturings)
                .HasForeignKey(s => s.ProductionOutputId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
