using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeavingIED_RequestArticleOutput_RequestArticleOutputId",
                table: "WeavingIED");

            migrationBuilder.DropIndex(
                name: "IX_WeavingIED_RequestArticleOutputId",
                table: "WeavingIED");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingIED_RequestArticleOutputId",
                table: "WeavingIED",
                column: "RequestArticleOutputId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeavingIED_RequestArticleOutput_RequestArticleOutputId",
                table: "WeavingIED",
                column: "RequestArticleOutputId",
                principalTable: "RequestArticleOutput",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WeavingIED_RequestArticleOutput_RequestArticleOutputId",
                table: "WeavingIED");

            migrationBuilder.DropIndex(
                name: "IX_WeavingIED_RequestArticleOutputId",
                table: "WeavingIED");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingIED_RequestArticleOutputId",
                table: "WeavingIED",
                column: "RequestArticleOutputId");

            migrationBuilder.AddForeignKey(
                name: "FK_WeavingIED_RequestArticleOutput_RequestArticleOutputId",
                table: "WeavingIED",
                column: "RequestArticleOutputId",
                principalTable: "RequestArticleOutput",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
