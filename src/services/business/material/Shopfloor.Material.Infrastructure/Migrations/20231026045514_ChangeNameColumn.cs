using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MOQSurchargeCurrency",
                table: "SupplierWisePurchaseOption",
                newName: "MoqSurchargeCurrency");

            migrationBuilder.RenameColumn(
                name: "MOQSurChargeValue",
                table: "SupplierWisePurchaseOption",
                newName: "MoqSurChargeValue");

            migrationBuilder.RenameColumn(
                name: "MOQRoundingType",
                table: "SupplierWisePurchaseOption",
                newName: "MoqRoundingType");

            migrationBuilder.RenameColumn(
                name: "MOQ",
                table: "SupplierWisePurchaseOption",
                newName: "Moq");

            migrationBuilder.RenameColumn(
                name: "MCQSurchargeValue",
                table: "SupplierWisePurchaseOption",
                newName: "McqSurchargeValue");

            migrationBuilder.RenameColumn(
                name: "MCQSurchargeCurrency",
                table: "SupplierWisePurchaseOption",
                newName: "McqSurchargeCurrency");

            migrationBuilder.RenameColumn(
                name: "MCQ",
                table: "SupplierWisePurchaseOption",
                newName: "Mcq");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Supplier",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "UOM",
                table: "MaterialRequest",
                newName: "Uom");

            migrationBuilder.RenameColumn(
                name: "StoringUOM",
                table: "MaterialRequest",
                newName: "StoringUom");

            migrationBuilder.RenameColumn(
                name: "SizeGroupID",
                table: "MaterialRequest",
                newName: "SizeGroupId");

            migrationBuilder.RenameColumn(
                name: "SecondaryUOMConversion",
                table: "MaterialRequest",
                newName: "SecondaryUomConversion");

            migrationBuilder.RenameColumn(
                name: "SecondaryUOM",
                table: "MaterialRequest",
                newName: "SecondaryUom");

            migrationBuilder.RenameColumn(
                name: "MaterialTypeID",
                table: "MaterialRequest",
                newName: "MaterialTypeId");

            migrationBuilder.RenameColumn(
                name: "ConsUOM",
                table: "MaterialRequest",
                newName: "ConsUom");

            migrationBuilder.RenameColumn(
                name: "ColorGroupID",
                table: "MaterialRequest",
                newName: "ColorGroupId");

            migrationBuilder.RenameColumn(
                name: "SupplierCode",
                table: "MaterialRequest",
                newName: "SupplierId");

            migrationBuilder.RenameColumn(
                name: "ProductSubCatCode",
                table: "MaterialRequest",
                newName: "ProductSubCatId");

            migrationBuilder.RenameColumn(
                name: "ProductCatCode",
                table: "MaterialRequest",
                newName: "ProductCatId");

            migrationBuilder.RenameColumn(
                name: "CountCode",
                table: "MaterialRequest",
                newName: "CountId");

            migrationBuilder.RenameColumn(
                name: "ConstructionCode",
                table: "MaterialRequest",
                newName: "ConstructionId");

            migrationBuilder.RenameColumn(
                name: "BuyingCurrencyCode",
                table: "MaterialRequest",
                newName: "BuyingCurrencyId");

            migrationBuilder.RenameColumn(
                name: "ArticleCode",
                table: "MaterialRequest",
                newName: "ArticleId");

            migrationBuilder.AlterColumn<string>(
                name: "VATNumber",
                table: "Supplier",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AlterColumn<string>(
                name: "Remakes",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MoqSurchargeCurrency",
                table: "SupplierWisePurchaseOption",
                newName: "MOQSurchargeCurrency");

            migrationBuilder.RenameColumn(
                name: "MoqSurChargeValue",
                table: "SupplierWisePurchaseOption",
                newName: "MOQSurChargeValue");

            migrationBuilder.RenameColumn(
                name: "MoqRoundingType",
                table: "SupplierWisePurchaseOption",
                newName: "MOQRoundingType");

            migrationBuilder.RenameColumn(
                name: "Moq",
                table: "SupplierWisePurchaseOption",
                newName: "MOQ");

            migrationBuilder.RenameColumn(
                name: "McqSurchargeValue",
                table: "SupplierWisePurchaseOption",
                newName: "MCQSurchargeValue");

            migrationBuilder.RenameColumn(
                name: "McqSurchargeCurrency",
                table: "SupplierWisePurchaseOption",
                newName: "MCQSurchargeCurrency");

            migrationBuilder.RenameColumn(
                name: "Mcq",
                table: "SupplierWisePurchaseOption",
                newName: "MCQ");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Supplier",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "Uom",
                table: "MaterialRequest",
                newName: "UOM");

            migrationBuilder.RenameColumn(
                name: "StoringUom",
                table: "MaterialRequest",
                newName: "StoringUOM");

            migrationBuilder.RenameColumn(
                name: "SizeGroupId",
                table: "MaterialRequest",
                newName: "SizeGroupID");

            migrationBuilder.RenameColumn(
                name: "SecondaryUomConversion",
                table: "MaterialRequest",
                newName: "SecondaryUOMConversion");

            migrationBuilder.RenameColumn(
                name: "SecondaryUom",
                table: "MaterialRequest",
                newName: "SecondaryUOM");

            migrationBuilder.RenameColumn(
                name: "MaterialTypeId",
                table: "MaterialRequest",
                newName: "MaterialTypeID");

            migrationBuilder.RenameColumn(
                name: "ConsUom",
                table: "MaterialRequest",
                newName: "ConsUOM");

            migrationBuilder.RenameColumn(
                name: "ColorGroupId",
                table: "MaterialRequest",
                newName: "ColorGroupID");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "MaterialRequest",
                newName: "SupplierCode");

            migrationBuilder.RenameColumn(
                name: "ProductSubCatId",
                table: "MaterialRequest",
                newName: "ProductSubCatCode");

            migrationBuilder.RenameColumn(
                name: "ProductCatId",
                table: "MaterialRequest",
                newName: "ProductCatCode");

            migrationBuilder.RenameColumn(
                name: "CountId",
                table: "MaterialRequest",
                newName: "CountCode");

            migrationBuilder.RenameColumn(
                name: "ConstructionId",
                table: "MaterialRequest",
                newName: "ConstructionCode");

            migrationBuilder.RenameColumn(
                name: "BuyingCurrencyId",
                table: "MaterialRequest",
                newName: "BuyingCurrencyCode");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "MaterialRequest",
                newName: "ArticleCode");

            migrationBuilder.AlterColumn<decimal>(
                name: "VATNumber",
                table: "Supplier",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remakes",
                table: "Supplier",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
