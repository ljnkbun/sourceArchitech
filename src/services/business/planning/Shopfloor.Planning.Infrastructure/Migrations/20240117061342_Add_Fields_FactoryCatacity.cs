using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Fields_FactoryCatacity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlanningFactoryId",
                table: "StripFactory",
                newName: "FactoryProcessId");

            migrationBuilder.AddColumn<int>(
                name: "FactoryProcessId",
                table: "FactoryCapacity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessId",
                table: "FactoryCapacity",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcessName",
                table: "FactoryCapacity",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FactoryProcessId",
                table: "FactoryCapacity");

            migrationBuilder.DropColumn(
                name: "ProcessId",
                table: "FactoryCapacity");

            migrationBuilder.DropColumn(
                name: "ProcessName",
                table: "FactoryCapacity");

            migrationBuilder.RenameColumn(
                name: "FactoryProcessId",
                table: "StripFactory",
                newName: "PlanningFactoryId");
        }
    }
}
