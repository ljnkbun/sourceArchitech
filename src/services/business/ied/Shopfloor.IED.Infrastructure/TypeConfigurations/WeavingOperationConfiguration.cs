using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.IED.Domain.Entities;

namespace Shopfloor.IED.Infrastructure.TypeConfigurations
{
    public class WeavingOperationConfiguration : BaseConfiguration<WeavingOperation>
    {
        public override void Configure(EntityTypeBuilder<WeavingOperation> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.MachineType).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Operation).IsRequired().HasMaxLength(100);
            builder.Property(e => e.ArticleCode).HasMaxLength(250);
            builder.Property(e => e.ArticleName).HasMaxLength(250);
            builder.Property(e => e.LineNumber).IsRequired();
            builder.HasOne(e => e.WeavingRouting)
                .WithMany(e => e.WeavingOperations)
                .HasForeignKey(e => e.WeavingRoutingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}