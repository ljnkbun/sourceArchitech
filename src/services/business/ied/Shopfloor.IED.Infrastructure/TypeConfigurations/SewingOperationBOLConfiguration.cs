using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingOperationBOLConfiguration : BaseConfiguration<SewingOperationBOL>
    {
        public override void Configure(EntityTypeBuilder<SewingOperationBOL> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Freq).HasColumnType("decimal(28,8)");
            builder.Property(e => e.TotalTMU).HasColumnType("decimal(28,8)");

            builder.HasOne(e => e.SewingOperation)
                .WithMany(e => e.SewingOperationBOLs)
                .HasForeignKey(e => e.SewingOperationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.SewingTask)
                .WithMany(e => e.SewingOperationBOLs)
                .HasForeignKey(e => e.SewingTaskId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
