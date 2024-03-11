using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSlotIndexIntoWeavingRappoMatric : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeavingYarn_WeavingRappo_WeavingRappoId",
                table: "WeavingYarn");

            migrationBuilder.DropIndex(
                name: "IX_WeavingYarn_WeavingRappoId",
                table: "WeavingYarn");

            migrationBuilder.DropColumn(
                name: "WeavingRappoId",
                table: "WeavingYarn");

            migrationBuilder.AddColumn<int>(
                name: "SlotIndex",
                table: "WeavingRappoMatric",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlotIndex",
                table: "WeavingRappoMatric");

            migrationBuilder.AddColumn<int>(
                name: "WeavingRappoId",
                table: "WeavingYarn",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeavingYarn_WeavingRappoId",
                table: "WeavingYarn",
                column: "WeavingRappoId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeavingYarn_WeavingRappo_WeavingRappoId",
                table: "WeavingYarn",
                column: "WeavingRappoId",
                principalTable: "WeavingRappo",
                principalColumn: "Id");
        }
    }
}
