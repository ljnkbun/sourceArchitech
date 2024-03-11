using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addfieldforWfxPOArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemberCompanyName",
                table: "WfxPOArticle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductSubCat",
                table: "WfxPOArticle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RMPOCreationMonth",
                table: "WfxPOArticle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RMPOCreationYear",
                table: "WfxPOArticle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "WfxPOArticle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Traceable",
                table: "WfxPOArticle",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberCompanyName",
                table: "WfxPOArticle");

            migrationBuilder.DropColumn(
                name: "ProductSubCat",
                table: "WfxPOArticle");

            migrationBuilder.DropColumn(
                name: "RMPOCreationMonth",
                table: "WfxPOArticle");

            migrationBuilder.DropColumn(
                name: "RMPOCreationYear",
                table: "WfxPOArticle");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "WfxPOArticle");

            migrationBuilder.DropColumn(
                name: "Traceable",
                table: "WfxPOArticle");
        }
    }
}
