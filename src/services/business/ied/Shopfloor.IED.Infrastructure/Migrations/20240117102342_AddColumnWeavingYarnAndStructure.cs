using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnWeavingYarnAndStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "YarnTotal",
                table: "WeavingYarn",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LineNumber",
                table: "WeavingDetailStructure",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YarnTotal",
                table: "WeavingYarn");

            migrationBuilder.DropColumn(
                name: "LineNumber",
                table: "WeavingDetailStructure");
        }
    }
}
