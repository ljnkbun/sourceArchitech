using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumn_WfxStatus_Table_ImportandExport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "WfxStatus",
                table: "Import",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "WfxStatus",
                table: "Export",
                type: "tinyint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WfxStatus",
                table: "Import");

            migrationBuilder.DropColumn(
                name: "WfxStatus",
                table: "Export");
        }
    }
}
