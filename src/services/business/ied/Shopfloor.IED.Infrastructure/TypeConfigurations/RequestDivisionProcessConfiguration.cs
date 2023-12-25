using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class RequestDivisionProcessConfiguration : BaseConfiguration<RequestDivisionProcess>
    {
        public override void Configure(EntityTypeBuilder<RequestDivisionProcess> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.ProcessCode).IsRequired().HasMaxLength(100);
            builder.Property(e => e.ProcessName).IsRequired().HasMaxLength(100);

            builder.HasOne(e => e.RequestDivision)
                .WithMany(e => e.RequestDivisionProcesses)
                .HasForeignKey(e => e.RequestDivisionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
