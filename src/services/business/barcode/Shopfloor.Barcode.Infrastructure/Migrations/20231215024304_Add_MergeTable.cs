using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Barcode.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_MergeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Meter",
                table: "ImportTransferToSiteDetail");

            migrationBuilder.RenameColumn(
                name: "Yard",
                table: "ImportTransferToSiteDetail",
                newName: "NumberOfCone");

            migrationBuilder.RenameColumn(
                name: "SizeCode",
                table: "ImportTransferToSiteDetail",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "ColorCode",
                table: "ImportTransferToSiteDetail",
                newName: "Color");

            migrationBuilder.AlterColumn<decimal>(
                name: "Qty",
                table: "ImportTransferToSiteSync",
                type: "decimal(28,8)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Unit",
                table: "ImportTransferToSiteDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ArticleCode",
                table: "ImportTransferToSiteDetail",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleName",
                table: "ImportTransferToSiteDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ImportTransferToSiteDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "ImportTransferToSiteDetail",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WeightPerCone",
                table: "ImportTransferToSiteDetail",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<decimal>(
                name: "Qty",
                table: "ImportTransferToSiteArticle",
                type: "decimal(28,8)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValue: 0);

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
                name: "ImportArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GDNNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FromSite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ToSite = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImportId = table.Column<int>(type: "int", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Buyer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PONo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SourceASNNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
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
                    table.PrimaryKey("PK_ImportArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImportArticle_Import_ImportId",
                        column: x => x.ImportId,
                        principalTable: "Import",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImportDetail");

            migrationBuilder.DropTable(
                name: "ImportArticle");

            migrationBuilder.DropTable(
                name: "Import");

            migrationBuilder.DropColumn(
                name: "ArticleCode",
                table: "ImportTransferToSiteDetail");

            migrationBuilder.DropColumn(
                name: "ArticleName",
                table: "ImportTransferToSiteDetail");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ImportTransferToSiteDetail");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ImportTransferToSiteDetail");

            migrationBuilder.DropColumn(
                name: "WeightPerCone",
                table: "ImportTransferToSiteDetail");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "ImportTransferToSiteDetail",
                newName: "SizeCode");

            migrationBuilder.RenameColumn(
                name: "NumberOfCone",
                table: "ImportTransferToSiteDetail",
                newName: "Yard");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "ImportTransferToSiteDetail",
                newName: "ColorCode");

            migrationBuilder.AlterColumn<int>(
                name: "Qty",
                table: "ImportTransferToSiteSync",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Unit",
                table: "ImportTransferToSiteDetail",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Meter",
                table: "ImportTransferToSiteDetail",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Qty",
                table: "ImportTransferToSiteArticle",
                type: "int",
                nullable: true,
                defaultValue: 0,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)",
                oldNullable: true);
        }
    }
}
