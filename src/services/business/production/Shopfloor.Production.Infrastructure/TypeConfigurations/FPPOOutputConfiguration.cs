using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Production.Domain.Entities;

namespace Shopfloor.Production.Infrastructure.TypeConfigurations
{
    public class FPPOOutputConfiguration : BaseConfiguration<FPPOOutput>
    {
        public override void Configure(EntityTypeBuilder<FPPOOutput> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.Start).HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(e => e.End).HasColumnType("datetime")
                .HasDefaultValueSql("(getdate())");
            builder.Property(e => e.FPPONo).HasMaxLength(100);
            builder.Property(e => e.PORNo).HasMaxLength(100);
            builder.Property(e => e.OperationCode).HasMaxLength(100);
            builder.Property(e => e.OperationName).HasMaxLength(500);
            builder.Property(e => e.ArticleCode).HasMaxLength(100);
            builder.Property(e => e.ArticleName).HasMaxLength(500);
            builder.Property(e => e.JobOrderNo).HasMaxLength(100);
            builder.Property(e => e.BatchNo).HasMaxLength(500);
            builder.Property(e => e.OCNo).HasMaxLength(500);
            builder.Property(e => e.QCName).HasMaxLength(100);
            builder.Property(e => e.UOM).HasMaxLength(100);
            builder.Property(e => e.ProcessCode).HasMaxLength(100);
            builder.Property(e => e.ProcessName).HasMaxLength(500);
            
        }
    }
}
