using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSewingBundleIdSewingTaskLib : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SewingBundleId",
                table: "SewingTaskLib",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SewingTaskLib_SewingBundleId",
                table: "SewingTaskLib",
                column: "SewingBundleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingTaskLib_SewingBundle_SewingBundleId",
                table: "SewingTaskLib",
                column: "SewingBundleId",
                principalTable: "SewingBundle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingTaskLib_SewingBundle_SewingBundleId",
                table: "SewingTaskLib");

            migrationBuilder.DropIndex(
                name: "IX_SewingTaskLib_SewingBundleId",
                table: "SewingTaskLib");

            migrationBuilder.DropColumn(
                name: "SewingBundleId",
                table: "SewingTaskLib");
        }
    }
}
