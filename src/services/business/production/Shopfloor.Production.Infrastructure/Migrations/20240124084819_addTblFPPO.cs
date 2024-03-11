using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Production.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTblFPPO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LotNo",
                table: "InspectionBySize",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shade",
                table: "InspectionBySize",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FPPOOutput",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WFXArticleId = table.Column<int>(type: "int", nullable: true),
                    ArticleCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PORId = table.Column<int>(type: "int", nullable: true),
                    FactoryProcessId = table.Column<int>(type: "int", nullable: true),
                    LineId = table.Column<int>(type: "int", nullable: true),
                    MachineId = table.Column<int>(type: "int", nullable: true),
                    OCNo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FPPONo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PORNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Process = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OperationName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Style = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RequiredQty = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Start = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    End = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FPPOOutput", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FPPOOutputDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FPPOOutputId = table.Column<int>(type: "int", nullable: true),
                    OrderedQty = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    ReceivedQty = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    ReallocationQty = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    OpenQty = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FPPOOutputDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FPPOOutputDetail_FPPOOutput_FPPOOutputId",
                        column: x => x.FPPOOutputId,
                        principalTable: "FPPOOutput",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FPPOOutputDetail_FPPOOutputId",
                table: "FPPOOutputDetail",
                column: "FPPOOutputId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FPPOOutputDetail");

            migrationBuilder.DropTable(
                name: "FPPOOutput");

            migrationBuilder.DropColumn(
                name: "LotNo",
                table: "InspectionBySize");

            migrationBuilder.DropColumn(
                name: "Shade",
                table: "InspectionBySize");
        }
    }
}
