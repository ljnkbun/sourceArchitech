using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Modify_Buyer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAddressDetails",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "BillAddress",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "CatalogPath",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "CountryOfOrigin",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "DeliveryTerms",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "PaymentTerms",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "PortOfLoading",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "ShipmentTerms",
                table: "Buyer");

            migrationBuilder.RenameColumn(
                name: "Tolearancen",
                table: "Buyer",
                newName: "Tolearance");

            migrationBuilder.RenameColumn(
                name: "ShipAddress",
                table: "Buyer",
                newName: "BankAddress");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Buyer",
                newName: "ContactEmail");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Buyer",
                newName: "Fax");

            migrationBuilder.AlterColumn<string>(
                name: "VATNumber",
                table: "Buyer",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyEmail",
                table: "Buyer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceTaxNumber",
                table: "Buyer",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyEmail",
                table: "Buyer");

            migrationBuilder.DropColumn(
                name: "ServiceTaxNumber",
                table: "Buyer");

            migrationBuilder.RenameColumn(
                name: "Tolearance",
                table: "Buyer",
                newName: "Tolearancen");

            migrationBuilder.RenameColumn(
                name: "Fax",
                table: "Buyer",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "ContactEmail",
                table: "Buyer",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "BankAddress",
                table: "Buyer",
                newName: "ShipAddress");

            migrationBuilder.AlterColumn<string>(
                name: "VATNumber",
                table: "Buyer",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankAddressDetails",
                table: "Buyer",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BillAddress",
                table: "Buyer",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CatalogPath",
                table: "Buyer",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryOfOrigin",
                table: "Buyer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryTerms",
                table: "Buyer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Buyer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentTerms",
                table: "Buyer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PortOfLoading",
                table: "Buyer",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShipmentTerms",
                table: "Buyer",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
