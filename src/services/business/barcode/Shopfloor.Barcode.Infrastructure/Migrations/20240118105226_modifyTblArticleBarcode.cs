using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyTblArticleBarcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InternalShade",
                table: "ExportDetail");

            migrationBuilder.RenameColumn(
                name: "RollUnits",
                table: "ExportDetail",
                newName: "RemainQuantity");

            migrationBuilder.RenameColumn(
                name: "RollOCRefNum",
                table: "ExportDetail",
                newName: "OCRefNum");

            migrationBuilder.RenameColumn(
                name: "RollNo",
                table: "ExportDetail",
                newName: "ParentBarcode");

            migrationBuilder.RenameColumn(
                name: "RollBarcode",
                table: "ExportDetail",
                newName: "No");

            migrationBuilder.RenameColumn(
                name: "ParentRollBarcode",
                table: "ExportDetail",
                newName: "Barcode");

            migrationBuilder.RenameColumn(
                name: "GDIPendingUnits",
                table: "ExportDetail",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "ArticleBarcode",
                newName: "GDINum");

            migrationBuilder.AddColumn<decimal>(
                name: "BGroupQty",
                table: "ArticleBarcode",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "ArticleBarcode",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FPPOOCNUm",
                table: "ArticleBarcode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FPPOQty",
                table: "ArticleBarcode",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OKQty",
                table: "ArticleBarcode",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderRefNum",
                table: "ArticleBarcode",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RejectQty",
                table: "ArticleBarcode",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UpdatedToDate",
                table: "ArticleBarcode",
                type: "decimal(28,8)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BGroupQty",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "FPPOOCNUm",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "FPPOQty",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "OKQty",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "OrderRefNum",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "RejectQty",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "UpdatedToDate",
                table: "ArticleBarcode");

            migrationBuilder.RenameColumn(
                name: "RemainQuantity",
                table: "ExportDetail",
                newName: "RollUnits");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ExportDetail",
                newName: "GDIPendingUnits");

            migrationBuilder.RenameColumn(
                name: "ParentBarcode",
                table: "ExportDetail",
                newName: "RollNo");

            migrationBuilder.RenameColumn(
                name: "OCRefNum",
                table: "ExportDetail",
                newName: "RollOCRefNum");

            migrationBuilder.RenameColumn(
                name: "No",
                table: "ExportDetail",
                newName: "RollBarcode");

            migrationBuilder.RenameColumn(
                name: "Barcode",
                table: "ExportDetail",
                newName: "ParentRollBarcode");

            migrationBuilder.RenameColumn(
                name: "GDINum",
                table: "ArticleBarcode",
                newName: "Unit");

            migrationBuilder.AddColumn<string>(
                name: "InternalShade",
                table: "ExportDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
