using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class WeavingRappoMatricConfiguration : BaseConfiguration<WeavingRappoMatric>
    {
        public override void Configure(EntityTypeBuilder<WeavingRappoMatric> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            builder.HasOne(e => e.WeavingRappo)
                .WithMany(e => e.WeavingRappoMatrics)
                .HasForeignKey(e => e.WeavingRappoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.HorizontalYarn)
                .WithMany(e => e.WeavingHorizontalRappoMatrics)
                .HasForeignKey(e => e.HorizontalYarnId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.VerticleYarn)
                .WithMany(e => e.WeavingVerticleRappoMatrics)
                .HasForeignKey(e => e.VerticleYarnId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
