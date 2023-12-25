using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationLibBOLs_SewingMacroLibId",
                table: "SewingOperationLibBOLs",
                column: "SewingMacroLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationBOL_SewingMacroId",
                table: "SewingOperationBOL",
                column: "SewingMacroId");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingOperationBOL_SewingMacro_SewingMacroId",
                table: "SewingOperationBOL",
                column: "SewingMacroId",
                principalTable: "SewingMacro",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingOperationLibBOLs_SewingMacroLib_SewingMacroLibId",
                table: "SewingOperationLibBOLs",
                column: "SewingMacroLibId",
                principalTable: "SewingMacroLib",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingOperationBOL_SewingMacro_SewingMacroId",
                table: "SewingOperationBOL");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingOperationLibBOLs_SewingMacroLib_SewingMacroLibId",
                table: "SewingOperationLibBOLs");

            migrationBuilder.DropIndex(
                name: "IX_SewingOperationLibBOLs_SewingMacroLibId",
                table: "SewingOperationLibBOLs");

            migrationBuilder.DropIndex(
                name: "IX_SewingOperationBOL_SewingMacroId",
                table: "SewingOperationBOL");
        }
    }
}
