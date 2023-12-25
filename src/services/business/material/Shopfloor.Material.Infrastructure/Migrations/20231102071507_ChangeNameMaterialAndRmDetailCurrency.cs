using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameMaterialAndRmDetailCurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailCurrency");

            migrationBuilder.AlterColumn<string>(
                name: "PicName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContentName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Brand",
                table: "MaterialRequest",
                type: "int",
                maxLength: 500,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrandCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrandName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerDivisionSupplierCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerDivisionSupplierName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyingCurrencyCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyingCurrencyName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorGroupCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorGroupName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorTypeCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorTypeName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsUomCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsUomName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConstructionCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConstructionName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CropSeasonCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CropSeasonName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DivisionCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DivisionName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FiberTypeCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FiberTypeName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GenderCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GenderName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GradeCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GradeName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MicronaireCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MicronaireName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurContactCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurContactName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PerSizeConsCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PerSizeConsName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PricePerCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PricePerName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductCatCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductCatName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductGroupCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductGroupName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductSubCatCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductSubCatName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QualityCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QualityName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeasonCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SeasonName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryUomCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryUomName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeGroupCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeGroupName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StapleCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StapleName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockMovementUomCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockMovementUomName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoringUomCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoringUomName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StrengthCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StrengthName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThemeCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThemeName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UomCode",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UomName",
                table: "MaterialRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrandCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "BrandName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "BuyerCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "BuyerDivisionSupplierCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "BuyerDivisionSupplierName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "BuyerName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "BuyingCurrencyCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "BuyingCurrencyName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ColorGroupCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ColorGroupName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ColorTypeCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ColorTypeName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ConsUomCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ConsUomName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ConstructionCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ConstructionName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "CountCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "CountName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "CropSeasonCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "CropSeasonName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "DivisionCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "DivisionName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "FiberTypeCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "FiberTypeName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "GenderCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "GenderName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "GradeCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "GradeName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "MicronaireCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "MicronaireName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "OriginCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "OriginName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "OurContactCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "OurContactName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "PerSizeConsCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "PerSizeConsName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "PricePerCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "PricePerName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ProductCatCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ProductCatName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ProductGroupCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ProductGroupName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ProductSubCatCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ProductSubCatName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "QualityCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "QualityName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "SeasonCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "SeasonName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "SecondaryUomCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "SecondaryUomName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "SizeGroupCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "SizeGroupName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "StapleCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "StapleName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "StockMovementUomCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "StockMovementUomName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "StoringUomCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "StoringUomName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "StrengthCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "StrengthName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "SupplierCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "SupplierName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ThemeCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ThemeName",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "UomCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "UomName",
                table: "MaterialRequest");

            migrationBuilder.AlterColumn<string>(
                name: "PicName",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ContentName",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 500);

            migrationBuilder.CreateTable(
                name: "DetailCurrency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    From = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    To = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailCurrency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailCurrency_PriceListCurrency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "PriceListCurrency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetailCurrency_CurrencyId",
                table: "DetailCurrency",
                column: "CurrencyId");
        }
    }
}
