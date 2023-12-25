using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteIdMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "Buyer",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "BuyerDivisionSupplier",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "BuyingCurrencyId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ColorGroupId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ColorTypeId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ConsUomId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ConstructionId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "CountId",
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
                name: "Gender",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "MaterialTypeId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "MicronaireId",
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
                name: "ProductCatId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ProductGroupId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ProductSubCatId",
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
                name: "SizeGroupId",
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
                name: "SupplierId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ThemeId",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "UomId",
                table: "MaterialRequest");

            migrationBuilder.RenameColumn(
                name: "OrderQtyMultipleId",
                table: "MaterialRequest",
                newName: "OrderQtyMultiple");

            migrationBuilder.AddColumn<string>(
                name: "MaterialTypeCode",
                table: "MaterialRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaterialTypeName",
                table: "MaterialRequest",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialTypeCode",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "MaterialTypeName",
                table: "MaterialRequest");

            migrationBuilder.RenameColumn(
                name: "OrderQtyMultiple",
                table: "MaterialRequest",
                newName: "OrderQtyMultipleId");

            migrationBuilder.AddColumn<int>(
                name: "Brand",
                table: "MaterialRequest",
                type: "int",
                maxLength: 500,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Buyer",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BuyerDivisionSupplier",
                table: "MaterialRequest",
                type: "int",
                maxLength: 500,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BuyingCurrencyId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ColorGroupId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "ConstructionId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountId",
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
                name: "Gender",
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
                name: "MaterialTypeId",
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
                name: "ProductCatId",
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
                name: "ProductSubCatId",
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
                name: "SizeGroupId",
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
                name: "SupplierId",
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

            migrationBuilder.AddColumn<int>(
                name: "UomId",
                table: "MaterialRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
