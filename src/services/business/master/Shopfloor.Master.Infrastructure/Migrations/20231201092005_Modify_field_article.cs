using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Modify_field_article : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Article_Code",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ArticleFlexFields");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ArticleFlexFields");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ArticleBaseSizes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ArticleBaseSizes");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ArticleBaseColors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ArticleBaseColors");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Article");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ArticleFlexFields",
                newName: "AttributeValue");

            migrationBuilder.RenameColumn(
                name: "WfxColorId",
                table: "ArticleBaseColors",
                newName: "WFXColorId");

            migrationBuilder.RenameColumn(
                name: "WfxArticleId",
                table: "Article",
                newName: "WFXArticleId");

            migrationBuilder.RenameColumn(
                name: "SubCategoryCode",
                table: "Article",
                newName: "ProductSubCategory");

            migrationBuilder.RenameColumn(
                name: "ProductGroupCode",
                table: "Article",
                newName: "ProductGroup");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Article",
                newName: "StockTypeName");

            migrationBuilder.RenameColumn(
                name: "MaterialTypeCode",
                table: "Article",
                newName: "MaterialType");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Article",
                newName: "PackingTypeName");

            migrationBuilder.RenameColumn(
                name: "CategoryCode",
                table: "Article",
                newName: "Category");

            migrationBuilder.AddColumn<string>(
                name: "AttributeName",
                table: "ArticleFlexFields",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeCode",
                table: "ArticleBaseSizes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeName",
                table: "ArticleBaseSizes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WFXColorId",
                table: "ArticleBaseColors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                table: "ArticleBaseColors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorName",
                table: "ArticleBaseColors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SellingPrice",
                table: "Article",
                type: "decimal(28,8)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "SAM",
                table: "Article",
                type: "decimal(28,8)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "RequirementMultiple",
                table: "Article",
                type: "decimal(28,8)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AlterColumn<string>(
                name: "PerSizeCons",
                table: "Article",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<decimal>(
                name: "OrderQtyMultiple",
                table: "Article",
                type: "decimal(28,8)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MinimumQty",
                table: "Article",
                type: "decimal(28,8)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MinimumOrderQty",
                table: "Article",
                type: "decimal(28,8)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaximumQty",
                table: "Article",
                type: "decimal(28,8)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Article",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "BuyingPrice",
                table: "Article",
                type: "decimal(28,8)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AddColumn<string>(
                name: "ArticleCode",
                table: "Article",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleDesc",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleName",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MYear",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModelNo",
                table: "Article",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ReOrderLevel",
                table: "Article",
                type: "decimal(28,8)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttributeName",
                table: "ArticleFlexFields");

            migrationBuilder.DropColumn(
                name: "SizeCode",
                table: "ArticleBaseSizes");

            migrationBuilder.DropColumn(
                name: "SizeName",
                table: "ArticleBaseSizes");

            migrationBuilder.DropColumn(
                name: "ColorCode",
                table: "ArticleBaseColors");

            migrationBuilder.DropColumn(
                name: "ColorName",
                table: "ArticleBaseColors");

            migrationBuilder.DropColumn(
                name: "ArticleCode",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ArticleDesc",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ArticleName",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "MYear",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ModelNo",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ReOrderLevel",
                table: "Article");

            migrationBuilder.RenameColumn(
                name: "AttributeValue",
                table: "ArticleFlexFields",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "WFXColorId",
                table: "ArticleBaseColors",
                newName: "WfxColorId");

            migrationBuilder.RenameColumn(
                name: "WFXArticleId",
                table: "Article",
                newName: "WfxArticleId");

            migrationBuilder.RenameColumn(
                name: "StockTypeName",
                table: "Article",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ProductSubCategory",
                table: "Article",
                newName: "SubCategoryCode");

            migrationBuilder.RenameColumn(
                name: "ProductGroup",
                table: "Article",
                newName: "ProductGroupCode");

            migrationBuilder.RenameColumn(
                name: "PackingTypeName",
                table: "Article",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "MaterialType",
                table: "Article",
                newName: "MaterialTypeCode");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Article",
                newName: "CategoryCode");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ArticleFlexFields",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ArticleFlexFields",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ArticleBaseSizes",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ArticleBaseSizes",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WfxColorId",
                table: "ArticleBaseColors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ArticleBaseColors",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ArticleBaseColors",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SellingPrice",
                table: "Article",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SAM",
                table: "Article",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "RequirementMultiple",
                table: "Article",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "PerSizeCons",
                table: "Article",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "OrderQtyMultiple",
                table: "Article",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MinimumQty",
                table: "Article",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MinimumOrderQty",
                table: "Article",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MaximumQty",
                table: "Article",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BuyingPrice",
                table: "Article",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Article",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Article_Code",
                table: "Article",
                column: "Code",
                unique: true);
        }
    }
}
