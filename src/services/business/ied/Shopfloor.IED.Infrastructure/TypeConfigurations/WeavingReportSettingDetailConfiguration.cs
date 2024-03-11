using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class WeavingReportSettingDetailConfiguration : BaseConfiguration<WeavingReportSettingDetail>
    {
        public override void Configure(EntityTypeBuilder<WeavingReportSettingDetail> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Split).HasColumnType("varchar(100)");
            builder.HasOne(e => e.WeavingReportSetting)
                .WithMany(e => e.WeavingReportSettingDetails)
                .HasForeignKey(e => e.WeavingReportSettingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}