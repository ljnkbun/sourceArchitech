using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDCTemplateTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskCode",
                table: "DCTemplateTask");

            migrationBuilder.DropColumn(
                name: "TaskName",
                table: "DCTemplateTask");

            migrationBuilder.RenameColumn(
                name: "WFXMachineId",
                table: "SewingTaskLib",
                newName: "MachineId");

            migrationBuilder.RenameColumn(
                name: "WFXMachineId",
                table: "SewingMachineEfficiencyProfile",
                newName: "MachineId");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "DCTemplateTask",
                newName: "MachineId");

            migrationBuilder.AddColumn<string>(
                name: "MachineName",
                table: "DCTemplateTask",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Operation",
                table: "DCTemplateTask",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Process",
                table: "DCTemplateTask",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MachineName",
                table: "DCTemplateTask");

            migrationBuilder.DropColumn(
                name: "Operation",
                table: "DCTemplateTask");

            migrationBuilder.DropColumn(
                name: "Process",
                table: "DCTemplateTask");

            migrationBuilder.RenameColumn(
                name: "MachineId",
                table: "SewingTaskLib",
                newName: "WFXMachineId");

            migrationBuilder.RenameColumn(
                name: "MachineId",
                table: "SewingMachineEfficiencyProfile",
                newName: "WFXMachineId");

            migrationBuilder.RenameColumn(
                name: "MachineId",
                table: "DCTemplateTask",
                newName: "TaskId");

            migrationBuilder.AddColumn<string>(
                name: "TaskCode",
                table: "DCTemplateTask",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaskName",
                table: "DCTemplateTask",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
