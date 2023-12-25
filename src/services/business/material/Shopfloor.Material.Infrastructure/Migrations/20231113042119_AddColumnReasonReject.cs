using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnReasonReject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReasonReject",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonReject",
                table: "PriceList",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonReject",
                table: "MaterialRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonReject",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReasonReject",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ReasonReject",
                table: "PriceList");

            migrationBuilder.DropColumn(
                name: "ReasonReject",
                table: "MaterialRequest");

            migrationBuilder.DropColumn(
                name: "ReasonReject",
                table: "Buyer");
        }
    }
}
