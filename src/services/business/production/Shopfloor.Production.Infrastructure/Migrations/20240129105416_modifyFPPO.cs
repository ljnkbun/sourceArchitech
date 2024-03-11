using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Production.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyFPPO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReceivedQty",
                table: "FPPOOutputDetail",
                newName: "UpdatedToDate");

            migrationBuilder.RenameColumn(
                name: "ReallocationQty",
                table: "FPPOOutputDetail",
                newName: "RejectedQty");

            migrationBuilder.RenameColumn(
                name: "OrderedQty",
                table: "FPPOOutputDetail",
                newName: "OKQty");

            migrationBuilder.RenameColumn(
                name: "OpenQty",
                table: "FPPOOutputDetail",
                newName: "FPPOQty");

            migrationBuilder.RenameColumn(
                name: "Process",
                table: "FPPOOutput",
                newName: "ProcessCode");

            migrationBuilder.RenameColumn(
                name: "FactoryProcessId",
                table: "FPPOOutput",
                newName: "ProcessId");

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

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "FPPOOutputDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "FPPOOutputDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UOM",
                table: "FPPOOutputDetail",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FPPOId",
                table: "FPPOOutput",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperationCode",
                table: "FPPOOutput",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OperationId",
                table: "FPPOOutput",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProcessName",
                table: "FPPOOutput",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BGroupQty",
                table: "FPPOOutputDetail");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "FPPOOutputDetail");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "FPPOOutputDetail");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "FPPOOutputDetail");

            migrationBuilder.DropColumn(
                name: "UOM",
                table: "FPPOOutputDetail");

            migrationBuilder.DropColumn(
                name: "FPPOId",
                table: "FPPOOutput");

            migrationBuilder.DropColumn(
                name: "OperationCode",
                table: "FPPOOutput");

            migrationBuilder.DropColumn(
                name: "OperationId",
                table: "FPPOOutput");

            migrationBuilder.DropColumn(
                name: "ProcessName",
                table: "FPPOOutput");

            migrationBuilder.RenameColumn(
                name: "UpdatedToDate",
                table: "FPPOOutputDetail",
                newName: "ReceivedQty");

            migrationBuilder.RenameColumn(
                name: "RejectedQty",
                table: "FPPOOutputDetail",
                newName: "ReallocationQty");

            migrationBuilder.RenameColumn(
                name: "OKQty",
                table: "FPPOOutputDetail",
                newName: "OrderedQty");

            migrationBuilder.RenameColumn(
                name: "FPPOQty",
                table: "FPPOOutputDetail",
                newName: "OpenQty");

            migrationBuilder.RenameColumn(
                name: "ProcessId",
                table: "FPPOOutput",
                newName: "FactoryProcessId");

            migrationBuilder.RenameColumn(
                name: "ProcessCode",
                table: "FPPOOutput",
                newName: "Process");
        }
    }
}
