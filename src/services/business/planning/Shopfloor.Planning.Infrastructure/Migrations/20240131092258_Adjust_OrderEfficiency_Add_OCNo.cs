using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Adjust_OrderEfficiency_Add_OCNo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "OrderEfficiency");

            migrationBuilder.AddColumn<string>(
                name: "OCNo",
                table: "OrderEfficiency",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OCNo",
                table: "OrderEfficiency");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "OrderEfficiency",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
