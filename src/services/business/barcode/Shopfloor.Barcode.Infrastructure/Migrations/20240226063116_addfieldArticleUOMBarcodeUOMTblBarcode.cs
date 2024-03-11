using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addfieldArticleUOMBarcodeUOMTblBarcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UOM",
                table: "ArticleBarcode",
                newName: "BarcodeUOM");

            migrationBuilder.AddColumn<string>(
                name: "ArticleUOM",
                table: "ArticleBarcode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticleUOM",
                table: "ArticleBarcode");

            migrationBuilder.RenameColumn(
                name: "BarcodeUOM",
                table: "ArticleBarcode",
                newName: "UOM");
        }
    }
}
