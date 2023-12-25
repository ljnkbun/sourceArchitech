using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImportTransferToSite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ArticleBarcode",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CurrentLocationId",
                table: "ArticleBarcode",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "ImportTransferToSite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNote = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
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
                    table.PrimaryKey("PK_ImportTransferToSite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImportTransferToSiteSync",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ArticleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    UOM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StoringUOM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GDNNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FromSite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ToSite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LotNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportTransferToSiteSync", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImportTransferToSiteArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GDNNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FromSite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ToSite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImportTransferToSiteId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    OC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LotNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                name: "ImportTransferToSiteDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<byte>(type: "tinyint", nullable: true),
                    ColorCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SizeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Yard = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Meter = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Unit = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Note = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ImportTransferToSiteArticleId = table.Column<int>(type: "int", nullable: false),
                    OC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Shade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AriticleBarcodeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportTransferToSiteDetail");

            migrationBuilder.DropTable(
                name: "ImportTransferToSiteSync");

            migrationBuilder.DropTable(
                name: "ImportTransferToSiteArticle");

            migrationBuilder.DropTable(
                name: "ImportTransferToSite");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ArticleBarcode",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CurrentLocationId",
                table: "ArticleBarcode",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
