using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddModifyFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Freq",
                table: "SewingTaskLib");

            migrationBuilder.DropColumn(
                name: "Freq",
                table: "SewingTask");

            migrationBuilder.RenameColumn(
                name: "VerticalShrinkage",
                table: "WeavingRusticFabricSpec",
                newName: "WeftShrinkage");

            migrationBuilder.RenameColumn(
                name: "VerticalDensity",
                table: "WeavingRusticFabricSpec",
                newName: "WeftDensity");

            migrationBuilder.RenameColumn(
                name: "RusticSize",
                table: "WeavingRusticFabricSpec",
                newName: "WarpShrinkage");

            migrationBuilder.RenameColumn(
                name: "HorizontalShrinkage",
                table: "WeavingRusticFabricSpec",
                newName: "WarpDensity");

            migrationBuilder.RenameColumn(
                name: "HorizontalDensitySetting",
                table: "WeavingRusticFabricSpec",
                newName: "SettingWeftDensity");

            migrationBuilder.RenameColumn(
                name: "HorizontalDensity",
                table: "WeavingRusticFabricSpec",
                newName: "ReedWidth");

            migrationBuilder.RenameColumn(
                name: "CombSize",
                table: "WeavingRusticFabricSpec",
                newName: "ReedCount");

            migrationBuilder.RenameColumn(
                name: "CombNum",
                table: "WeavingRusticFabricSpec",
                newName: "HarnessFrameMWS");

            migrationBuilder.RenameColumn(
                name: "BorderType",
                table: "WeavingRusticFabricSpec",
                newName: "MarginWeaveStyle");

            migrationBuilder.RenameColumn(
                name: "BorderLoomFrame",
                table: "WeavingRusticFabricSpec",
                newName: "HarnessFrameCWS");

            migrationBuilder.RenameColumn(
                name: "BackgroundType",
                table: "WeavingRusticFabricSpec",
                newName: "ContentWeaveStyle");

            migrationBuilder.RenameColumn(
                name: "BackgroundLoomFrame",
                table: "WeavingRusticFabricSpec",
                newName: "GreigeWidth");

            migrationBuilder.RenameColumn(
                name: "YarnOfBorder",
                table: "WeavingRappo",
                newName: "WarpPerMarginDentSplit");

            migrationBuilder.RenameColumn(
                name: "YarnOfBackground",
                table: "WeavingRappo",
                newName: "WarpPerContentDentSplit");

            migrationBuilder.RenameColumn(
                name: "NumOfRappo",
                table: "WeavingRappo",
                newName: "TotalRappo");

            migrationBuilder.RenameColumn(
                name: "NumOfLine",
                table: "WeavingRappo",
                newName: "Line");

            migrationBuilder.RenameColumn(
                name: "SlotNumber",
                table: "WeavingDetailStructure",
                newName: "Denting");

            migrationBuilder.RenameColumn(
                name: "CombString",
                table: "WeavingDetailStructure",
                newName: "DentSplit");

            migrationBuilder.RenameColumn(
                name: "TotalTMU",
                table: "SewingOperationLib",
                newName: "TotalSMV");

            migrationBuilder.RenameColumn(
                name: "TotalTMU",
                table: "SewingOperation",
                newName: "TotalSMV");

            migrationBuilder.AddColumn<int>(
                name: "WFXYarnId",
                table: "WeavingYarn",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "WastageRatio",
                table: "WeavingYarn",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "AdditionYarn",
                table: "WeavingRappo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DrawingComment",
                table: "WeavingRappo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MachineName",
                table: "SewingTaskLib",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WFXMachineId",
                table: "SewingTaskLib",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MachineName",
                table: "SewingTask",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WFXMachineId",
                table: "SewingTask",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Allowance",
                table: "SewingOperationLibBOL",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Contingency",
                table: "SewingOperationLib",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MachineDelay",
                table: "SewingOperationLib",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PersonalAllowance",
                table: "SewingOperationLib",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Allowance",
                table: "SewingOperationBOL",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Contingency",
                table: "SewingOperation",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MachineDelay",
                table: "SewingOperation",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PersonalAllowance",
                table: "SewingOperation",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WFXYarnId",
                table: "WeavingYarn");

            migrationBuilder.DropColumn(
                name: "WastageRatio",
                table: "WeavingYarn");

            migrationBuilder.DropColumn(
                name: "AdditionYarn",
                table: "WeavingRappo");

            migrationBuilder.DropColumn(
                name: "DrawingComment",
                table: "WeavingRappo");

            migrationBuilder.DropColumn(
                name: "MachineName",
                table: "SewingTaskLib");

            migrationBuilder.DropColumn(
                name: "WFXMachineId",
                table: "SewingTaskLib");

            migrationBuilder.DropColumn(
                name: "MachineName",
                table: "SewingTask");

            migrationBuilder.DropColumn(
                name: "WFXMachineId",
                table: "SewingTask");

            migrationBuilder.DropColumn(
                name: "Allowance",
                table: "SewingOperationLibBOL");

            migrationBuilder.DropColumn(
                name: "Contingency",
                table: "SewingOperationLib");

            migrationBuilder.DropColumn(
                name: "MachineDelay",
                table: "SewingOperationLib");

            migrationBuilder.DropColumn(
                name: "PersonalAllowance",
                table: "SewingOperationLib");

            migrationBuilder.DropColumn(
                name: "Allowance",
                table: "SewingOperationBOL");

            migrationBuilder.DropColumn(
                name: "Contingency",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "MachineDelay",
                table: "SewingOperation");

            migrationBuilder.DropColumn(
                name: "PersonalAllowance",
                table: "SewingOperation");

            migrationBuilder.RenameColumn(
                name: "WeftShrinkage",
                table: "WeavingRusticFabricSpec",
                newName: "VerticalShrinkage");

            migrationBuilder.RenameColumn(
                name: "WeftDensity",
                table: "WeavingRusticFabricSpec",
                newName: "VerticalDensity");

            migrationBuilder.RenameColumn(
                name: "WarpShrinkage",
                table: "WeavingRusticFabricSpec",
                newName: "RusticSize");

            migrationBuilder.RenameColumn(
                name: "WarpDensity",
                table: "WeavingRusticFabricSpec",
                newName: "HorizontalShrinkage");

            migrationBuilder.RenameColumn(
                name: "SettingWeftDensity",
                table: "WeavingRusticFabricSpec",
                newName: "HorizontalDensitySetting");

            migrationBuilder.RenameColumn(
                name: "ReedWidth",
                table: "WeavingRusticFabricSpec",
                newName: "HorizontalDensity");

            migrationBuilder.RenameColumn(
                name: "ReedCount",
                table: "WeavingRusticFabricSpec",
                newName: "CombSize");

            migrationBuilder.RenameColumn(
                name: "MarginWeaveStyle",
                table: "WeavingRusticFabricSpec",
                newName: "BorderType");

            migrationBuilder.RenameColumn(
                name: "HarnessFrameMWS",
                table: "WeavingRusticFabricSpec",
                newName: "CombNum");

            migrationBuilder.RenameColumn(
                name: "HarnessFrameCWS",
                table: "WeavingRusticFabricSpec",
                newName: "BorderLoomFrame");

            migrationBuilder.RenameColumn(
                name: "GreigeWidth",
                table: "WeavingRusticFabricSpec",
                newName: "BackgroundLoomFrame");

            migrationBuilder.RenameColumn(
                name: "ContentWeaveStyle",
                table: "WeavingRusticFabricSpec",
                newName: "BackgroundType");

            migrationBuilder.RenameColumn(
                name: "WarpPerMarginDentSplit",
                table: "WeavingRappo",
                newName: "YarnOfBorder");

            migrationBuilder.RenameColumn(
                name: "WarpPerContentDentSplit",
                table: "WeavingRappo",
                newName: "YarnOfBackground");

            migrationBuilder.RenameColumn(
                name: "TotalRappo",
                table: "WeavingRappo",
                newName: "NumOfRappo");

            migrationBuilder.RenameColumn(
                name: "Line",
                table: "WeavingRappo",
                newName: "NumOfLine");

            migrationBuilder.RenameColumn(
                name: "Denting",
                table: "WeavingDetailStructure",
                newName: "SlotNumber");

            migrationBuilder.RenameColumn(
                name: "DentSplit",
                table: "WeavingDetailStructure",
                newName: "CombString");

            migrationBuilder.RenameColumn(
                name: "TotalSMV",
                table: "SewingOperationLib",
                newName: "TotalTMU");

            migrationBuilder.RenameColumn(
                name: "TotalSMV",
                table: "SewingOperation",
                newName: "TotalTMU");

            migrationBuilder.AddColumn<string>(
                name: "Freq",
                table: "SewingTaskLib",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Freq",
                table: "SewingTask",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
