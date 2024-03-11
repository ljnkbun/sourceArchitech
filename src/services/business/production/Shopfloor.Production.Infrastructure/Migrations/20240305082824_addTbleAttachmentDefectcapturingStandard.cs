using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Production.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTbleAttachmentDefectcapturingStandard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ActualWeight",
                table: "ProductionOutput",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "AttachmentId",
                table: "ProductionOutput",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CaptureMeter",
                table: "ProductionOutput",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Grade",
                table: "ProductionOutput",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonInChargeId",
                table: "ProductionOutput",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PointSquareMeter",
                table: "ProductionOutput",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "ProductionOutput",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Result",
                table: "ProductionOutput",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "StockMovementNo",
                table: "ProductionOutput",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SystemResult",
                table: "ProductionOutput",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TotalContDefect",
                table: "ProductionOutput",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalDefect",
                table: "ProductionOutput",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPoint",
                table: "ProductionOutput",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "UserResult",
                table: "ProductionOutput",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "WarpDensity",
                table: "ProductionOutput",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeftDensity",
                table: "ProductionOutput",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WeightGM2",
                table: "ProductionOutput",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Remark",
                table: "InspectionBySize",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttachmentId",
                table: "DefectCapturing4Points",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttachmentId",
                table: "DefectCapturing100Points",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DefectCapturingStandard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionOutputId = table.Column<int>(type: "int", nullable: true),
                    QCDefectId = table.Column<int>(type: "int", nullable: true),
                    Defect = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RootCauseIds = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CorrectiveActionIds = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TimelineId = table.Column<int>(type: "int", nullable: true),
                    PersonInChargeIds = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectCapturingStandard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefectCapturingStandard_ProductionOutput_ProductionOutputId",
                        column: x => x.ProductionOutputId,
                        principalTable: "ProductionOutput",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionOutputId = table.Column<int>(type: "int", nullable: true),
                    DefectCapturing100PointsId = table.Column<int>(type: "int", nullable: true),
                    DefectCapturing4PointsId = table.Column<int>(type: "int", nullable: true),
                    DefectCapturingStandardId = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FileId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FileType = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachment_DefectCapturing100Points_DefectCapturing100PointsId",
                        column: x => x.DefectCapturing100PointsId,
                        principalTable: "DefectCapturing100Points",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attachment_DefectCapturing4Points_DefectCapturing4PointsId",
                        column: x => x.DefectCapturing4PointsId,
                        principalTable: "DefectCapturing4Points",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attachment_DefectCapturingStandard_DefectCapturingStandardId",
                        column: x => x.DefectCapturingStandardId,
                        principalTable: "DefectCapturingStandard",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attachment_ProductionOutput_ProductionOutputId",
                        column: x => x.ProductionOutputId,
                        principalTable: "ProductionOutput",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_DefectCapturing100PointsId",
                table: "Attachment",
                column: "DefectCapturing100PointsId",
                unique: true,
                filter: "[DefectCapturing100PointsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_DefectCapturing4PointsId",
                table: "Attachment",
                column: "DefectCapturing4PointsId",
                unique: true,
                filter: "[DefectCapturing4PointsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_DefectCapturingStandardId",
                table: "Attachment",
                column: "DefectCapturingStandardId",
                unique: true,
                filter: "[DefectCapturingStandardId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_ProductionOutputId",
                table: "Attachment",
                column: "ProductionOutputId",
                unique: true,
                filter: "[ProductionOutputId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DefectCapturingStandard_ProductionOutputId",
                table: "DefectCapturingStandard",
                column: "ProductionOutputId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "DefectCapturingStandard");

            migrationBuilder.DropColumn(
                name: "ActualWeight",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "CaptureMeter",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "PersonInChargeId",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "PointSquareMeter",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "StockMovementNo",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "SystemResult",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "TotalContDefect",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "TotalDefect",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "TotalPoint",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "UserResult",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "WarpDensity",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "WeftDensity",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "WeightGM2",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "Remark",
                table: "InspectionBySize");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "DefectCapturing4Points");

            migrationBuilder.DropColumn(
                name: "AttachmentId",
                table: "DefectCapturing100Points");
        }
    }
}
