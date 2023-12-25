using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Modify_Column_Buyer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyWebsite",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "ServiceTaxNumber",
                table: "Buyer");

            migrationBuilder.RenameColumn(
                name: "Fax",
                table: "Buyer",
                newName: "TIN");

            migrationBuilder.RenameColumn(
                name: "CompanyEmail",
                table: "Buyer",
                newName: "ShipmentTerms");

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address3",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillAddress",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryOfFinalDestination",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomHouse",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Buyer",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryTerms",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FinalDestination",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Market",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PAN",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerms",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PortofDischarge",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipAddress",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "Address3",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "BillAddress",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "CountryOfFinalDestination",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "CustomHouse",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "DeliveryTerms",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "FinalDestination",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "Market",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "PAN",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "PaymentTerms",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "PortofDischarge",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "ShipAddress",
                table: "Buyer");

            migrationBuilder.RenameColumn(
                name: "TIN",
                table: "Buyer",
                newName: "Fax");

            migrationBuilder.RenameColumn(
                name: "ShipmentTerms",
                table: "Buyer",
                newName: "CompanyEmail");

            migrationBuilder.AddColumn<string>(
                name: "CompanyWebsite",
                table: "Buyer",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Buyer",
                type: "nvarchar(4000)",
                maxLength: 4000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceTaxNumber",
                table: "Buyer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
