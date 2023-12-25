using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Master.Domain.Entities;

namespace Shopfloor.Master.Infrastructure.TypeConfigurations
{
    public class UOMConversionConfiguration : BaseConfiguration<UOMConversion>
    {
        public override void Configure(EntityTypeBuilder<UOMConversion> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.Value).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Action).HasMaxLength(500);
            builder.HasOne(e => e.FromUOM)
                .WithMany(e => e.FromUOMConversions)
                .HasForeignKey(e => e.FromUOMId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
            builder.HasOne(e => e.ToUOM)
                .WithMany(e => e.ToUOMConversions)
                .HasForeignKey(e => e.ToUOMId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}

