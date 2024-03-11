using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Table_PlanningRow : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarLeave_PlanningRow_PlanningRowId",
                table: "CalendarLeave");

            migrationBuilder.DropForeignKey(
                name: "FK_CalendarRow_PlanningRow_PlanningRowId",
                table: "CalendarRow");

            migrationBuilder.DropTable(
                name: "PlanningRow");

            migrationBuilder.DropIndex(
                name: "IX_CalendarRow_PlanningRowId",
                table: "CalendarRow");

            migrationBuilder.DropIndex(
                name: "IX_CalendarLeave_PlanningRowId",
                table: "CalendarLeave");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanningRow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanningFactoryId = table.Column<int>(type: "int", nullable: false),
                    ProfileEfficiencyId = table.Column<int>(type: "int", nullable: true),
                    CapacityMachine = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EfficiencyProfileId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LineId = table.Column<int>(type: "int", nullable: true),
                    MachineHour = table.Column<int>(type: "int", nullable: true),
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Worker = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanningRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanningRow_PlanningFactory_PlanningFactoryId",
                        column: x => x.PlanningFactoryId,
                        principalTable: "PlanningFactory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanningRow_ProfileEfficiency_ProfileEfficiencyId",
                        column: x => x.ProfileEfficiencyId,
                        principalTable: "ProfileEfficiency",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarRow_PlanningRowId",
                table: "CalendarRow",
                column: "PlanningRowId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarLeave_PlanningRowId",
                table: "CalendarLeave",
                column: "PlanningRowId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningRow_PlanningFactoryId",
                table: "PlanningRow",
                column: "PlanningFactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanningRow_ProfileEfficiencyId",
                table: "PlanningRow",
                column: "ProfileEfficiencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarLeave_PlanningRow_PlanningRowId",
                table: "CalendarLeave",
                column: "PlanningRowId",
                principalTable: "PlanningRow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarRow_PlanningRow_PlanningRowId",
                table: "CalendarRow",
                column: "PlanningRowId",
                principalTable: "PlanningRow",
                principalColumn: "Id");
        }
    }
}
