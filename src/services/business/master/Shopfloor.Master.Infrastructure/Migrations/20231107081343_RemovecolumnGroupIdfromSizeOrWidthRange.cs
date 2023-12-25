using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemovecolumnGroupIdfromSizeOrWidthRange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "SizeOrWidthRange");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "SizeOrWidthRange",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
