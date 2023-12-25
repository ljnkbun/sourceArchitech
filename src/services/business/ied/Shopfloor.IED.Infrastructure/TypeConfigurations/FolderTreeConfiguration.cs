using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class FolderTreeConfiguration : BaseConfiguration<FolderTree>
    {
        public override void Configure(EntityTypeBuilder<FolderTree> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Name).HasMaxLength(500);

            builder.HasOne(x => x.ParentFolder)
            .WithMany(x => x.SubFolders)
            .HasForeignKey(x => x.ParentId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
