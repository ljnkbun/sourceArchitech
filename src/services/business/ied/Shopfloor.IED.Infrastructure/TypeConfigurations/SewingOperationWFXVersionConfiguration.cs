using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingOperationWFXVersionConfiguration : BaseConfiguration<SewingOperationWFXVersion>
    {
        public override void Configure(EntityTypeBuilder<SewingOperationWFXVersion> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Version).IsRequired();
            builder.HasIndex(e => new { e.SewingOperationWFXId, e.Version }).IsUnique();

            builder.HasOne(e => e.SewingOperationWFX)
                .WithMany(e => e.SewingOperationWFXVersions)
                .HasForeignKey(e => e.SewingOperationWFXId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
