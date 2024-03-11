using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class WeavingReportSettingConfiguration : BaseConfiguration<WeavingReportSetting>
    {
        public override void Configure(EntityTypeBuilder<WeavingReportSetting> builder)
        {
            base.Configure(builder);
            builder.HasOne(e => e.WeavingIED)
                .WithOne(e => e.WeavingReportSetting)
                .HasForeignKey<WeavingReportSetting>(e => e.WeavingIEDId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}