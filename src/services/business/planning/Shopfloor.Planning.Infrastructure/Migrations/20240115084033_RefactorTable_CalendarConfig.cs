using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefactorTable_CalendarConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarWeekDay_CalendarConfig_CalendarConfigId",
                table: "CalendarWeekDay");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CalendarConfig");

            migrationBuilder.AddColumn<string>(
                name: "CalendarName",
                table: "CalendarConfig",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                table: "CalendarConfig",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Friday",
                table: "CalendarConfig",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDate",
                table: "CalendarConfig",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsWorkOnHoliday",
                table: "CalendarConfig",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "LineId",
                table: "CalendarConfig",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "CalendarConfig",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Monday",
                table: "CalendarConfig",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Saturday",
                table: "CalendarConfig",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Sunday",
                table: "CalendarConfig",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Thursday",
                table: "CalendarConfig",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDate",
                table: "CalendarConfig",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Tuesday",
                table: "CalendarConfig",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Wednesday",
                table: "CalendarConfig",
                type: "time",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarWeekDay_CalendarConfig_CalendarConfigId",
                table: "CalendarWeekDay",
                column: "CalendarConfigId",
                principalTable: "CalendarConfig",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarWeekDay_CalendarConfig_CalendarConfigId",
                table: "CalendarWeekDay");

            migrationBuilder.DropColumn(
                name: "CalendarName",
                table: "CalendarConfig");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                table: "CalendarConfig");

            migrationBuilder.DropColumn(
                name: "Friday",
                table: "CalendarConfig");

            migrationBuilder.DropColumn(
                name: "FromDate",
                table: "CalendarConfig");

            migrationBuilder.DropColumn(
                name: "IsWorkOnHoliday",
                table: "CalendarConfig");

            migrationBuilder.DropColumn(
                name: "LineId",
                table: "CalendarConfig");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "CalendarConfig");

            migrationBuilder.DropColumn(
                name: "Monday",
                table: "CalendarConfig");

            migrationBuilder.DropColumn(
                name: "Saturday",
                table: "CalendarConfig");

            migrationBuilder.DropColumn(
                name: "Sunday",
                table: "CalendarConfig");

            migrationBuilder.DropColumn(
                name: "Thursday",
                table: "CalendarConfig");

            migrationBuilder.DropColumn(
                name: "ToDate",
                table: "CalendarConfig");

            migrationBuilder.DropColumn(
                name: "Tuesday",
                table: "CalendarConfig");

            migrationBuilder.DropColumn(
                name: "Wednesday",
                table: "CalendarConfig");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CalendarConfig",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarWeekDay_CalendarConfig_CalendarConfigId",
                table: "CalendarWeekDay",
                column: "CalendarConfigId",
                principalTable: "CalendarConfig",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
