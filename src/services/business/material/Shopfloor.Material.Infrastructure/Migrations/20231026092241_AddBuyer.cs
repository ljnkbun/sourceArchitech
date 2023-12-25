using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBuyer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buyer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BillAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ShipAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactFirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ContactLastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Tolearancen = table.Column<decimal>(type: "decimal(18,2)", maxLength: 10, nullable: true),
                    PaymentTerms = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DeliveryTerms = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ShipmentTerms = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PortOfLoading = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CatalogPath = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AccountGroup = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BankAddressDetails = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    VATNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CompanyWebsite = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    IsRetailer = table.Column<bool>(type: "bit", nullable: false),
                    IsWholesaler = table.Column<bool>(type: "bit", nullable: false),
                    IsManufacture = table.Column<bool>(type: "bit", nullable: false),
                    IsTransporter = table.Column<bool>(type: "bit", nullable: false),
                    IsBuying = table.Column<bool>(type: "bit", nullable: false),
                    IsServiceProvider = table.Column<bool>(type: "bit", nullable: false),
                    IsBrand = table.Column<bool>(type: "bit", nullable: false),
                    IsComposition = table.Column<bool>(type: "bit", nullable: false),
                    IsOther = table.Column<bool>(type: "bit", nullable: false),
                    SegmentOther = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuyerProductCategoryMapping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerProductCategoryMapping", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyerProductCategoryMapping_Buyer_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyerProductCategoryMapping_BuyerId",
                table: "BuyerProductCategoryMapping",
                column: "BuyerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyerProductCategoryMapping");

            migrationBuilder.DropTable(
                name: "Buyer");
        }
    }
}
