using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyFPPO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UOM",
                table: "FPPODetail");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "FPPO",
                type: "bit",
                nullable: false,
                defaultValueSql: "((0))");

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                table: "FPPO",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UOM",
                table: "FPPO",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WFXDeliveryOrderCode",
                table: "FPPO",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WFXFPPOId",
                table: "FPPO",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WFXOCId",
                table: "FPPO",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WipDispatchSite",
                table: "FPPO",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WipReceivingSite",
                table: "FPPO",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "FPPO");

            migrationBuilder.DropColumn(
                name: "Supplier",
                table: "FPPO");

            migrationBuilder.DropColumn(
                name: "UOM",
                table: "FPPO");

            migrationBuilder.DropColumn(
                name: "WFXDeliveryOrderCode",
                table: "FPPO");

            migrationBuilder.DropColumn(
                name: "WFXFPPOId",
                table: "FPPO");

            migrationBuilder.DropColumn(
                name: "WFXOCId",
                table: "FPPO");

            migrationBuilder.DropColumn(
                name: "WipDispatchSite",
                table: "FPPO");

            migrationBuilder.DropColumn(
                name: "WipReceivingSite",
                table: "FPPO");

            migrationBuilder.AddColumn<string>(
                name: "UOM",
                table: "FPPODetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
