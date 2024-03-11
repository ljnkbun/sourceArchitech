using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsQCRequestArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QCType",
                table: "QCRequest");

            migrationBuilder.DropColumn(
                name: "WFXQCDefName",
                table: "QCRequest");

            migrationBuilder.AddColumn<decimal>(
                name: "BalanceQty",
                table: "QCRequestArticle",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BatchNo",
                table: "QCRequestArticle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobOrderNo",
                table: "QCRequestArticle",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Length",
                table: "QCRequestArticle",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Line",
                table: "QCRequestArticle",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Machine",
                table: "QCRequestArticle",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MadeQty",
                table: "QCRequestArticle",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PlannedQty",
                table: "QCRequestArticle",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RollQty",
                table: "QCRequestArticle",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WeightKg",
                table: "QCRequestArticle",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "WidghtKg",
                table: "QCRequestArticle",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ProductionOutputCode",
                table: "QCRequest",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "To",
                table: "InspectionDefectError4PointSys",
                type: "decimal(28,8)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "From",
                table: "InspectionDefectError4PointSys",
                type: "decimal(28,8)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "To",
                table: "InspectionDefectError100PointSys",
                type: "decimal(28,8)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "From",
                table: "InspectionDefectError100PointSys",
                type: "decimal(28,8)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceQty",
                table: "QCRequestArticle");

            migrationBuilder.DropColumn(
                name: "BatchNo",
                table: "QCRequestArticle");

            migrationBuilder.DropColumn(
                name: "JobOrderNo",
                table: "QCRequestArticle");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "QCRequestArticle");

            migrationBuilder.DropColumn(
                name: "Line",
                table: "QCRequestArticle");

            migrationBuilder.DropColumn(
                name: "Machine",
                table: "QCRequestArticle");

            migrationBuilder.DropColumn(
                name: "MadeQty",
                table: "QCRequestArticle");

            migrationBuilder.DropColumn(
                name: "PlannedQty",
                table: "QCRequestArticle");

            migrationBuilder.DropColumn(
                name: "RollQty",
                table: "QCRequestArticle");

            migrationBuilder.DropColumn(
                name: "WeightKg",
                table: "QCRequestArticle");

            migrationBuilder.DropColumn(
                name: "WidghtKg",
                table: "QCRequestArticle");

            migrationBuilder.DropColumn(
                name: "ProductionOutputCode",
                table: "QCRequest");

            migrationBuilder.AddColumn<string>(
                name: "QCType",
                table: "QCRequest",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WFXQCDefName",
                table: "QCRequest",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "To",
                table: "InspectionDefectError4PointSys",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "From",
                table: "InspectionDefectError4PointSys",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AlterColumn<int>(
                name: "To",
                table: "InspectionDefectError100PointSys",
                type: "int",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "From",
                table: "InspectionDefectError100PointSys",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");
        }
    }
}
