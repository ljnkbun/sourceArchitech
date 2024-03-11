using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifySewingRoutingBOL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingRoutingBOL_SewingFeature_SewingFeatureId",
                table: "SewingRoutingBOL");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingRoutingBOL_SewingOperation_SewingOperationId",
                table: "SewingRoutingBOL");

            migrationBuilder.RenameColumn(
                name: "SewingOperationId",
                table: "SewingRoutingBOL",
                newName: "SewingOperationLibId");

            migrationBuilder.RenameColumn(
                name: "SewingFeatureId",
                table: "SewingRoutingBOL",
                newName: "SewingFeatureLibId");

            migrationBuilder.RenameIndex(
                name: "IX_SewingRoutingBOL_SewingOperationId",
                table: "SewingRoutingBOL",
                newName: "IX_SewingRoutingBOL_SewingOperationLibId");

            migrationBuilder.RenameIndex(
                name: "IX_SewingRoutingBOL_SewingFeatureId",
                table: "SewingRoutingBOL",
                newName: "IX_SewingRoutingBOL_SewingFeatureLibId");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingRoutingBOL_SewingFeatureLib_SewingFeatureLibId",
                table: "SewingRoutingBOL",
                column: "SewingFeatureLibId",
                principalTable: "SewingFeatureLib",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingRoutingBOL_SewingOperationLib_SewingOperationLibId",
                table: "SewingRoutingBOL",
                column: "SewingOperationLibId",
                principalTable: "SewingOperationLib",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingRoutingBOL_SewingFeatureLib_SewingFeatureLibId",
                table: "SewingRoutingBOL");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingRoutingBOL_SewingOperationLib_SewingOperationLibId",
                table: "SewingRoutingBOL");

            migrationBuilder.RenameColumn(
                name: "SewingOperationLibId",
                table: "SewingRoutingBOL",
                newName: "SewingOperationId");

            migrationBuilder.RenameColumn(
                name: "SewingFeatureLibId",
                table: "SewingRoutingBOL",
                newName: "SewingFeatureId");

            migrationBuilder.RenameIndex(
                name: "IX_SewingRoutingBOL_SewingOperationLibId",
                table: "SewingRoutingBOL",
                newName: "IX_SewingRoutingBOL_SewingOperationId");

            migrationBuilder.RenameIndex(
                name: "IX_SewingRoutingBOL_SewingFeatureLibId",
                table: "SewingRoutingBOL",
                newName: "IX_SewingRoutingBOL_SewingFeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingRoutingBOL_SewingFeature_SewingFeatureId",
                table: "SewingRoutingBOL",
                column: "SewingFeatureId",
                principalTable: "SewingFeature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingRoutingBOL_SewingOperation_SewingOperationId",
                table: "SewingRoutingBOL",
                column: "SewingOperationId",
                principalTable: "SewingOperation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
