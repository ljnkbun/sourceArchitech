using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQCRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QCRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QCType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QCRequestDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SiteCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SiteName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    QCRequestNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    QCRequestStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    TransferStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    DocumentNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WFXQCDefName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    QCDefinitionCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RequestedQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QCRequest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QCRequestArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QCRequestId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Shade = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Lot = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StyleNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    StyleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Season = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Buyer = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FPONo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    OCNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GRNNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PONo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GRNDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequestedQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QCRequestArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QCRequestArticle_QCRequest_QCRequestId",
                        column: x => x.QCRequestId,
                        principalTable: "QCRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QCRequestDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QCRequestArticleId = table.Column<int>(type: "int", nullable: false),
                    ColorCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ColorName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SizeCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SizeName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RequestedQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    QCReleasedQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    GRNQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QCRequestDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QCRequestDetail_QCRequestArticle_QCRequestArticleId",
                        column: x => x.QCRequestArticleId,
                        principalTable: "QCRequestArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QCRequestArticle_QCRequestId",
                table: "QCRequestArticle",
                column: "QCRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_QCRequestDetail_QCRequestArticleId",
                table: "QCRequestDetail",
                column: "QCRequestArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QCRequestDetail");

            migrationBuilder.DropTable(
                name: "QCRequestArticle");

            migrationBuilder.DropTable(
                name: "QCRequest");
        }
    }
}
