using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class DepartmentConfiguration : BaseMasterConfiguration<Department>
    {
        public override void Configure(EntityTypeBuilder<Department> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.HasOne(e => e.Division)
                .WithMany(e => e.Departments)
                .HasForeignKey(e => e.DivisionId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

        }
    }
}
