using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class TestConfiguration : BaseMasterConfiguration<Test>
    {
        public override void Configure(EntityTypeBuilder<Test> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.HasOne(s => s.TestGroup)
             .WithMany(g => g.Tests)
             .HasForeignKey(s => s.TestGroupId)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
