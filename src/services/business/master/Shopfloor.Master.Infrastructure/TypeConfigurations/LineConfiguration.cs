using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class LineConfiguration : BaseMasterConfiguration<Line>
    {
        public override void Configure(EntityTypeBuilder<Line> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);

            builder.HasOne(e => e.Factory)
                .WithMany(e => e.Lines)
                .HasForeignKey(e => e.FactoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Process)
                .WithMany(e => e.Lines)
                .HasForeignKey(e => e.ProcessId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
