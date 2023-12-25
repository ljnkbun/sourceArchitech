using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addArticleBarcodeHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportPODetail");

            migrationBuilder.DropTable(
                name: "ImportTransferToSiteDetail");

            migrationBuilder.DropTable(
                name: "ImportPOArticle");

            migrationBuilder.DropTable(
                name: "ImportTransferToSiteArticle");

            migrationBuilder.DropTable(
                name: "ImportPO");

            migrationBuilder.DropTable(
                name: "ImportTransferToSite");

            migrationBuilder.DropIndex(
                name: "IX_ExportDetail_ArticleBarcodeId",
                table: "ExportDetail");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "ArticleBarcode",
                newName: "PreLocationId");

            migrationBuilder.AddColumn<string>(
                name: "ArticleCode",
                table: "ArticleBarcode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleName",
                table: "ArticleBarcode",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "ArticleBarcode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ArticleBarcode",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "ArticleBarcode",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NumberOfCone",
                table: "ArticleBarcode",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OC",
                table: "ArticleBarcode",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "ArticleBarcode",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RemainQuantity",
                table: "ArticleBarcode",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shade",
                table: "ArticleBarcode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "ArticleBarcode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UOM",
                table: "ArticleBarcode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "ArticleBarcode",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WeightPerCone",
                table: "ArticleBarcode",
                type: "decimal(28,8)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetail_ArticleBarcodeId",
                table: "ExportDetail",
                column: "ArticleBarcodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleBarcodeHistory");

            migrationBuilder.DropIndex(
                name: "IX_ExportDetail_ArticleBarcodeId",
                table: "ExportDetail");

            migrationBuilder.DropColumn(
                name: "ArticleCode",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "ArticleName",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "NumberOfCone",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "OC",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "RemainQuantity",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "Shade",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "UOM",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "ArticleBarcode");

            migrationBuilder.DropColumn(
                name: "WeightPerCone",
                table: "ArticleBarcode");

            migrationBuilder.RenameColumn(
                name: "PreLocationId",
                table: "ArticleBarcode",
                newName: "ParentId");

            migrationBuilder.CreateTable(
                name: "ImportPO",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportPO", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImportTransferToSite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DocumentNote = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportTransferToSite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImportPOArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImportPOId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    Buyer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LotNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OC = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PONo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SourceASNNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportPOArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportPOArticle_ImportPO_ImportPOId",
                        column: x => x.ImportPOId,
                        principalTable: "ImportPO",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportTransferToSiteArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImportTransferToSiteId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FromSite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GDNNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LotNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ToSite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportTransferToSiteArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportTransferToSiteArticle_ImportTransferToSite_ImportTransferToSiteId",
                        column: x => x.ImportTransferToSiteId,
                        principalTable: "ImportTransferToSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportPODetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleBarcodeId = table.Column<int>(type: "int", nullable: true),
                    ImportPOArticleId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LotNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Meter = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    OC = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Shade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Unit = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Yard = table.Column<decimal>(type: "decimal(28,8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportPODetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportPODetail_ArticleBarcode_ArticleBarcodeId",
                        column: x => x.ArticleBarcodeId,
                        principalTable: "ArticleBarcode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImportPODetail_ImportPOArticle_ImportPOArticleId",
                        column: x => x.ImportPOArticleId,
                        principalTable: "ImportPOArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImportTransferToSiteDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AriticleBarcodeId = table.Column<int>(type: "int", nullable: false),
                    ImportTransferToSiteArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NumberOfCone = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    OC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Shade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WeightPerCone = table.Column<decimal>(type: "decimal(28,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportTransferToSiteDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportTransferToSiteDetail_ArticleBarcode_AriticleBarcodeId",
                        column: x => x.AriticleBarcodeId,
                        principalTable: "ArticleBarcode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImportTransferToSiteDetail_ImportTransferToSiteArticle_ImportTransferToSiteArticleId",
                        column: x => x.ImportTransferToSiteArticleId,
                        principalTable: "ImportTransferToSiteArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExportDetail_ArticleBarcodeId",
                table: "ExportDetail",
                column: "ArticleBarcodeId",
                unique: true,
                filter: "[ArticleBarcodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ImportPO_Code",
                table: "ImportPO",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImportPOArticle_Code",
                table: "ImportPOArticle",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImportPOArticle_ImportPOId",
                table: "ImportPOArticle",
                column: "ImportPOId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportPODetail_ArticleBarcodeId",
                table: "ImportPODetail",
                column: "ArticleBarcodeId",
                unique: true,
                filter: "[ArticleBarcodeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ImportPODetail_Code",
                table: "ImportPODetail",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImportPODetail_ImportPOArticleId",
                table: "ImportPODetail",
                column: "ImportPOArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportTransferToSite_Code",
                table: "ImportTransferToSite",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImportTransferToSiteArticle_ImportTransferToSiteId",
                table: "ImportTransferToSiteArticle",
                column: "ImportTransferToSiteId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportTransferToSiteDetail_AriticleBarcodeId",
                table: "ImportTransferToSiteDetail",
                column: "AriticleBarcodeId");

            migrationBuilder.CreateIndex(
                name: "IX_ImportTransferToSiteDetail_ImportTransferToSiteArticleId",
                table: "ImportTransferToSiteDetail",
                column: "ImportTransferToSiteArticleId");
        }
    }
}
