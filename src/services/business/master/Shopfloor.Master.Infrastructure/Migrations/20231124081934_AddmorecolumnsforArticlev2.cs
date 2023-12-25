using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddmorecolumnsforArticlev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "PerSizeCons",
                table: "Article",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerDepartmentName",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerStyleRef",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorDefinition",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DivisionName",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FabricMaterial",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "HSCode",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MinimumOrderQty",
                table: "Article",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Reference",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RequirementMultiple",
                table: "Article",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SAM",
                table: "Article",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Season",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SellingPrice",
                table: "Article",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SellingPriceCurrency",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StyleType",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerDepartmentName",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "BuyerStyleRef",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ColorDefinition",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "DivisionName",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "FabricMaterial",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "HSCode",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "MinimumOrderQty",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Reference",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "RequirementMultiple",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "SAM",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "SellingPrice",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "SellingPriceCurrency",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "StyleType",
                table: "Article");

            migrationBuilder.AlterColumn<string>(
                name: "PerSizeCons",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
