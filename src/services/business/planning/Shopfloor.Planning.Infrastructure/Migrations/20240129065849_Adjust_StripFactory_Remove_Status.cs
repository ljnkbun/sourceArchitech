using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Adjust_StripFactory_Remove_Status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StripFactoryStatus",
                table: "StripFactory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "StripFactoryStatus",
                table: "StripFactory",
                type: "tinyint",
                nullable: true);
        }
    }
}
