using MassTransit.Internals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Shopfloor.Core.EntityConfigurations;
using Shopfloor.Material.Domain.Entities;

namespace Shopfloor.Material.Infrastructure.TypeConfigurations
{
    public class MaterialRequestConfiguration : BaseConfiguration<MaterialRequest>
    {
        public override void Configure(EntityTypeBuilder<MaterialRequest> builder)
        {
            base.Configure(builder);

            builder.Property(e => e.RequestNo).HasColumnType("varchar(50)");
            builder.Property(e => e.HSCode).HasColumnType("varchar(100)");
            builder.Property(e => e.ArticleName).HasMaxLength(500);

            builder.Property(e => e.ArticleDesc).HasMaxLength(500);

            builder.Property(e => e.BuyerRef).HasMaxLength(500);

            builder.Property(e => e.SupplierRef).HasMaxLength(500);

            builder.Property(e => e.BuyingPrice).HasColumnType("decimal(28,8)");

            builder.Property(e => e.ProvisionalStyleRef).HasMaxLength(500);

            builder.Property(e => e.SampleRef).HasMaxLength(500);

            builder.Property(e => e.ReorderLevel).HasMaxLength(500);

            builder.Property(e => e.Remarks).HasMaxLength(500);

            builder.Property(e => e.ContentName).HasMaxLength(500);

            builder.Property(e => e.SecondaryUomConversion).HasColumnType("decimal(28,8)");

            builder.Property(e => e.StockMovementConversion).HasColumnType("decimal(28,8)");

            builder.Property(e => e.PicName).HasColumnType("varchar(200)");

            builder.Property(e => e.Brand).HasColumnType("varchar(200)");
            builder.Property(e => e.BuyerCode).HasColumnType("varchar(200)");
            builder.Property(e => e.BuyerDivisionSupplierCode).HasColumnType("varchar(200)");
            builder.Property(e => e.BuyingCurrencyCode).HasColumnType("varchar(200)");
            builder.Property(e => e.ColorGroupCode).HasColumnType("varchar(200)");
            builder.Property(e => e.ColorTypeCode).HasColumnType("varchar(200)");
            builder.Property(e => e.ConsUomCode).HasColumnType("varchar(200)");
            builder.Property(e => e.ConstructionCode).HasColumnType("varchar(200)");
            builder.Property(e => e.CountCode).HasColumnType("varchar(200)");
            builder.Property(e => e.CropSeasonCode).HasColumnType("varchar(200)");
            builder.Property(e => e.DivisionCode).HasColumnType("varchar(200)");
            builder.Property(e => e.FiberTypeCode).HasColumnType("varchar(200)");
            builder.Property(e => e.GenderCode).HasColumnType("varchar(200)");
            builder.Property(e => e.GradeCode).HasColumnType("varchar(200)");
            builder.Property(e => e.MicronaireCode).HasColumnType("varchar(200)");
            builder.Property(e => e.OriginCode).HasColumnType("varchar(200)");
            builder.Property(e => e.OurContactCode).HasColumnType("varchar(200)");
            builder.Property(e => e.PerSizeConsCode).HasColumnType("varchar(200)");
            builder.Property(e => e.PricePerCode).HasColumnType("varchar(200)");
            builder.Property(e => e.ProductCatCode).HasColumnType("varchar(200)");
            builder.Property(e => e.ProductGroupCode).HasColumnType("varchar(200)");
            builder.Property(e => e.ProductSubCatCode).HasColumnType("varchar(200)");
            builder.Property(e => e.QualityCode).HasColumnType("varchar(200)");
            builder.Property(e => e.SeasonCode).HasColumnType("varchar(200)");
            builder.Property(e => e.SecondaryUomCode).HasColumnType("varchar(200)");
            builder.Property(e => e.StapleCode).HasColumnType("varchar(200)");
            builder.Property(e => e.SizeGroupCode).HasColumnType("varchar(200)");
            builder.Property(e => e.StockMovementUomCode).HasColumnType("varchar(200)");
            builder.Property(e => e.StoringUomCode).HasColumnType("varchar(200)");
            builder.Property(e => e.StrengthCode).HasColumnType("varchar(200)");
            builder.Property(e => e.SupplierCode).HasColumnType("varchar(200)");
            builder.Property(e => e.ThemeCode).HasColumnType("varchar(200)");
            builder.Property(e => e.UomCode).HasColumnType("varchar(200)");
            builder.Property(e => e.BuyerDivisionSupplierName).HasMaxLength(200);
            builder.Property(e => e.BuyerName).HasMaxLength(200);
            builder.Property(e => e.BuyingCurrencyName).HasMaxLength(200);
            builder.Property(e => e.ColorGroupName).HasMaxLength(200);
            builder.Property(e => e.ColorTypeName).HasMaxLength(200);
            builder.Property(e => e.ConsUomName).HasMaxLength(200);
            builder.Property(e => e.ConstructionName).HasMaxLength(200);
            builder.Property(e => e.ContentName).HasMaxLength(200);
            builder.Property(e => e.CountName).HasMaxLength(200);
            builder.Property(e => e.CropSeasonName).HasMaxLength(200);
            builder.Property(e => e.DivisionName).HasMaxLength(200);
            builder.Property(e => e.FiberTypeName).HasMaxLength(200);
            builder.Property(e => e.GenderName).HasMaxLength(200);
            builder.Property(e => e.GradeName).HasMaxLength(200);
            builder.Property(e => e.MicronaireName).HasMaxLength(200);
            builder.Property(e => e.OriginName).HasMaxLength(200);
            builder.Property(e => e.OurContactName).HasMaxLength(200);
            builder.Property(e => e.PerSizeConsName).HasMaxLength(200);
            builder.Property(e => e.PricePerName).HasMaxLength(200);
            builder.Property(e => e.ProductCatName).HasMaxLength(200);
            builder.Property(e => e.ProductSubCatName).HasMaxLength(200);
            builder.Property(e => e.ProductGroupName).HasMaxLength(200);
            builder.Property(e => e.SecondaryUomName).HasMaxLength(200);
            builder.Property(e => e.StoringUomName).HasMaxLength(200);
            builder.Property(e => e.QualityName).HasMaxLength(200);
            builder.Property(e => e.SeasonName).HasMaxLength(200);
            builder.Property(e => e.SizeGroupName).HasMaxLength(200);
            builder.Property(e => e.StapleName).HasMaxLength(200);
            builder.Property(e => e.StockMovementUomName).HasMaxLength(200);
            builder.Property(e => e.StrengthName).HasMaxLength(200);
            builder.Property(e => e.SupplierName).HasMaxLength(200);
            builder.Property(e => e.ThemeName).HasMaxLength(200);
            builder.Property(e => e.UomName).HasMaxLength(200);
            builder.Property(e => e.ApproveUserId).HasMaxLength(200);
            builder.Property(e => e.ApproveName).HasMaxLength(200);

            builder.Property(e => e.CatalogPath).HasColumnType("varchar(200)");
            builder.Property(e => e.DesignAndPattern).HasColumnType("varchar(200)");
            builder.Property(e => e.DesignAndPatternName).HasMaxLength(500);
            builder.Property(e => e.InternalPrice).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MinimumOrder).HasColumnType("decimal(28,8)");
            builder.Property(e => e.Finish).HasColumnType("varchar(200)");
            builder.Property(e => e.HSNCode).HasColumnType("varchar(200)");
            builder.Property(e => e.RequirementMultiple).HasColumnType("varchar(200)");
            builder.Property(e => e.HTSCode).HasColumnType("varchar(200)");
            builder.Property(e => e.HSNCode).HasColumnType("varchar(200)");
            builder.Property(e => e.Weight).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MinimumQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MaximumQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.MinimumOrderQty).HasColumnType("decimal(28,8)");
            builder.Property(e => e.ArticleNameChinese).HasColumnType("varchar(200)");
            builder.Property(e => e.FabricAndMaterial).HasColumnType("varchar(200)");
            builder.Property(e => e.MaterialTypeCode).HasMaxLength(200);
            builder.Property(e => e.MaterialTypeName).HasMaxLength(500);
            builder.Property(e => e.ArticleCode).HasMaxLength(200);
        }
    }
}