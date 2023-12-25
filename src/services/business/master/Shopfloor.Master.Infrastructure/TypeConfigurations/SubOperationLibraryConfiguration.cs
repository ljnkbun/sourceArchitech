using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class SubOperationLibraryConfiguration : BaseMasterConfiguration<SubOperationLibrary>
    {
        public override void Configure(EntityTypeBuilder<SubOperationLibrary> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.HasOne(e => e.OperationLibrary)
                .WithMany(e => e.SubOperationLibraries)
                .HasForeignKey(e => e.OperationLibraryId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
