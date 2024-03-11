using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Inspection.Domain.Entities;

namespace Shopfloor.Inspection.Infrastructure.TypeConfigurations
{
    public class Inpection100PointSysConfiguration : BaseConfiguration<Inpection100PointSys>
    {
        public override void Configure(EntityTypeBuilder<Inpection100PointSys> builder)
        {
            base.Configure(builder);
            builder.Property(e => e.QCRequestArticleId).HasColumnType("int");
            builder.Property(e => e.StockMovementNo).HasMaxLength(20);
            builder.Property(e => e.CaptureMeter).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ActualWeight).HasColumnType("decimal(28,8)");
            builder.Property(e => e.TotalDefect).HasColumnType("int");
            builder.Property(e => e.TotalContDefect).HasColumnType("int");
            builder.Property(e => e.TotalPoint).HasColumnType("int");
            builder.Property(e => e.PointSquareMeter).HasColumnType("int");
            builder.Property(e => e.WarpDensity).HasColumnType("int");
            builder.Property(e => e.WeftDensity).HasColumnType("int");
            builder.Property(e => e.PersonInChargeId).HasColumnType("int");
            builder.Property(e => e.Remark).HasMaxLength(500);
            builder.Property(e => e.Grade).HasMaxLength(20);
            builder.Property(e => e.WeightGM2).HasColumnType("decimal(28,8)");
            builder.Property(e => e.SystemResult).HasColumnType("bit");
            builder.Property(e => e.UserResult).HasColumnType("bit");
            builder.Property(e => e.IsCreatedFromProduction).HasColumnType("bit");
            builder.Property(e => e.InspectionDate).HasColumnType("datetime");
        }
    }
}
