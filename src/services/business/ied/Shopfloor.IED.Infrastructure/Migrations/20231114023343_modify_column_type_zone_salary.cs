using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modify_column_type_zone_salary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ZoneSalary",
                table: "Zone",
                type: "decimal(28,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ZoneSalary",
                table: "Zone",
                type: "decimal(18,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");
        }
    }
}
