using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyDCTemplateTaskDCTemplateDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Process",
                table: "DCTemplateTask",
                newName: "DyeingProcessName");

            migrationBuilder.RenameColumn(
                name: "Operation",
                table: "DCTemplateTask",
                newName: "DyeingOpreationName");

            migrationBuilder.RenameColumn(
                name: "MachineId",
                table: "DCTemplateTask",
                newName: "LineNumber");

            migrationBuilder.RenameColumn(
                name: "LineNumber",
                table: "DCTemplateDetail",
                newName: "ChemicalId");

            migrationBuilder.AddColumn<int>(
                name: "DyeingOpreationId",
                table: "DCTemplateTask",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DyeingProcessId",
                table: "DCTemplateTask",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MachineCode",
                table: "DCTemplateTask",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ChemicalSubCategory",
                table: "DCTemplateDetail",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DyeingOpreationId",
                table: "DCTemplateTask");

            migrationBuilder.DropColumn(
                name: "DyeingProcessId",
                table: "DCTemplateTask");

            migrationBuilder.DropColumn(
                name: "MachineCode",
                table: "DCTemplateTask");

            migrationBuilder.DropColumn(
                name: "ChemicalSubCategory",
                table: "DCTemplateDetail");

            migrationBuilder.RenameColumn(
                name: "LineNumber",
                table: "DCTemplateTask",
                newName: "MachineId");

            migrationBuilder.RenameColumn(
                name: "DyeingProcessName",
                table: "DCTemplateTask",
                newName: "Process");

            migrationBuilder.RenameColumn(
                name: "DyeingOpreationName",
                table: "DCTemplateTask",
                newName: "Operation");

            migrationBuilder.RenameColumn(
                name: "ChemicalId",
                table: "DCTemplateDetail",
                newName: "LineNumber");
        }
    }
}
