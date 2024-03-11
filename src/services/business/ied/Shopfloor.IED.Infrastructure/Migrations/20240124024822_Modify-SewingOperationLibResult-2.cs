using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifySewingOperationLibResult2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MachineDelay",
                table: "SewingOperationLibResult",
                type: "decimal(28,8)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MachineDelay",
                table: "SewingOperationLibResult",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)",
                oldNullable: true);
        }
    }
}
