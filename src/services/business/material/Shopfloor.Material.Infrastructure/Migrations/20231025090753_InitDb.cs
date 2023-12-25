using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCatCode = table.Column<int>(type: "int", nullable: false),
                    MaterialTypeID = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ArticleCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ArticleDesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductGroup = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductSubCatCode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Theme = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OurContact = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StoringUOM = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ConsUOM = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Season = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DivisionCode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ColorGroupID = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SizeGroupID = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Buyer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BuyerRef = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupplierCode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupplierRef = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BuyingPrice = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BuyingCurrencyCode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PricePer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ColorType = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PerSizeCons = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OrderQtyMultiple = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Quality = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProvisionalStyleRef = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BuyerDivisionSupplier = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SampleRef = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReorderLevel = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FiberType = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Micronaire = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Strength = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Staple = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CropSeason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CountCode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ConstructionCode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ContentName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SecondaryUOM = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SecondaryUOMConversion = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    StockMovementUOM = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StockMovementConversion = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    PicName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BillAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ShipAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    State = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ContactFirstName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ContactLastName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BusinessSegment = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductCategory = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Tolearancen = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    PaymentTerms = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DeliveryTerms = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ShipmentTerms = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PortOfLoading = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Category = table.Column<int>(type: "int", maxLength: 500, nullable: false),
                    CatalogPath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AccountGroup = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BankAddressDetails = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    VATNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CompanyWebsite = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Remakes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PicName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FabricComposition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialRequestId = table.Column<int>(type: "int", nullable: false),
                    ContentNameDesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Percentage = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricComposition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FabricComposition_MaterialRequest_MaterialRequestId",
                        column: x => x.MaterialRequestId,
                        principalTable: "MaterialRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MOQMSQRoudingOptionItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialRequestId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    From = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    To = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOQMSQRoudingOptionItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MOQMSQRoudingOptionItem_MaterialRequest_MaterialRequestId",
                        column: x => x.MaterialRequestId,
                        principalTable: "MaterialRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierWisePurchaseOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialRequestId = table.Column<int>(type: "int", nullable: false),
                    MOQRoundingType = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupplierCode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MOQ = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MOQSurChargeValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MOQSurchargeCurrency = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MCQ = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MCQSurchargeValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MCQSurchargeCurrency = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierWisePurchaseOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierWisePurchaseOption_MaterialRequest_MaterialRequestId",
                        column: x => x.MaterialRequestId,
                        principalTable: "MaterialRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FabricComposition_MaterialRequestId",
                table: "FabricComposition",
                column: "MaterialRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_MOQMSQRoudingOptionItem_MaterialRequestId",
                table: "MOQMSQRoudingOptionItem",
                column: "MaterialRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierWisePurchaseOption_MaterialRequestId",
                table: "SupplierWisePurchaseOption",
                column: "MaterialRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FabricComposition");

            migrationBuilder.DropTable(
                name: "MOQMSQRoudingOptionItem");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "SupplierWisePurchaseOption");

            migrationBuilder.DropTable(
                name: "MaterialRequest");
        }
    }
}
