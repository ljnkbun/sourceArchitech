using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationshipWeavingIED : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WeavingRusticFabricSpec_WeavingIEDId",
                table: "WeavingRusticFabricSpec");

            migrationBuilder.DropIndex(
                name: "IX_WeavingRappo_WeavingIEDId",
                table: "WeavingRappo");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRusticFabricSpec_WeavingIEDId",
                table: "WeavingRusticFabricSpec",
                column: "WeavingIEDId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRappo_WeavingIEDId",
                table: "WeavingRappo",
                column: "WeavingIEDId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WeavingRusticFabricSpec_WeavingIEDId",
                table: "WeavingRusticFabricSpec");

            migrationBuilder.DropIndex(
                name: "IX_WeavingRappo_WeavingIEDId",
                table: "WeavingRappo");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRusticFabricSpec_WeavingIEDId",
                table: "WeavingRusticFabricSpec",
                column: "WeavingIEDId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRappo_WeavingIEDId",
                table: "WeavingRappo",
                column: "WeavingIEDId");
        }
    }
}
