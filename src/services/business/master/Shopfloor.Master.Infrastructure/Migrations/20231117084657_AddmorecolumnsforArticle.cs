using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddmorecolumnsforArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BaseColorList",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BaseSizeList",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyingCurrencyCode",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BuyingPrice",
                table: "Article",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CategoryCode",
                table: "Article",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorCard",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConsumptionUOM",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaterialTypeCode",
                table: "Article",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaximumQty",
                table: "Article",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinimumQty",
                table: "Article",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OrderQtyMultiple",
                table: "Article",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "OurContact",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PerSizeCons",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PricePer",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductGroupCode",
                table: "Article",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchaseUOM",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RestrictedItem",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeWidthRange",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoringUOM",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCategoryCode",
                table: "Article",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseColorList",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "BaseSizeList",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Buyer",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "BuyingCurrencyCode",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "BuyingPrice",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "CategoryCode",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ColorCard",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ConsumptionUOM",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "MaterialTypeCode",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "MaximumQty",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "MinimumQty",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "OrderQtyMultiple",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "OurContact",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "PerSizeCons",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "PricePer",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ProductGroupCode",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "PurchaseUOM",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "RestrictedItem",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "SizeWidthRange",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "StoringUOM",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "SubCategoryCode",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "Article");
        }
    }
}
