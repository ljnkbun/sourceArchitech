using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Production.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTbl4point100point : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LongErrorFrom",
                table: "DefectCapturing",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "LongErrorTo",
                table: "DefectCapturing",
                type: "decimal(28,8)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongErrorFrom",
                table: "DefectCapturing");

            migrationBuilder.DropColumn(
                name: "LongErrorTo",
                table: "DefectCapturing");
        }
    }
}
