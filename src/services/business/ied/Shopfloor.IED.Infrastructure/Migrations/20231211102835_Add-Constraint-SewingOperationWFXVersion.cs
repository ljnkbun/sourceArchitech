using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConstraintSewingOperationWFXVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SewingOperationWFXVersion_SewingOperationWFXId",
                table: "SewingOperationWFXVersion");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "SewingOperationWFXVersion");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SewingOperationWFXVersion");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "SewingOperationWFX");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "SewingOperationWFX");

            migrationBuilder.AlterColumn<decimal>(
                name: "LabourCostFactoryIncludingOverhead",
                table: "SewingOperationWFX",
                type: "decimal(28,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FactoryOverheadAgainstLabourPercent",
                table: "SewingOperationWFX",
                type: "decimal(28,8)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "CurrentVersionId",
                table: "SewingOperationWFX",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationWFXVersion_SewingOperationWFXId_Version",
                table: "SewingOperationWFXVersion",
                columns: new[] { "SewingOperationWFXId", "Version" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SewingOperationWFXVersion_SewingOperationWFXId_Version",
                table: "SewingOperationWFXVersion");

            migrationBuilder.DropColumn(
                name: "CurrentVersionId",
                table: "SewingOperationWFX");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "SewingOperationWFXVersion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SewingOperationWFXVersion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "LabourCostFactoryIncludingOverhead",
                table: "SewingOperationWFX",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AlterColumn<decimal>(
                name: "FactoryOverheadAgainstLabourPercent",
                table: "SewingOperationWFX",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "SewingOperationWFX",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "SewingOperationWFX",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationWFXVersion_SewingOperationWFXId",
                table: "SewingOperationWFXVersion",
                column: "SewingOperationWFXId");
        }
    }
}
