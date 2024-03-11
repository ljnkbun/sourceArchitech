using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCodeForDyeingWeavingKnitting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeavingProcessId",
                table: "WeavingRouting");

            migrationBuilder.AddColumn<string>(
                name: "WeavingProcessCode",
                table: "WeavingRouting",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KnittingProcessCode",
                table: "KnittingRouting",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DyeingProcessCode",
                table: "DyeingRouting",
                type: "varchar(100)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WeavingProcessCode",
                table: "WeavingRouting");

            migrationBuilder.DropColumn(
                name: "KnittingProcessCode",
                table: "KnittingRouting");

            migrationBuilder.DropColumn(
                name: "DyeingProcessCode",
                table: "DyeingRouting");

            migrationBuilder.AddColumn<int>(
                name: "WeavingProcessId",
                table: "WeavingRouting",
                type: "int",
                nullable: true);
        }
    }
}
