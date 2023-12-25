using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingMacroLibBOLConfiguration : BaseConfiguration<SewingMacroLibBOL>
    {
        public override void Configure(EntityTypeBuilder<SewingMacroLibBOL> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Freq).HasColumnType("decimal(28,8)");
            builder.Property(e => e.TotalTMU).HasColumnType("decimal(28,8)");

            builder.HasOne(e => e.SewingTaskLib)
                .WithMany(e => e.SewingMacroLibBOLs)
                .HasForeignKey(e => e.SewingTaskLibId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.SewingMacroLib)
                .WithMany(e => e.SewingMacroLibBOLs)
                .HasForeignKey(e => e.SewingMacroLibId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
