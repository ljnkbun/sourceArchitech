using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class KnittingYarnConfiguration : BaseConfiguration<KnittingYarn>
    {
        public override void Configure(EntityTypeBuilder<KnittingYarn> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.YarnCode).IsRequired().HasMaxLength(250);
            builder.Property(e => e.YarnName).IsRequired().HasMaxLength(250);
            builder.Property(e => e.Color).IsRequired().HasMaxLength(100);
            builder.Property(e => e.YarnRatio).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Weight).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Wastage).HasColumnType("decimal(28,8)");

            builder.HasOne(e => e.KnittingIED)
               .WithMany(e => e.KnittingYarns)
               .HasForeignKey(e => e.KnittingIEDId)
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
