using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdjustTableStripFactoryDetailChangeDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StripFactoryDetail_PORDetail_PorDetailId",
                table: "StripFactoryDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_StripFactoryDetail_StripFactory_StripFactoryId",
                table: "StripFactoryDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_StripFactorySchedule_StripFactory_StripFactoryId",
                table: "StripFactorySchedule");

            migrationBuilder.DropIndex(
                name: "IX_StripFactoryDetail_PorDetailId",
                table: "StripFactoryDetail");

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactoryDetail_StripFactory_StripFactoryId",
                table: "StripFactoryDetail",
                column: "StripFactoryId",
                principalTable: "StripFactory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactorySchedule_StripFactory_StripFactoryId",
                table: "StripFactorySchedule",
                column: "StripFactoryId",
                principalTable: "StripFactory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StripFactoryDetail_StripFactory_StripFactoryId",
                table: "StripFactoryDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_StripFactorySchedule_StripFactory_StripFactoryId",
                table: "StripFactorySchedule");

            migrationBuilder.CreateIndex(
                name: "IX_StripFactoryDetail_PorDetailId",
                table: "StripFactoryDetail",
                column: "PorDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactoryDetail_PORDetail_PorDetailId",
                table: "StripFactoryDetail",
                column: "PorDetailId",
                principalTable: "PORDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactoryDetail_StripFactory_StripFactoryId",
                table: "StripFactoryDetail",
                column: "StripFactoryId",
                principalTable: "StripFactory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactorySchedule_StripFactory_StripFactoryId",
                table: "StripFactorySchedule",
                column: "StripFactoryId",
                principalTable: "StripFactory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
