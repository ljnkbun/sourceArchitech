using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Inspection.Domain.Entities;
using Shopfloor.Core.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class InpectionTCStandardConfiguration : BaseConfiguration<InpectionTCStandard>
    {
        public override void Configure(EntityTypeBuilder<InpectionTCStandard> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.QCRequestArticleId).HasColumnType("int");
            builder.Property(e => e.StockMovementNo).HasMaxLength(20);
            builder.Property(e => e.Grade).HasMaxLength(20);
            builder.Property(e => e.PersonInChargeId).HasColumnType("int");
            builder.Property(e => e.Remark).HasMaxLength(500);
            builder.Property(e => e.Result).HasColumnType("bit");
            builder.Property(e => e.IsCreatedFromProduction).HasColumnType("bit");
            builder.Property(e => e.InspectionDate).HasColumnType("datetime");
        }
    }
}
