using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Production.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTbleDefectcapturingMeasurement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductionOuputId",
                table: "InspectionBySize",
                newName: "ProductionOutputId");

            migrationBuilder.CreateTable(
                name: "DefectCapturing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionOutputId = table.Column<int>(type: "int", nullable: true),
                    QCDefectId = table.Column<int>(type: "int", nullable: true),
                    Minor = table.Column<int>(type: "int", nullable: true),
                    Major = table.Column<int>(type: "int", nullable: true),
                    Critical = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    RootCausesId = table.Column<int>(type: "int", nullable: true),
                    PersonInChargeId = table.Column<int>(type: "int", nullable: true),
                    CorrectActionId = table.Column<int>(type: "int", nullable: true),
                    IsLongError = table.Column<byte>(type: "tinyint", nullable: true),
                    LongErrorFrom = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    LongErrorTo = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
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
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectCapturing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefectCapturing_ProductionOutput_ProductionOutputId",
                        column: x => x.ProductionOutputId,
                        principalTable: "ProductionOutput",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measurement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionOutputId = table.Column<int>(type: "int", nullable: true),
                    QCDefectId = table.Column<int>(type: "int", nullable: true),
                    Minor = table.Column<int>(type: "int", nullable: true),
                    Major = table.Column<int>(type: "int", nullable: true),
                    Critical = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    RootCausesId = table.Column<int>(type: "int", nullable: true),
                    PersonInChargeId = table.Column<int>(type: "int", nullable: true),
                    CorrectActionId = table.Column<int>(type: "int", nullable: true),
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
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measurement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measurement_ProductionOutput_ProductionOutputId",
                        column: x => x.ProductionOutputId,
                        principalTable: "ProductionOutput",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InspectionBySize_ProductionOutputId",
                table: "InspectionBySize",
                column: "ProductionOutputId");

            migrationBuilder.CreateIndex(
                name: "IX_DefectCapturing_ProductionOutputId",
                table: "DefectCapturing",
                column: "ProductionOutputId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurement_ProductionOutputId",
                table: "Measurement",
                column: "ProductionOutputId");

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionBySize_ProductionOutput_ProductionOutputId",
                table: "InspectionBySize",
                column: "ProductionOutputId",
                principalTable: "ProductionOutput",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InspectionBySize_ProductionOutput_ProductionOutputId",
                table: "InspectionBySize");

            migrationBuilder.DropTable(
                name: "DefectCapturing");

            migrationBuilder.DropTable(
                name: "Measurement");

            migrationBuilder.DropIndex(
                name: "IX_InspectionBySize_ProductionOutputId",
                table: "InspectionBySize");

            migrationBuilder.RenameColumn(
                name: "ProductionOutputId",
                table: "InspectionBySize",
                newName: "ProductionOuputId");
        }
    }
}
