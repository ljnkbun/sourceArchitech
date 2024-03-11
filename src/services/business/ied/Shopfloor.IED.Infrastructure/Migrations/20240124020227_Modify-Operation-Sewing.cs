using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyOperationSewing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TMUType",
                table: "SewingOperationLibResult",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "BasicMunite",
                table: "SewingOperationLibResult",
                newName: "BasicMinute");

            migrationBuilder.RenameIndex(
                name: "IX_SewingOperationLibResult_SewingOperationLibId_TMUType",
                table: "SewingOperationLibResult",
                newName: "IX_SewingOperationLibResult_SewingOperationLibId_Type");

            migrationBuilder.AddColumn<decimal>(
                name: "BundleTime",
                table: "SewingOperationLibBOL",
                type: "decimal(28,8)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BundleTime",
                table: "SewingOperationLibBOL");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "SewingOperationLibResult",
                newName: "TMUType");

            migrationBuilder.RenameColumn(
                name: "BasicMinute",
                table: "SewingOperationLibResult",
                newName: "BasicMunite");

            migrationBuilder.RenameIndex(
                name: "IX_SewingOperationLibResult_SewingOperationLibId_Type",
                table: "SewingOperationLibResult",
                newName: "IX_SewingOperationLibResult_SewingOperationLibId_TMUType");
        }
    }
}
