using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingSubOperationWFXBOLConfiguration : BaseConfiguration<SewingSubOperationWFXBOL>
    {
        public override void Configure(EntityTypeBuilder<SewingSubOperationWFXBOL> builder)
        {
            base.Configure(builder);

            builder.HasOne(e => e.SewingSubOperationWFX)
                .WithMany(e => e.SewingSubOperationWFXBOLs)
                .HasForeignKey(e => e.SewingSubOperationWFXId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
