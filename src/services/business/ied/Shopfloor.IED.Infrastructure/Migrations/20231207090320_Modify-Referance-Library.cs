using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyReferanceLibrary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingFeatureLibBOLs_SewingFeatureLibs_SewingFeatureLibId",
                table: "SewingFeatureLibBOLs");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingFeatureLibBOLs_SewingOperationLibs_SewingOperationLibId",
                table: "SewingFeatureLibBOLs");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingMacroLibBOLs_SewingMacroLib_SewingMacroLibId",
                table: "SewingMacroLibBOLs");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingMacroLibBOLs_SewingTaskLib_SewingTaskLibId",
                table: "SewingMacroLibBOLs");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingSubOperationWFXBOL_SewingFeature_SewingFeatureId",
                table: "SewingSubOperationWFXBOL");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingSubOperationWFXBOL_SewingOperation_SewingOperationId",
                table: "SewingSubOperationWFXBOL");

            migrationBuilder.AlterColumn<int>(
                name: "SewingOperationId",
                table: "SewingSubOperationWFXBOL",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SewingFeatureId",
                table: "SewingSubOperationWFXBOL",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SewingTaskLibId",
                table: "SewingMacroLibBOLs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SewingMacroLibId",
                table: "SewingMacroLibBOLs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SewingOperationLibId",
                table: "SewingFeatureLibBOLs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SewingFeatureLibId",
                table: "SewingFeatureLibBOLs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingFeatureLibBOLs_SewingFeatureLibs_SewingFeatureLibId",
                table: "SewingFeatureLibBOLs",
                column: "SewingFeatureLibId",
                principalTable: "SewingFeatureLibs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingFeatureLibBOLs_SewingOperationLibs_SewingOperationLibId",
                table: "SewingFeatureLibBOLs",
                column: "SewingOperationLibId",
                principalTable: "SewingOperationLibs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingMacroLibBOLs_SewingMacroLib_SewingMacroLibId",
                table: "SewingMacroLibBOLs",
                column: "SewingMacroLibId",
                principalTable: "SewingMacroLib",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingMacroLibBOLs_SewingTaskLib_SewingTaskLibId",
                table: "SewingMacroLibBOLs",
                column: "SewingTaskLibId",
                principalTable: "SewingTaskLib",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingSubOperationWFXBOL_SewingFeature_SewingFeatureId",
                table: "SewingSubOperationWFXBOL",
                column: "SewingFeatureId",
                principalTable: "SewingFeature",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingSubOperationWFXBOL_SewingOperation_SewingOperationId",
                table: "SewingSubOperationWFXBOL",
                column: "SewingOperationId",
                principalTable: "SewingOperation",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SewingFeatureLibBOLs_SewingFeatureLibs_SewingFeatureLibId",
                table: "SewingFeatureLibBOLs");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingFeatureLibBOLs_SewingOperationLibs_SewingOperationLibId",
                table: "SewingFeatureLibBOLs");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingMacroLibBOLs_SewingMacroLib_SewingMacroLibId",
                table: "SewingMacroLibBOLs");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingMacroLibBOLs_SewingTaskLib_SewingTaskLibId",
                table: "SewingMacroLibBOLs");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingSubOperationWFXBOL_SewingFeature_SewingFeatureId",
                table: "SewingSubOperationWFXBOL");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingSubOperationWFXBOL_SewingOperation_SewingOperationId",
                table: "SewingSubOperationWFXBOL");

            migrationBuilder.AlterColumn<int>(
                name: "SewingOperationId",
                table: "SewingSubOperationWFXBOL",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SewingFeatureId",
                table: "SewingSubOperationWFXBOL",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SewingTaskLibId",
                table: "SewingMacroLibBOLs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SewingMacroLibId",
                table: "SewingMacroLibBOLs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SewingOperationLibId",
                table: "SewingFeatureLibBOLs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SewingFeatureLibId",
                table: "SewingFeatureLibBOLs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingFeatureLibBOLs_SewingFeatureLibs_SewingFeatureLibId",
                table: "SewingFeatureLibBOLs",
                column: "SewingFeatureLibId",
                principalTable: "SewingFeatureLibs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingFeatureLibBOLs_SewingOperationLibs_SewingOperationLibId",
                table: "SewingFeatureLibBOLs",
                column: "SewingOperationLibId",
                principalTable: "SewingOperationLibs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingMacroLibBOLs_SewingMacroLib_SewingMacroLibId",
                table: "SewingMacroLibBOLs",
                column: "SewingMacroLibId",
                principalTable: "SewingMacroLib",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingMacroLibBOLs_SewingTaskLib_SewingTaskLibId",
                table: "SewingMacroLibBOLs",
                column: "SewingTaskLibId",
                principalTable: "SewingTaskLib",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SewingSubOperationWFXBOL_SewingFeature_SewingFeatureId",
                table: "SewingSubOperationWFXBOL",
                column: "SewingFeatureId",
                principalTable: "SewingFeature",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SewingSubOperationWFXBOL_SewingOperation_SewingOperationId",
                table: "SewingSubOperationWFXBOL",
                column: "SewingOperationId",
                principalTable: "SewingOperation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
