using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class SewingSubcategoryEfficiencyConfiguration : BaseConfiguration<SewingSubcategoryEfficiency>
    {
        public override void Configure(EntityTypeBuilder<SewingSubcategoryEfficiency> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.SubCategory).HasColumnType("varchar(250)");
            builder.HasOne(e => e.SewingEfficiencyProfile)
            .WithMany(e => e.SewingSubcategoryEfficiencies)
            .HasForeignKey(e => e.SewingEfficiencyProfileId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}