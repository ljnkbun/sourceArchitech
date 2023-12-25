using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Mod_Buyer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApproveName",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApproveUserId",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestNo",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SwiftCode",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApproveName",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "ApproveUserId",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "RequestNo",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "SwiftCode",
                table: "Buyer");
        }
    }
}
