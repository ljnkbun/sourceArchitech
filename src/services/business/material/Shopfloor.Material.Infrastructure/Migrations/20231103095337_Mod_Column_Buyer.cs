using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mod_Column_Buyer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyName",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "CurrencyName",
                table: "Buyer");
        }
    }
}
