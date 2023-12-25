using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingMacroBOLConfiguration : BaseConfiguration<SewingMacroBOL>
    {
        public override void Configure(EntityTypeBuilder<SewingMacroBOL> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Freq).HasColumnType("decimal(28,8)");
            builder.Property(e => e.TotalTMU).HasColumnType("decimal(28,8)");

            builder.HasOne(e => e.SewingTask)
                .WithMany(e => e.SewingMacroBOLs)
                .HasForeignKey(e => e.SewingTaskId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.SewingMacro)
                .WithMany(e => e.SewingMacroBOLs)
                .HasForeignKey(e => e.SewingMacroId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
