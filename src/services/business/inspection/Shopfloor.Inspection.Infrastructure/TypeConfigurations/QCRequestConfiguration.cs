using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class QCRequestConfiguration : BaseConfiguration<QCRequest>
    {
        public override void Configure(EntityTypeBuilder<QCRequest> builder)
        {
            base.Configure(builder);
			builder.Property(e => e.SiteCode).HasMaxLength(50);
			builder.Property(e => e.SiteName).HasMaxLength(200);
			builder.Property(e => e.SupplierName).HasMaxLength(200);
			builder.Property(e => e.QCRequestNo).HasMaxLength(100);
			builder.Property(e => e.Category).HasMaxLength(200);
			builder.Property(e => e.DocumentNo).HasMaxLength(100);
			builder.Property(e => e.QCDefinitionCode).HasMaxLength(200);
			builder.Property(e => e.RequestedQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.QCRequestStatus).HasColumnType("tinyint");
            builder.Property(e => e.QCRequestDate).HasColumnType("datetime");
            builder.Property(e => e.TransferStatus).HasColumnType("tinyint");
        }
    }
}
