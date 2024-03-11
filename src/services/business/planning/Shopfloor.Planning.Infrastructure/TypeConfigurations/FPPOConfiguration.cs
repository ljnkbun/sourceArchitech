using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Planning.Domain.Entities;

namespace Shopfloor.Planning.Infrastructure.TypeConfigurations
{
    public class FPPOConfiguration : BaseConfiguration<FPPO>
    {
        public override void Configure(EntityTypeBuilder<FPPO> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.FPPONo).HasMaxLength(100);
            builder.Property(e => e.OCNo).HasMaxLength(100);
            builder.Property(e => e.PORNo).HasMaxLength(100);
            builder.Property(e => e.BatchNo).HasMaxLength(250);
            builder.Property(e => e.JobOrderNo).HasMaxLength(100);
            builder.Property(e => e.ProcessCode).HasMaxLength(100);
            builder.Property(e => e.ProcessName).HasMaxLength(100);
            builder.Property(e => e.ArticleCode).HasMaxLength(100);
            builder.Property(e => e.ArticleName).HasMaxLength(250);
            builder.Property(e => e.WFXDeliveryOrderCode).HasColumnType("varchar(100)");
            builder.Property(e => e.Supplier).HasMaxLength(500);
            builder.Property(e => e.WipDispatchSite).HasMaxLength(250);
            builder.Property(e => e.WipReceivingSite).HasMaxLength(250);
            builder.Property(e => e.UOM).HasMaxLength(250);
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");
            builder.HasOne(e => e.StripSchedule)
                .WithMany(e => e.FPPOs)
                .HasForeignKey(e => e.StripScheduleId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
