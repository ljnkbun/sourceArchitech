using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifySewingMacroLib : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingTaskLib_SewingComponentGroup_SewingComponentGroupId",
                table: "SewingTaskLib");

            migrationBuilder.DropIndex(
                name: "IX_SewingTaskLib_SewingComponentGroupId",
                table: "SewingTaskLib");

            migrationBuilder.DropColumn(
                name: "SewingComponentGroupId",
                table: "SewingTaskLib");

            migrationBuilder.AddColumn<int>(
                name: "SewingComponentGroupId",
                table: "SewingMacroLib",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SewingMacroLib_SewingComponentGroupId",
                table: "SewingMacroLib",
                column: "SewingComponentGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingMacroLib_SewingComponentGroup_SewingComponentGroupId",
                table: "SewingMacroLib",
                column: "SewingComponentGroupId",
                principalTable: "SewingComponentGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingMacroLib_SewingComponentGroup_SewingComponentGroupId",
                table: "SewingMacroLib");

            migrationBuilder.DropIndex(
                name: "IX_SewingMacroLib_SewingComponentGroupId",
                table: "SewingMacroLib");

            migrationBuilder.DropColumn(
                name: "SewingComponentGroupId",
                table: "SewingMacroLib");

            migrationBuilder.AddColumn<int>(
                name: "SewingComponentGroupId",
                table: "SewingTaskLib",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SewingTaskLib_SewingComponentGroupId",
                table: "SewingTaskLib",
                column: "SewingComponentGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingTaskLib_SewingComponentGroup_SewingComponentGroupId",
                table: "SewingTaskLib",
                column: "SewingComponentGroupId",
                principalTable: "SewingComponentGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
