using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class RequestDivisionConfiguration : BaseConfiguration<RequestDivision>
    {
        public override void Configure(EntityTypeBuilder<RequestDivision> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.DivisionCode).IsRequired().HasMaxLength(100);
            builder.Property(e => e.DivisionName).IsRequired().HasMaxLength(100);

            builder.HasOne(e => e.Request)
                .WithMany(e => e.RequestDivisions)
                .HasForeignKey(e => e.RequestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
