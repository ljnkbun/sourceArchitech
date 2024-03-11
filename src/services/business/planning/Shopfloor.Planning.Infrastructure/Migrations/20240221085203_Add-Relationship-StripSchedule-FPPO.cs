using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipStripScheduleFPPO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FPPO_StripScheduleId",
                table: "FPPO",
                column: "StripScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_FPPO_StripSchedule_StripScheduleId",
                table: "FPPO",
                column: "StripScheduleId",
                principalTable: "StripSchedule",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FPPO_StripSchedule_StripScheduleId",
                table: "FPPO");

            migrationBuilder.DropIndex(
                name: "IX_FPPO_StripScheduleId",
                table: "FPPO");
        }
    }
}
