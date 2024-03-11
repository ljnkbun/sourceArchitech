using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AdjustTableStripScheduleCaculate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FromWorkingHours",
                table: "StripSchedule",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToWorkingHours",
                table: "StripSchedule",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromWorkingHours",
                table: "StripSchedule");

            migrationBuilder.DropColumn(
                name: "ToWorkingHours",
                table: "StripSchedule");
        }
    }
}
