using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.Converters;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class CalendarDetailConfiguration : BaseConfiguration<CalendarDetail>
    {
        public override void Configure(EntityTypeBuilder<CalendarDetail> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.StartTime).HasConversion<TimeOnlyConverter>();
            builder.Property(e => e.EndTime).HasConversion<TimeOnlyConverter>();

            builder.Property(e => e.WorkingHours)
                .HasColumnType("decimal(3,1)")
                .HasMaxLength(24);
            builder.Property(e => e.BreakHours)
                .HasColumnType("decimal(2,1)")
                .HasMaxLength(4);
            builder.HasOne(e => e.Calendar)
                .WithMany(e => e.CalendarDetails)
                .HasForeignKey(e => e.CalendarId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
