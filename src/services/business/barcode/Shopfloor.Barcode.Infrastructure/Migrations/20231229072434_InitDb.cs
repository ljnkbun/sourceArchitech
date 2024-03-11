using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleBarcode",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Barcode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ArticleCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PONo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    RemainQuantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Shade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OC = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NumberOfCone = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    WeightPerCone = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CurrentLocationId = table.Column<int>(type: "int", nullable: true),
                    PreLocationId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleBarcode", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleBarcodeHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromId = table.Column<int>(type: "int", nullable: false),
                    ToId = table.Column<int>(type: "int", nullable: false),
                    MergeSplitType = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleBarcodeHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Export",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    GDIType = table.Column<byte>(type: "tinyint", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Export", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Import",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Import", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentLocationId = table.Column<int>(type: "int", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LevelLocation = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WfxGDI",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GDINum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GDICreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    GDIType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrderRefNum = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OrderCreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    WFXArticleCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WFXArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ColorName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SizeCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SizeName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FPPOOCNUm = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BuyerStyleRef = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RollNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RollBarcode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ParentRollBarcode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RollOCRefNum = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Shade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WareHouse = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InternalShade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GDIPendingUnits = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    RollUnits = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfxGDI", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WfxPOArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrderRefNum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrderCreationDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ArticleCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MaterialType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProductGroup = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ExecutionType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ColorName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SizeCode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OCNum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Units = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupplierRef = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupplierShortName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupplierCompanyID = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    OrderCompany = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StyleCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    StyleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    BuyerStyleNum = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    InternalLotNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    WashColorCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WashColorName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WfxPOArticle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExportArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ArticleCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExportId = table.Column<int>(type: "int", nullable: false),
                    GDINo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GDIType = table.Column<byte>(type: "tinyint", maxLength: 100, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    FromSite = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Buyer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SummaryOC = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DeliveryOC = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LotNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportArticle_Export_ExportId",
                        column: x => x.ExportId,
                        principalTable: "Export",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PONo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GDNNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FromSite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ToSite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrderRefNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ColorName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SizeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Units = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    OCNum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ImportId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportArticle_Import_ImportId",
                        column: x => x.ImportId,
                        principalTable: "Import",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarcodeLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    ArticleBarcodeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarcodeLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarcodeLocation_ArticleBarcode_ArticleBarcodeId",
                        column: x => x.ArticleBarcodeId,
                        principalTable: "ArticleBarcode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BarcodeLocation_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExportDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ArticleCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExportArticleId = table.Column<int>(type: "int", nullable: true),
                    ArticleBarcodeId = table.Column<int>(type: "int", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Shade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OC = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LotNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    WeightPerCone = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Yard = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Meter = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportDetail_ArticleBarcode_ArticleBarcodeId",
                        column: x => x.ArticleBarcodeId,
                        principalTable: "ArticleBarcode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExportDetail_ExportArticle_ExportArticleId",
                        column: x => x.ExportArticleId,
                        principalTable: "ExportArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ArticleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PONo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    Shade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumberOfCone = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    WeightPerCone = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ImportArticleId = table.Column<int>(type: "int", nullable: false),
                    AriticleBarcodeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportDetail_ArticleBarcode_AriticleBarcodeId",
                        column: x => x.AriticleBarcodeId,
                        principalTable: "ArticleBarcode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImportDetail_ImportArticle_ImportArticleId",
                        column: x => x.ImportArticleId,
                        principalTable: "ImportArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleBarcode_Barcode",
                table: "ArticleBarcode",
                column: "Barcode",
                unique: true,
                filter: "[Barcode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BarcodeLocation_ArticleBarcodeId",
                table: "BarcodeLocation",
                column: "ArticleBarcodeId");

            migrationBuilder.CreateIndex(
                name: "IX_BarcodeLocation_LocationId",
                table: "BarcodeLocation",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Export_Code",
                table: "Export",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportArticle_Code",
                table: "ExportArticle",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportArticle_ExportId",
                table: "ExportArticle",
                column: "ExportId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetail_ArticleBarcodeId",
                table: "ExportDetail",
                column: "ArticleBarcodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetail_Code",
                table: "ExportDetail",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetail_ExportArticleId",
                table: "ExportDetail",
                column: "ExportArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Import_Code",
                table: "Import",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImportArticle_ImportId",
                table: "ImportArticle",
                column: "ImportId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportDetail_AriticleBarcodeId",
                table: "ImportDetail",
                column: "AriticleBarcodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportDetail_ImportArticleId",
                table: "ImportDetail",
                column: "ImportArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_Code",
                table: "Location",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleBarcodeHistory");

            migrationBuilder.DropTable(
                name: "BarcodeLocation");

            migrationBuilder.DropTable(
                name: "ExportDetail");

            migrationBuilder.DropTable(
                name: "ImportDetail");

            migrationBuilder.DropTable(
                name: "WfxGDI");

            migrationBuilder.DropTable(
                name: "WfxPOArticle");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "ExportArticle");

            migrationBuilder.DropTable(
                name: "ArticleBarcode");

            migrationBuilder.DropTable(
                name: "ImportArticle");

            migrationBuilder.DropTable(
                name: "Export");

            migrationBuilder.DropTable(
                name: "Import");
        }
    }
}
