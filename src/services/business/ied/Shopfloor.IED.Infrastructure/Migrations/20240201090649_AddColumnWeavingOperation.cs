using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnWeavingOperation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeavingProcessId",
                table: "WeavingRouting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OperationId",
                table: "WeavingOperation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeavingProcessId",
                table: "WeavingRouting");

            migrationBuilder.DropColumn(
                name: "OperationId",
                table: "WeavingOperation");
        }
    }
}
