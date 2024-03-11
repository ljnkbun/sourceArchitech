using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addfieldBarcode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "NumberOfCone",
                table: "ImportDetail",
                type: "decimal(28,8)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "ExportDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LotNo",
                table: "ExportDetail",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NumberOfCone",
                table: "ExportDetail",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ExportArticle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "ArticleBarcode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LotNo",
                table: "ArticleBarcode",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                table: "ExportDetail");

            migrationBuilder.DropColumn(
                name: "LotNo",
                table: "ExportDetail");

            migrationBuilder.DropColumn(
                name: "NumberOfCone",
                table: "ExportDetail");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ExportArticle");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "LotNo",
                table: "ArticleBarcode");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfCone",
                table: "ImportDetail",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)",
                oldNullable: true);
        }
    }
}
