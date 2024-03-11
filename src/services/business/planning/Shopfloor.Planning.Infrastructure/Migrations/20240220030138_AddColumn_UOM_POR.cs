using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumn_UOM_POR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UOM",
                table: "PORDetail");

            migrationBuilder.AddColumn<string>(
                name: "UOM",
                table: "POR",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UOM",
                table: "POR");

            migrationBuilder.AddColumn<string>(
                name: "UOM",
                table: "PORDetail",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
