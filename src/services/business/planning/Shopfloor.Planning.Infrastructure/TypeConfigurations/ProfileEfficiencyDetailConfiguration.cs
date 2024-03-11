using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class ProfileEfficiencyDetailConfiguration : BaseConfiguration<ProfileEfficiencyDetail>
    {
        public override void Configure(EntityTypeBuilder<ProfileEfficiencyDetail> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.SubCategoryCode).HasMaxLength(200);
            builder.Property(e => e.SubCategoryName).HasMaxLength(500);
            builder.Property(e => e.EfficiencyValue).HasColumnType("decimal(28,8)");

            builder.HasOne(e => e.ProfileEfficiency)
                .WithMany(e => e.ProfileEfficiencyDetails)
                .HasForeignKey(e => e.ProfileEfficiencyId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}
