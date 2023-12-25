using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintArticleBarcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArticleName",
                table: "ImportTransferToSiteArticle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArticleBarcode_Barcode",
                table: "ArticleBarcode",
                column: "Barcode",
                unique: true,
                filter: "[Barcode] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ArticleBarcode_Barcode",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "ArticleName",
                table: "ImportTransferToSiteArticle");
        }
    }
}
