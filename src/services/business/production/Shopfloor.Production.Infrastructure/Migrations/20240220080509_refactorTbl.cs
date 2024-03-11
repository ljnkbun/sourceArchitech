using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Production.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class refactorTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FPPOOutputDetail_FPPOOutput_FPPOOutputId",
                table: "FPPOOutputDetail");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "End",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "FPPONo",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "FRBalance",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "FRUpdateToDate",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "Line",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "OCNo",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "OperationName",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "Strip",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "UpdateToDate",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "Barcode",
                table: "InspectionBySize");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "InspectionBySize");

            migrationBuilder.DropColumn(
                name: "LotNo",
                table: "InspectionBySize");

            migrationBuilder.DropColumn(
                name: "Shade",
                table: "InspectionBySize");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "InspectionBySize");

            migrationBuilder.DropColumn(
                name: "UOM",
                table: "InspectionBySize");

            migrationBuilder.DropColumn(
                name: "BGroupQty",
                table: "FPPOOutputDetail");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "FPPOOutputDetail");

            migrationBuilder.DropColumn(
                name: "FPPOQty",
                table: "FPPOOutputDetail");

            migrationBuilder.DropColumn(
                name: "UOM",
                table: "FPPOOutputDetail");

            migrationBuilder.DropColumn(
                name: "RequiredQty",
                table: "FPPOOutput");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "ProductionOutput",
                newName: "WFXExportDate");

            migrationBuilder.RenameColumn(
                name: "Group",
                table: "ProductionOutput",
                newName: "Remarks");

            migrationBuilder.RenameColumn(
                name: "FPPOId",
                table: "ProductionOutput",
                newName: "FPPOOutputId");

            migrationBuilder.RenameColumn(
                name: "UpdatedToDate",
                table: "InspectionBySize",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "FPPOQty",
                table: "InspectionBySize",
                newName: "WeftDensity");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "InspectionBySize",
                newName: "WarpDensity");

            migrationBuilder.RenameColumn(
                name: "UpdatedToDate",
                table: "FPPOOutputDetail",
                newName: "PlannedQty");

            migrationBuilder.RenameColumn(
                name: "RejectedQty",
                table: "FPPOOutputDetail",
                newName: "MadeQty");

            migrationBuilder.RenameColumn(
                name: "OKQty",
                table: "FPPOOutputDetail",
                newName: "BalanceQty");

            migrationBuilder.RenameColumn(
                name: "Style",
                table: "FPPOOutput",
                newName: "UOM");

            migrationBuilder.AddColumn<byte>(
                name: "WFXExportStatus",
                table: "ProductionOutput",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ActualWeight",
                table: "InspectionBySize",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CaptureMeter",
                table: "InspectionBySize",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CuttingWidth",
                table: "InspectionBySize",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FPPOOutputDetailId",
                table: "InspectionBySize",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Length",
                table: "InspectionBySize",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MadeQty",
                table: "InspectionBySize",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QCDefinationId",
                table: "FPPOOutput",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QCName",
                table: "FPPOOutput",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionBySize_FPPOOutputDetailId",
                table: "InspectionBySize",
                column: "FPPOOutputDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_FPPOOutputDetail_FPPOOutput_FPPOOutputId",
                table: "FPPOOutputDetail",
                column: "FPPOOutputId",
                principalTable: "FPPOOutput",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InspectionBySize_FPPOOutputDetail_FPPOOutputDetailId",
                table: "InspectionBySize",
                column: "FPPOOutputDetailId",
                principalTable: "FPPOOutputDetail",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FPPOOutputDetail_FPPOOutput_FPPOOutputId",
                table: "FPPOOutputDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_InspectionBySize_FPPOOutputDetail_FPPOOutputDetailId",
                table: "InspectionBySize");

            migrationBuilder.DropIndex(
                name: "IX_InspectionBySize_FPPOOutputDetailId",
                table: "InspectionBySize");

            migrationBuilder.DropColumn(
                name: "WFXExportStatus",
                table: "ProductionOutput");

            migrationBuilder.DropColumn(
                name: "ActualWeight",
                table: "InspectionBySize");

            migrationBuilder.DropColumn(
                name: "CaptureMeter",
                table: "InspectionBySize");

            migrationBuilder.DropColumn(
                name: "CuttingWidth",
                table: "InspectionBySize");

            migrationBuilder.DropColumn(
                name: "FPPOOutputDetailId",
                table: "InspectionBySize");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "InspectionBySize");

            migrationBuilder.DropColumn(
                name: "MadeQty",
                table: "InspectionBySize");

            migrationBuilder.DropColumn(
                name: "QCDefinationId",
                table: "FPPOOutput");

            migrationBuilder.DropColumn(
                name: "QCName",
                table: "FPPOOutput");

            migrationBuilder.RenameColumn(
                name: "WFXExportDate",
                table: "ProductionOutput",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "Remarks",
                table: "ProductionOutput",
                newName: "Group");

            migrationBuilder.RenameColumn(
                name: "FPPOOutputId",
                table: "ProductionOutput",
                newName: "FPPOId");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "InspectionBySize",
                newName: "UpdatedToDate");

            migrationBuilder.RenameColumn(
                name: "WeftDensity",
                table: "InspectionBySize",
                newName: "FPPOQty");

            migrationBuilder.RenameColumn(
                name: "WarpDensity",
                table: "InspectionBySize",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "PlannedQty",
                table: "FPPOOutputDetail",
                newName: "UpdatedToDate");

            migrationBuilder.RenameColumn(
                name: "MadeQty",
                table: "FPPOOutputDetail",
                newName: "RejectedQty");

            migrationBuilder.RenameColumn(
                name: "BalanceQty",
                table: "FPPOOutputDetail",
                newName: "OKQty");

            migrationBuilder.RenameColumn(
                name: "UOM",
                table: "FPPOOutput",
                newName: "Style");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "ProductionOutput",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "ProductionOutput",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<string>(
                name: "FPPONo",
                table: "ProductionOutput",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FRBalance",
                table: "ProductionOutput",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FRUpdateToDate",
                table: "ProductionOutput",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Line",
                table: "ProductionOutput",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OCNo",
                table: "ProductionOutput",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperationName",
                table: "ProductionOutput",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Strip",
                table: "ProductionOutput",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "UpdateToDate",
                table: "ProductionOutput",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                table: "InspectionBySize",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "InspectionBySize",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "InspectionBySize",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UOM",
                table: "InspectionBySize",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BGroupQty",
                table: "FPPOOutputDetail",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "FPPOOutputDetail",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FPPOQty",
                table: "FPPOOutputDetail",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UOM",
                table: "FPPOOutputDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "RequiredQty",
                table: "FPPOOutput",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FPPOOutputDetail_FPPOOutput_FPPOOutputId",
                table: "FPPOOutputDetail",
                column: "FPPOOutputId",
                principalTable: "FPPOOutput",
                principalColumn: "Id");
        }
    }
}
