using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class RequestConfiguration : BaseConfiguration<Request>
    {
        public override void Configure(EntityTypeBuilder<Request> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.RequestNo).HasMaxLength(200);
            builder.Property(e => e.Deleted).HasDefaultValueSql("((0))");

            builder.HasOne(e => e.RequestType)
                .WithMany(e => e.Requests)
                .HasForeignKey(e => e.RequestTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
