using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRequestNoModifyFreq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Freq",
                table: "SewingRoutingBOL",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Freq",
                table: "SewingOperationLibBOL",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AlterColumn<string>(
                name: "Freq",
                table: "SewingMacroLibBOL",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AddColumn<string>(
                name: "RequestNo",
                table: "SewingIED",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Freq",
                table: "SewingFeatureLibBOL",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AddColumn<string>(
                name: "RequestNo",
                table: "KnittingIED",
                type: "varchar(50)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RequestNo",
                table: "SewingIED");

            migrationBuilder.DropColumn(
                name: "RequestNo",
                table: "KnittingIED");

            migrationBuilder.AlterColumn<string>(
                name: "Freq",
                table: "SewingRoutingBOL",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Freq",
                table: "SewingOperationLibBOL",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Freq",
                table: "SewingMacroLibBOL",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Freq",
                table: "SewingFeatureLibBOL",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);
        }
    }
}
