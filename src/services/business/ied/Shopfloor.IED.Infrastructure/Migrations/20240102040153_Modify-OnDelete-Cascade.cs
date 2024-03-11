using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyOnDeleteCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingFeatureBOL_SewingFeature_SewingFeatureId",
                table: "SewingFeatureBOL");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingFeatureLibBOL_SewingFeatureLib_SewingFeatureLibId",
                table: "SewingFeatureLibBOL");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingMacroBOL_SewingMacro_SewingMacroId",
                table: "SewingMacroBOL");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingMacroLibBOL_SewingMacroLib_SewingMacroLibId",
                table: "SewingMacroLibBOL");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingOperationBOL_SewingOperation_SewingOperationId",
                table: "SewingOperationBOL");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingOperationLibBOL_SewingOperationLib_SewingOperationLibId",
                table: "SewingOperationLibBOL");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingSubOperationWFXBOL_SewingSubOperationWFX_SewingSubOperationWFXId",
                table: "SewingSubOperationWFXBOL");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingFeatureBOL_SewingFeature_SewingFeatureId",
                table: "SewingFeatureBOL",
                column: "SewingFeatureId",
                principalTable: "SewingFeature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingFeatureLibBOL_SewingFeatureLib_SewingFeatureLibId",
                table: "SewingFeatureLibBOL",
                column: "SewingFeatureLibId",
                principalTable: "SewingFeatureLib",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingMacroBOL_SewingMacro_SewingMacroId",
                table: "SewingMacroBOL",
                column: "SewingMacroId",
                principalTable: "SewingMacro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingMacroLibBOL_SewingMacroLib_SewingMacroLibId",
                table: "SewingMacroLibBOL",
                column: "SewingMacroLibId",
                principalTable: "SewingMacroLib",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingOperationBOL_SewingOperation_SewingOperationId",
                table: "SewingOperationBOL",
                column: "SewingOperationId",
                principalTable: "SewingOperation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingOperationLibBOL_SewingOperationLib_SewingOperationLibId",
                table: "SewingOperationLibBOL",
                column: "SewingOperationLibId",
                principalTable: "SewingOperationLib",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingSubOperationWFXBOL_SewingSubOperationWFX_SewingSubOperationWFXId",
                table: "SewingSubOperationWFXBOL",
                column: "SewingSubOperationWFXId",
                principalTable: "SewingSubOperationWFX",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingFeatureBOL_SewingFeature_SewingFeatureId",
                table: "SewingFeatureBOL");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingFeatureLibBOL_SewingFeatureLib_SewingFeatureLibId",
                table: "SewingFeatureLibBOL");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingMacroBOL_SewingMacro_SewingMacroId",
                table: "SewingMacroBOL");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingMacroLibBOL_SewingMacroLib_SewingMacroLibId",
                table: "SewingMacroLibBOL");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingOperationBOL_SewingOperation_SewingOperationId",
                table: "SewingOperationBOL");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingOperationLibBOL_SewingOperationLib_SewingOperationLibId",
                table: "SewingOperationLibBOL");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingSubOperationWFXBOL_SewingSubOperationWFX_SewingSubOperationWFXId",
                table: "SewingSubOperationWFXBOL");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingFeatureBOL_SewingFeature_SewingFeatureId",
                table: "SewingFeatureBOL",
                column: "SewingFeatureId",
                principalTable: "SewingFeature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingFeatureLibBOL_SewingFeatureLib_SewingFeatureLibId",
                table: "SewingFeatureLibBOL",
                column: "SewingFeatureLibId",
                principalTable: "SewingFeatureLib",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingMacroBOL_SewingMacro_SewingMacroId",
                table: "SewingMacroBOL",
                column: "SewingMacroId",
                principalTable: "SewingMacro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingMacroLibBOL_SewingMacroLib_SewingMacroLibId",
                table: "SewingMacroLibBOL",
                column: "SewingMacroLibId",
                principalTable: "SewingMacroLib",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingOperationBOL_SewingOperation_SewingOperationId",
                table: "SewingOperationBOL",
                column: "SewingOperationId",
                principalTable: "SewingOperation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingOperationLibBOL_SewingOperationLib_SewingOperationLibId",
                table: "SewingOperationLibBOL",
                column: "SewingOperationLibId",
                principalTable: "SewingOperationLib",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingSubOperationWFXBOL_SewingSubOperationWFX_SewingSubOperationWFXId",
                table: "SewingSubOperationWFXBOL",
                column: "SewingSubOperationWFXId",
                principalTable: "SewingSubOperationWFX",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
