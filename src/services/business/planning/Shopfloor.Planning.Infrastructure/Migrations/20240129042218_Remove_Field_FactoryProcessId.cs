using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Field_FactoryProcessId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FactoryProcessLinePlanning");

            migrationBuilder.DropTable(
                name: "FactoryProcessMachinePlanning");

            migrationBuilder.RenameColumn(
                name: "FactoryProcessId",
                table: "StripFactory",
                newName: "PlanningGroupFactoryId");

            migrationBuilder.RenameColumn(
                name: "FactoryProcessId",
                table: "FactoryCapacity",
                newName: "PlanningGroupFactoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlanningGroupFactoryId",
                table: "StripFactory",
                newName: "FactoryProcessId");

            migrationBuilder.RenameColumn(
                name: "PlanningGroupFactoryId",
                table: "FactoryCapacity",
                newName: "FactoryProcessId");

            migrationBuilder.CreateTable(
                name: "FactoryProcessLinePlanning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FactoryProcessId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LineId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryProcessLinePlanning", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FactoryProcessMachinePlanning",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FactoryProcessId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    MachinePlanningId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FactoryProcessMachinePlanning", x => x.Id);
                });
        }
    }
}
