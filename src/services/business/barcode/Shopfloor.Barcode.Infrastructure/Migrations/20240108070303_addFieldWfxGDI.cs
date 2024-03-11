using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addFieldWfxGDI : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WFXArticleName",
                table: "WfxGDI",
                newName: "ArticleName");

            migrationBuilder.RenameColumn(
                name: "WFXArticleCode",
                table: "WfxGDI",
                newName: "ArticleCode");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "WfxGDI",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ParentLocationId",
                table: "Location",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "LevelLocation",
                table: "Location",
                type: "tinyint",
                nullable: true,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "WfxGDI");

            migrationBuilder.RenameColumn(
                name: "ArticleName",
                table: "WfxGDI",
                newName: "WFXArticleName");

            migrationBuilder.RenameColumn(
                name: "ArticleCode",
                table: "WfxGDI",
                newName: "WFXArticleCode");

            migrationBuilder.AlterColumn<int>(
                name: "ParentLocationId",
                table: "Location",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "LevelLocation",
                table: "Location",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0,
                oldClrType: typeof(byte),
                oldType: "tinyint",
                oldNullable: true);
        }
    }
}
