using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class InspectionConfiguration : BaseConfiguration<Shopfloor.Inspection.Domain.Entities.Inspection>
    {
        public override void Configure(EntityTypeBuilder<Shopfloor.Inspection.Domain.Entities.Inspection> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.QCRequestArticleId).HasColumnType("int");
            builder.Property(e => e.MeasurementQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.InspectionQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Reason).HasMaxLength(500);
            builder.Property(e => e.Remark).HasMaxLength(500);
            builder.Property(e => e.Line).HasMaxLength(500);
            builder.Property(e => e.TotalDefect).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Stage).HasMaxLength(500);
            builder.Property(e => e.CuttingTable).HasMaxLength(500);
            builder.Property(e => e.DefaultResult).HasColumnType("bit");
            builder.Property(e => e.UserResult).HasColumnType("bit");
            builder.Property(e => e.MeasurementResult).HasColumnType("bit");
            builder.Property(e => e.IsCreatedFromProduction).HasColumnType("bit");
            builder.Property(e => e.InspectionDate).HasColumnType("datetime");

          
        }
    }
}
