using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTable_CalendarRow_CalendarLeave_CalendarWeekDay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarLeave");

            migrationBuilder.DropTable(
                name: "CalendarRow");

            migrationBuilder.DropTable(
                name: "CalendarWeekDay");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalendarLeave",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LeaveDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    LeaveHourPerDay = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlanningRowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarLeave", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CalendarRow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanningFactoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Friday = table.Column<TimeSpan>(type: "time", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Monday = table.Column<TimeSpan>(type: "time", nullable: false),
                    PlanningRowId = table.Column<int>(type: "int", nullable: true),
                    Saturday = table.Column<TimeSpan>(type: "time", nullable: false),
                    Sunday = table.Column<TimeSpan>(type: "time", nullable: false),
                    Thursday = table.Column<TimeSpan>(type: "time", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Tuesday = table.Column<TimeSpan>(type: "time", nullable: false),
                    Wednesday = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarRow_PlanningFactory_PlanningFactoryId",
                        column: x => x.PlanningFactoryId,
                        principalTable: "PlanningFactory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CalendarWeekDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarConfigId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DayOfWeek = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ShiftType = table.Column<byte>(type: "tinyint", nullable: true),
                    StartTime = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    WorkHours = table.Column<decimal>(type: "decimal(28,8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarWeekDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarWeekDay_CalendarConfig_CalendarConfigId",
                        column: x => x.CalendarConfigId,
                        principalTable: "CalendarConfig",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarRow_PlanningFactoryId",
                table: "CalendarRow",
                column: "PlanningFactoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarWeekDay_CalendarConfigId",
                table: "CalendarWeekDay",
                column: "CalendarConfigId");
        }
    }
}
