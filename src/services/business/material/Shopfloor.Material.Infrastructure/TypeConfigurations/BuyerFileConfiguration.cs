using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Infrastructure.TypeConfigurations
{
    public class BuyerFileConfiguration : BaseConfiguration<BuyerFile>
    {
        public override void Configure(EntityTypeBuilder<BuyerFile> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.FileName).HasMaxLength(250);
            builder.Property(e => e.FileId).HasColumnType("varchar(50)");
            builder.HasOne(s => s.Buyer)
                .WithMany(g => g.BuyerFiles)
                .HasForeignKey(s => s.BuyerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}