using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtypeforfoldertree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "DivisionType",
                table: "FolderTree",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ItemType",
                table: "FolderTree",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DivisionType",
                table: "FolderTree");

            migrationBuilder.DropColumn(
                name: "ItemType",
                table: "FolderTree");
        }
    }
}
