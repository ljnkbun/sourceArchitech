using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Production.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Measurement");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Measurement");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "InspectionBySize");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "InspectionBySize");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "FPPOOutputDetail");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FPPOOutputDetail");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "FPPOOutput");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FPPOOutput");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "DefectCapturing");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "DefectCapturing");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductionOutput",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Measurement",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Measurement",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "InspectionBySize",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "InspectionBySize",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "FPPOOutputDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FPPOOutputDetail",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "FPPOOutput",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FPPOOutput",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "DefectCapturing",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "DefectCapturing",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
