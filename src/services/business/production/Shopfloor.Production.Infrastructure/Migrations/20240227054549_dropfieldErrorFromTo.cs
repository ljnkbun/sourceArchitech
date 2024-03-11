using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Production.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dropfieldErrorFromTo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongErrorFrom",
                table: "DefectCapturing");

            migrationBuilder.DropColumn(
                name: "LongErrorTo",
                table: "DefectCapturing");

            migrationBuilder.CreateTable(
                name: "DefectCapturing100Points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionOutputId = table.Column<int>(type: "int", nullable: true),
                    QCDefectId = table.Column<int>(type: "int", nullable: true),
                    Minor = table.Column<int>(type: "int", nullable: true),
                    Major = table.Column<int>(type: "int", nullable: true),
                    Critial = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    RootCausesId = table.Column<int>(type: "int", nullable: true),
                    PersonInChargeId = table.Column<int>(type: "int", nullable: true),
                    CorrectActionId = table.Column<int>(type: "int", nullable: true),
                    IsLongError = table.Column<byte>(type: "tinyint", nullable: true),
                    LongErrorFrom = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    LongErrorTo = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    ErrorCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ErrorName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RootCausesName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PersonInChargeName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CorrectActionName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Timeline = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectCapturing100Points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefectCapturing100Points_ProductionOutput_ProductionOutputId",
                        column: x => x.ProductionOutputId,
                        principalTable: "ProductionOutput",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DefectCapturing4Points",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionOutputId = table.Column<int>(type: "int", nullable: true),
                    QCDefectId = table.Column<int>(type: "int", nullable: true),
                    DefectQtyOne = table.Column<int>(type: "int", nullable: true),
                    DefectQtyTwo = table.Column<int>(type: "int", nullable: true),
                    DefectQtyThree = table.Column<int>(type: "int", nullable: true),
                    DefectQtyFour = table.Column<int>(type: "int", nullable: true),
                    MinorOne = table.Column<int>(type: "int", nullable: true),
                    MinorTwo = table.Column<int>(type: "int", nullable: true),
                    MinorThree = table.Column<int>(type: "int", nullable: true),
                    MinorFour = table.Column<int>(type: "int", nullable: true),
                    MajorOne = table.Column<int>(type: "int", nullable: true),
                    MajorTwo = table.Column<int>(type: "int", nullable: true),
                    MajorThree = table.Column<int>(type: "int", nullable: true),
                    MajorFour = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    RootCausesId = table.Column<int>(type: "int", nullable: true),
                    PersonInChargeId = table.Column<int>(type: "int", nullable: true),
                    CorrectActionId = table.Column<int>(type: "int", nullable: true),
                    IsLongError = table.Column<byte>(type: "tinyint", nullable: true),
                    LongErrorFrom = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    LongErrorTo = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    ErrorCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ErrorName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RootCausesName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PersonInChargeName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CorrectActionName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Timeline = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectCapturing4Points", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefectCapturing4Points_ProductionOutput_ProductionOutputId",
                        column: x => x.ProductionOutputId,
                        principalTable: "ProductionOutput",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefectCapturing100Points_ProductionOutputId",
                table: "DefectCapturing100Points",
                column: "ProductionOutputId");

            migrationBuilder.CreateIndex(
                name: "IX_DefectCapturing4Points_ProductionOutputId",
                table: "DefectCapturing4Points",
                column: "ProductionOutputId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefectCapturing100Points");

            migrationBuilder.DropTable(
                name: "DefectCapturing4Points");

            migrationBuilder.AddColumn<DateTime>(
                name: "LongErrorFrom",
                table: "DefectCapturing",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<DateTime>(
                name: "LongErrorTo",
                table: "DefectCapturing",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())");
        }
    }
}
