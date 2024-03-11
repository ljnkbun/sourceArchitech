using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsSewingTaskLib : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "RequestDivision");

            migrationBuilder.AddColumn<int>(
                name: "SewingMachineEfficiencyProfileId",
                table: "SewingTaskLib",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "RequestArticleOutput",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_SewingTaskLib_SewingMachineEfficiencyProfileId",
                table: "SewingTaskLib",
                column: "SewingMachineEfficiencyProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingTaskLib_SewingMachineEfficiencyProfile_SewingMachineEfficiencyProfileId",
                table: "SewingTaskLib",
                column: "SewingMachineEfficiencyProfileId",
                principalTable: "SewingMachineEfficiencyProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingTaskLib_SewingMachineEfficiencyProfile_SewingMachineEfficiencyProfileId",
                table: "SewingTaskLib");

            migrationBuilder.DropIndex(
                name: "IX_SewingTaskLib_SewingMachineEfficiencyProfileId",
                table: "SewingTaskLib");

            migrationBuilder.DropColumn(
                name: "SewingMachineEfficiencyProfileId",
                table: "SewingTaskLib");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "RequestArticleOutput");

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "RequestDivision",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
