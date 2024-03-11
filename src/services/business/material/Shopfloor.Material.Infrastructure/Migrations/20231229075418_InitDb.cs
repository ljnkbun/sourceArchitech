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
                name: "AutoIncrement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Separate = table.Column<string>(type: "varchar(10)", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false),
                    IndexFormat = table.Column<string>(type: "varchar(10)", nullable: true),
                    InputValue = table.Column<string>(type: "varchar(100)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoIncrement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buyer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Address3 = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    BillAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ShipAddress = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CurrencyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BuyerType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BuyerTypeName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ContactFirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ContactLastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Tolearance = table.Column<decimal>(type: "decimal(18,2)", maxLength: 10, nullable: true),
                    PaymentTerms = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    DeliveryTerms = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ShipmentTerms = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    FinalDestination = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CountryOfFinalDestination = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PortofDischarge = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GroupNameCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AccountGroup = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AccountGroupName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PAN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TIN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Market = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CustomHouse = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BankAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    VATNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    SwiftCode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Department = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MaximumOutAmount = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    ApproveUserId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ApproveName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReasonReject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRetailer = table.Column<bool>(type: "bit", nullable: false),
                    IsWholesaler = table.Column<bool>(type: "bit", nullable: false),
                    IsManufacture = table.Column<bool>(type: "bit", nullable: false),
                    IsTransporter = table.Column<bool>(type: "bit", nullable: false),
                    IsBuying = table.Column<bool>(type: "bit", nullable: false),
                    IsServiceProvider = table.Column<bool>(type: "bit", nullable: false),
                    IsBrand = table.Column<bool>(type: "bit", nullable: false),
                    IsComposition = table.Column<bool>(type: "bit", nullable: false),
                    IsOther = table.Column<bool>(type: "bit", nullable: false),
                    SegmentOther = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buyer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DynamicColumn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(200)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FieldType = table.Column<int>(type: "int", nullable: false),
                    IsContent = table.Column<bool>(type: "bit", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    CategoryCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    DisplayIndex = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicColumn", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    ProductCatCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    ProductCatName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MaterialTypeCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MaterialTypeName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ArticleCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ArticleDesc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProductGroupCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    ProductGroupName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProductSubCatCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    ProductSubCatName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ThemeCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    ThemeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OurContactCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    OurContactName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UomCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    UomName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StoringUomCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    StoringUomName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ConsUomCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    ConsUomName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SeasonCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    SeasonName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DivisionCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    DivisionName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ColorGroupCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    ColorGroupName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SizeGroupCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    SizeGroupName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BuyerCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    BuyerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BuyerRef = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupplierCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SupplierRef = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GenderCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    GenderName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Brand = table.Column<string>(type: "varchar(200)", nullable: true),
                    BuyingPrice = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BuyingCurrencyCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    BuyingCurrencyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PricePerCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    PricePerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ColorTypeCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    ColorTypeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PerSizeConsCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    PerSizeConsName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OrderQtyMultiple = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QualityCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    QualityName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ProvisionalStyleRef = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BuyerDivisionSupplierCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    BuyerDivisionSupplierName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SampleRef = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReorderLevel = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FiberTypeCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    FiberTypeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    GradeCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    GradeName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MicronaireCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    MicronaireName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StrengthCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    StrengthName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StapleCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    StapleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CropSeasonCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    CropSeasonName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    OriginCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    OriginName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CountCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    CountName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ConstructionCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    ConstructionName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ContentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SecondaryUomCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    SecondaryUomName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SecondaryUomConversion = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    StockMovementUomCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    StockMovementUomName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StockMovementConversion = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    CatalogPath = table.Column<string>(type: "varchar(200)", nullable: true),
                    DesignAndPattern = table.Column<string>(type: "varchar(200)", nullable: true),
                    DesignAndPatternName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InternalPrice = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Finish = table.Column<string>(type: "varchar(200)", nullable: true),
                    HSNCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    MinimumOrder = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MinimumQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MaximumQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MinimumOrderQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    RequirementMultiple = table.Column<string>(type: "varchar(200)", nullable: true),
                    HTSCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ArticleNameChinese = table.Column<string>(type: "varchar(200)", nullable: true),
                    FabricAndMaterial = table.Column<string>(type: "varchar(200)", nullable: true),
                    PicName = table.Column<string>(type: "varchar(200)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    ApproveUserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 200, nullable: true),
                    ApproveName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReasonReject = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "PriceList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    CategoryCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupplierCode = table.Column<string>(type: "varchar(200)", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    ApproveUserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 200, nullable: true),
                    ApproveName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ReasonReject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BillAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ShipAddress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(30)", nullable: true),
                    CountryCode = table.Column<string>(type: "varchar(100)", nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CategoryCode = table.Column<string>(type: "varchar(100)", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Telephone = table.Column<string>(type: "varchar(100)", nullable: true),
                    CurrencyCode = table.Column<string>(type: "varchar(100)", nullable: true),
                    CurrencyName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ContactFirstName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ContactLastName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "varchar(250)", nullable: true),
                    Tolearancen = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    PaymentTerms = table.Column<string>(type: "varchar(100)", nullable: true),
                    DeliveryTerms = table.Column<string>(type: "varchar(100)", nullable: true),
                    ShipmentTerms = table.Column<string>(type: "varchar(100)", nullable: true),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PortOfLoading = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GroupNameCode = table.Column<string>(type: "varchar(100)", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CatalogPath = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AccountGroupCode = table.Column<string>(type: "varchar(100)", nullable: true),
                    AccountGroupName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BankAccountNumber = table.Column<string>(type: "varchar(100)", nullable: true),
                    BankAddressDetails = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    VATNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CompanyWebsite = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Remakes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PicName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    CompanyId = table.Column<string>(type: "varchar(200)", nullable: true),
                    Pan = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Tin = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CustomHouse = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupplierTypeCode = table.Column<string>(type: "varchar(100)", nullable: true),
                    SupplierTypeName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ApproveUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApproveName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ReasonReject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRetailer = table.Column<bool>(type: "bit", nullable: false),
                    IsWholesaler = table.Column<bool>(type: "bit", nullable: false),
                    IsManufacture = table.Column<bool>(type: "bit", nullable: false),
                    IsTransporter = table.Column<bool>(type: "bit", nullable: false),
                    IsBuying = table.Column<bool>(type: "bit", nullable: false),
                    IsServiceProvider = table.Column<bool>(type: "bit", nullable: false),
                    IsBrand = table.Column<bool>(type: "bit", nullable: false),
                    IsComposition = table.Column<bool>(type: "bit", nullable: false),
                    IsOther = table.Column<bool>(type: "bit", nullable: false),
                    SegmentOther = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SwiftCode = table.Column<string>(type: "varchar(100)", nullable: true),
                    MaximumOutAmount = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
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
                name: "BuyerProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    CategoryCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BuyerProductCategory_Buyer_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "Buyer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DynamicColumnContent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DynamicColumnId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "varchar(200)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicColumnContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicColumnContent_DynamicColumn_DynamicColumnId",
                        column: x => x.DynamicColumnId,
                        principalTable: "DynamicColumn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "MaterialRequestDynamicColumn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialRequestId = table.Column<int>(type: "int", nullable: false),
                    DynamicColumnId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialRequestDynamicColumn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialRequestDynamicColumn_DynamicColumn_DynamicColumnId",
                        column: x => x.DynamicColumnId,
                        principalTable: "DynamicColumn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialRequestDynamicColumn_MaterialRequest_MaterialRequestId",
                        column: x => x.MaterialRequestId,
                        principalTable: "MaterialRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialRequestFile",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialRequestId = table.Column<int>(type: "int", nullable: false),
                    FileType = table.Column<byte>(type: "tinyint", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FileId = table.Column<string>(type: "varchar(50)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialRequestFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialRequestFile_MaterialRequest_MaterialRequestId",
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
                    MoqRoundingTypeId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupplierId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Moq = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MoqSurChargeValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MoqSurchargeCurrency = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Mcq = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    McqSurchargeValue = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    McqSurchargeCurrency = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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

            migrationBuilder.CreateTable(
                name: "PriceListDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceListId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MaterialCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Uom = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DeliveryTerm = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceListDetail_PriceList_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(200)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierProductCategory_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceListDetailColor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PriceListDetailId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListDetailColor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceListDetailColor_PriceListDetail_PriceListDetailId",
                        column: x => x.PriceListDetailId,
                        principalTable: "PriceListDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceListDetailSize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PriceListDetailId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceListDetailSize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceListDetailSize_PriceListDetail_PriceListDetailId",
                        column: x => x.PriceListDetailId,
                        principalTable: "PriceListDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buyer_Code",
                table: "Buyer",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuyerProductCategory_BuyerId",
                table: "BuyerProductCategory",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicColumnContent_DynamicColumnId",
                table: "DynamicColumnContent",
                column: "DynamicColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_FabricComposition_MaterialRequestId",
                table: "FabricComposition",
                column: "MaterialRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRequestDynamicColumn_DynamicColumnId",
                table: "MaterialRequestDynamicColumn",
                column: "DynamicColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRequestDynamicColumn_MaterialRequestId",
                table: "MaterialRequestDynamicColumn",
                column: "MaterialRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRequestFile_MaterialRequestId",
                table: "MaterialRequestFile",
                column: "MaterialRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_MOQMSQRoudingOptionItem_MaterialRequestId",
                table: "MOQMSQRoudingOptionItem",
                column: "MaterialRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListDetail_PriceListId",
                table: "PriceListDetail",
                column: "PriceListId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListDetailColor_PriceListDetailId",
                table: "PriceListDetailColor",
                column: "PriceListDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceListDetailSize_PriceListDetailId",
                table: "PriceListDetailSize",
                column: "PriceListDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProductCategory_SupplierId",
                table: "SupplierProductCategory",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierWisePurchaseOption_MaterialRequestId",
                table: "SupplierWisePurchaseOption",
                column: "MaterialRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoIncrement");

            migrationBuilder.DropTable(
                name: "BuyerProductCategory");

            migrationBuilder.DropTable(
                name: "DynamicColumnContent");

            migrationBuilder.DropTable(
                name: "FabricComposition");

            migrationBuilder.DropTable(
                name: "MaterialRequestDynamicColumn");

            migrationBuilder.DropTable(
                name: "MaterialRequestFile");

            migrationBuilder.DropTable(
                name: "MOQMSQRoudingOptionItem");

            migrationBuilder.DropTable(
                name: "PriceListDetailColor");

            migrationBuilder.DropTable(
                name: "PriceListDetailSize");

            migrationBuilder.DropTable(
                name: "SupplierProductCategory");

            migrationBuilder.DropTable(
                name: "SupplierWisePurchaseOption");

            migrationBuilder.DropTable(
                name: "Buyer");

            migrationBuilder.DropTable(
                name: "DynamicColumn");

            migrationBuilder.DropTable(
                name: "PriceListDetail");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "MaterialRequest");

            migrationBuilder.DropTable(
                name: "PriceList");
        }
    }
}
