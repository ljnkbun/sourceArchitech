using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTypeColumnCodeToId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoqRoundingType",
                table: "SupplierWisePurchaseOption");

            migrationBuilder.DropColumn(
                name: "SupplierCode",
                table: "SupplierWisePurchaseOption");

            migrationBuilder.DropColumn(
                name: "ColorType",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ConsUom",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "CropSeason",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "DivisionCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "FiberType",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "Micronaire",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "OrderQtyMultiple",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "OurContact",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "PerSizeCons",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "PricePer",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ProductGroup",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "Quality",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "SecondaryUom",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "Staple",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "StockMovementUom",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "StoringUom",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "Strength",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "Theme",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "Uom",
                table: "MaterialRequest");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "MaterialRequest",
                newName: "UomId");

            migrationBuilder.AddColumn<string>(
                name: "MoqRoundingTypeId",
                table: "SupplierWisePurchaseOption",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierId",
                table: "SupplierWisePurchaseOption",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuyerDivisionSupplier",
                table: "MaterialRequest",
                type: "int",
                maxLength: 500,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Buyer",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleCode",
                table: "MaterialRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorTypeId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ConsUomId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CropSeasonId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DivisionId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FiberTypeId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MicronaireId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "OrderQtyMultipleId",
                table: "MaterialRequest",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OurContactId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PerSizeConsId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PricePerId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductGroupId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QualityId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryUomId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StapleId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StockMovementUomId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StoringUomId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StrengthId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThemeId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoqRoundingTypeId",
                table: "SupplierWisePurchaseOption");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "SupplierWisePurchaseOption");

            migrationBuilder.DropColumn(
                name: "ArticleCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ColorTypeId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ConsUomId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "CropSeasonId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "DivisionId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "FiberTypeId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "MicronaireId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "OrderQtyMultipleId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "OurContactId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "PerSizeConsId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "PricePerId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ProductGroupId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "QualityId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "SecondaryUomId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "StapleId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "StockMovementUomId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "StoringUomId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "StrengthId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ThemeId",
                table: "MaterialRequest");

            migrationBuilder.RenameColumn(
                name: "UomId",
                table: "MaterialRequest",
                newName: "ArticleId");

            migrationBuilder.AddColumn<string>(
                name: "MoqRoundingType",
                table: "SupplierWisePurchaseOption",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierCode",
                table: "SupplierWisePurchaseOption",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "BuyerDivisionSupplier",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Buyer",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ColorType",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsUom",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CropSeason",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DivisionCode",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FiberType",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Micronaire",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OrderQtyMultiple",
                table: "MaterialRequest",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OurContact",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PerSizeCons",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PricePer",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductGroup",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quality",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Season",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondaryUom",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Staple",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockMovementUom",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoringUom",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Strength",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Uom",
                table: "MaterialRequest",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
