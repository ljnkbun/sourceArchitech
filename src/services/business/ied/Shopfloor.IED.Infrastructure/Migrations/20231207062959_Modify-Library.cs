using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyLibrary : Migration
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
                name: "FK_SewingMacro_FolderTree_FolderTreeId",
                table: "SewingMacro");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingMacroLibBOLs_SewingMacroLib_SewingMacroLibId",
                table: "SewingMacroLibBOLs");

            migrationBuilder.DropForeignKey(
                name: "FK_SewingMacroLibBOLs_SewingTaskLib_SewingTaskLibId",
                table: "SewingMacroLibBOLs");

            migrationBuilder.DropIndex(
                name: "IX_SewingMacro_FolderTreeId",
                table: "SewingMacro");

            migrationBuilder.DropColumn(
                name: "BundelTMU",
                table: "SewingTaskLib");

            migrationBuilder.DropColumn(
                name: "MachineTMU",
                table: "SewingTaskLib");

            migrationBuilder.DropColumn(
                name: "ManualTMU",
                table: "SewingTaskLib");

            migrationBuilder.DropColumn(
                name: "BundelTMU",
                table: "SewingTask");

            migrationBuilder.DropColumn(
                name: "MachineTMU",
                table: "SewingTask");

            migrationBuilder.DropColumn(
                name: "ManualTMU",
                table: "SewingTask");

            migrationBuilder.DropColumn(
                name: "BundelTMU",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "Freq",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "FolderTreeId",
                table: "SewingMacro");

            migrationBuilder.AddColumn<decimal>(
                name: "BundleTMU",
                table: "SewingOperationLibs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LabourCost",
                table: "SewingOperationLibs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MachineTMU",
                table: "SewingOperationLibs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ManualTMU",
                table: "SewingOperationLibs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NoneMachineTime",
                table: "SewingOperationLibs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTMU",
                table: "SewingOperationLibs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Freq",
                table: "SewingOperationLibBOLs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTMU",
                table: "SewingOperationLibBOLs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Freq",
                table: "SewingOperationBOL",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTMU",
                table: "SewingOperationBOL",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalTMU",
                table: "SewingOperation",
                type: "decimal(28,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ManualTMU",
                table: "SewingOperation",
                type: "decimal(28,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MachineTMU",
                table: "SewingOperation",
                type: "decimal(28,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "BundleTMU",
                table: "SewingOperation",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LabourCost",
                table: "SewingOperation",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NoneMachineTime",
                table: "SewingOperation",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.AddColumn<decimal>(
                name: "Freq",
                table: "SewingMacroLibBOLs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTMU",
                table: "SewingMacroLibBOLs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BundleTMU",
                table: "SewingMacroLib",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MachineTMU",
                table: "SewingMacroLib",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ManualTMU",
                table: "SewingMacroLib",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NoneMachineTime",
                table: "SewingMacroLib",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalBasicMinutes",
                table: "SewingMacroLib",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Freq",
                table: "SewingMacroBOL",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalTMU",
                table: "SewingMacroBOL",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BundleTMU",
                table: "SewingMacro",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MachineTMU",
                table: "SewingMacro",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ManualTMU",
                table: "SewingMacro",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NoneMachineTime",
                table: "SewingMacro",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalBasicMinutes",
                table: "SewingMacro",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AllowedTime",
                table: "SewingFeatureLibs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LabourCost",
                table: "SewingFeatureLibs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSMV",
                table: "SewingFeatureLibs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.AddColumn<decimal>(
                name: "AllowedTime",
                table: "SewingFeatureLibBOLs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Freq",
                table: "SewingFeatureLibBOLs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "MachineName",
                table: "SewingFeatureLibBOLs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RPM",
                table: "SewingFeatureLibBOLs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SMV",
                table: "SewingFeatureLibBOLs",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AllowedTime",
                table: "SewingFeatureBOL",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Freq",
                table: "SewingFeatureBOL",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "MachineName",
                table: "SewingFeatureBOL",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RPM",
                table: "SewingFeatureBOL",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "SMV",
                table: "SewingFeatureBOL",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AllowedTime",
                table: "SewingFeature",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "LabourCost",
                table: "SewingFeature",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalSMV",
                table: "SewingFeature",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.DropColumn(
                name: "BundleTMU",
                table: "SewingOperationLibs");

            migrationBuilder.DropColumn(
                name: "LabourCost",
                table: "SewingOperationLibs");

            migrationBuilder.DropColumn(
                name: "MachineTMU",
                table: "SewingOperationLibs");

            migrationBuilder.DropColumn(
                name: "ManualTMU",
                table: "SewingOperationLibs");

            migrationBuilder.DropColumn(
                name: "NoneMachineTime",
                table: "SewingOperationLibs");

            migrationBuilder.DropColumn(
                name: "TotalTMU",
                table: "SewingOperationLibs");

            migrationBuilder.DropColumn(
                name: "Freq",
                table: "SewingOperationLibBOLs");

            migrationBuilder.DropColumn(
                name: "TotalTMU",
                table: "SewingOperationLibBOLs");

            migrationBuilder.DropColumn(
                name: "Freq",
                table: "SewingOperationBOL");

            migrationBuilder.DropColumn(
                name: "TotalTMU",
                table: "SewingOperationBOL");

            migrationBuilder.DropColumn(
                name: "BundleTMU",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "LabourCost",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "NoneMachineTime",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "Freq",
                table: "SewingMacroLibBOLs");

            migrationBuilder.DropColumn(
                name: "TotalTMU",
                table: "SewingMacroLibBOLs");

            migrationBuilder.DropColumn(
                name: "BundleTMU",
                table: "SewingMacroLib");

            migrationBuilder.DropColumn(
                name: "MachineTMU",
                table: "SewingMacroLib");

            migrationBuilder.DropColumn(
                name: "ManualTMU",
                table: "SewingMacroLib");

            migrationBuilder.DropColumn(
                name: "NoneMachineTime",
                table: "SewingMacroLib");

            migrationBuilder.DropColumn(
                name: "TotalBasicMinutes",
                table: "SewingMacroLib");

            migrationBuilder.DropColumn(
                name: "Freq",
                table: "SewingMacroBOL");

            migrationBuilder.DropColumn(
                name: "TotalTMU",
                table: "SewingMacroBOL");

            migrationBuilder.DropColumn(
                name: "BundleTMU",
                table: "SewingMacro");

            migrationBuilder.DropColumn(
                name: "MachineTMU",
                table: "SewingMacro");

            migrationBuilder.DropColumn(
                name: "ManualTMU",
                table: "SewingMacro");

            migrationBuilder.DropColumn(
                name: "NoneMachineTime",
                table: "SewingMacro");

            migrationBuilder.DropColumn(
                name: "TotalBasicMinutes",
                table: "SewingMacro");

            migrationBuilder.DropColumn(
                name: "AllowedTime",
                table: "SewingFeatureLibs");

            migrationBuilder.DropColumn(
                name: "LabourCost",
                table: "SewingFeatureLibs");

            migrationBuilder.DropColumn(
                name: "TotalSMV",
                table: "SewingFeatureLibs");

            migrationBuilder.DropColumn(
                name: "AllowedTime",
                table: "SewingFeatureLibBOLs");

            migrationBuilder.DropColumn(
                name: "Freq",
                table: "SewingFeatureLibBOLs");

            migrationBuilder.DropColumn(
                name: "MachineName",
                table: "SewingFeatureLibBOLs");

            migrationBuilder.DropColumn(
                name: "RPM",
                table: "SewingFeatureLibBOLs");

            migrationBuilder.DropColumn(
                name: "SMV",
                table: "SewingFeatureLibBOLs");

            migrationBuilder.DropColumn(
                name: "AllowedTime",
                table: "SewingFeatureBOL");

            migrationBuilder.DropColumn(
                name: "Freq",
                table: "SewingFeatureBOL");

            migrationBuilder.DropColumn(
                name: "MachineName",
                table: "SewingFeatureBOL");

            migrationBuilder.DropColumn(
                name: "RPM",
                table: "SewingFeatureBOL");

            migrationBuilder.DropColumn(
                name: "SMV",
                table: "SewingFeatureBOL");

            migrationBuilder.DropColumn(
                name: "AllowedTime",
                table: "SewingFeature");

            migrationBuilder.DropColumn(
                name: "LabourCost",
                table: "SewingFeature");

            migrationBuilder.DropColumn(
                name: "TotalSMV",
                table: "SewingFeature");

            migrationBuilder.AddColumn<decimal>(
                name: "BundelTMU",
                table: "SewingTaskLib",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MachineTMU",
                table: "SewingTaskLib",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ManualTMU",
                table: "SewingTaskLib",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "BundelTMU",
                table: "SewingTask",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MachineTMU",
                table: "SewingTask",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ManualTMU",
                table: "SewingTask",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalTMU",
                table: "SewingOperation",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ManualTMU",
                table: "SewingOperation",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "MachineTMU",
                table: "SewingOperation",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AddColumn<decimal>(
                name: "BundelTMU",
                table: "SewingOperation",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Freq",
                table: "SewingOperation",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "FolderTreeId",
                table: "SewingMacro",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_SewingMacro_FolderTreeId",
                table: "SewingMacro",
                column: "FolderTreeId");

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
                name: "FK_SewingMacro_FolderTree_FolderTreeId",
                table: "SewingMacro",
                column: "FolderTreeId",
                principalTable: "FolderTree",
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
        }
    }
}
