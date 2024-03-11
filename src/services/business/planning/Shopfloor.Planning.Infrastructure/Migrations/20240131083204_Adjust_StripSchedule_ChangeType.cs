using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Adjust_StripSchedule_ChangeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderEfficiencyId",
                table: "StripSchedule");

            migrationBuilder.DropColumn(
                name: "ProfileEfficiencyId",
                table: "StripSchedule");

            migrationBuilder.DropColumn(
                name: "StripEfficiencyId",
                table: "StripSchedule");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "StripSchedulePlanningDetail",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ReceivedCapacity",
                table: "StripSchedulePlanningDetail",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WorkingHours",
                table: "StripSchedulePlanningDetail",
                type: "decimal(3,1)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ToDate",
                table: "StripSchedule",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FromDate",
                table: "StripSchedule",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<decimal>(
                name: "OrderEfficiencyValue",
                table: "StripSchedule",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ProfileEfficiencyValue",
                table: "StripSchedule",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "StripEfficiencyValue",
                table: "StripSchedule",
                type: "decimal(28,8)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceivedCapacity",
                table: "StripSchedulePlanningDetail");

            migrationBuilder.DropColumn(
                name: "WorkingHours",
                table: "StripSchedulePlanningDetail");

            migrationBuilder.DropColumn(
                name: "OrderEfficiencyValue",
                table: "StripSchedule");

            migrationBuilder.DropColumn(
                name: "ProfileEfficiencyValue",
                table: "StripSchedule");

            migrationBuilder.DropColumn(
                name: "StripEfficiencyValue",
                table: "StripSchedule");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "StripSchedulePlanningDetail",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ToDate",
                table: "StripSchedule",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FromDate",
                table: "StripSchedule",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<int>(
                name: "OrderEfficiencyId",
                table: "StripSchedule",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProfileEfficiencyId",
                table: "StripSchedule",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StripEfficiencyId",
                table: "StripSchedule",
                type: "int",
                nullable: true);
        }
    }
}
