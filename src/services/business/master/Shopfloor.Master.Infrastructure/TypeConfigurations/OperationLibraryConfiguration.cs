using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class OperationLibraryConfiguration : BaseMasterConfiguration<OperationLibrary>
    {
        public override void Configure(EntityTypeBuilder<OperationLibrary> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Code).HasMaxLength(200);
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.HasOne(e => e.ProcessLibrary)
                .WithMany(e => e.OperationLibraries)
                .HasForeignKey(e => e.ProcessLibraryId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
