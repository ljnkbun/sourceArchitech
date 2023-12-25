using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class FactoryConfiguration : BaseConfiguration<Factory>
    {
        public override void Configure(EntityTypeBuilder<Factory> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.HasOne(e => e.Divsion)
               .WithMany(e => e.Factories)
               .HasForeignKey(e => e.DivisionId)
               .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
