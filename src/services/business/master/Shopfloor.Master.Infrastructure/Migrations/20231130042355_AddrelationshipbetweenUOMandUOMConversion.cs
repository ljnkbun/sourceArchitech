using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddrelationshipbetweenUOMandUOMConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromUOM",
                table: "UOMConversion");

            migrationBuilder.DropColumn(
                name: "ToUOM",
                table: "UOMConversion");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "UOMConversion",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromUOMId",
                table: "UOMConversion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToUOMId",
                table: "UOMConversion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UOMConversion_FromUOMId",
                table: "UOMConversion",
                column: "FromUOMId");

            migrationBuilder.CreateIndex(
                name: "IX_UOMConversion_ToUOMId",
                table: "UOMConversion",
                column: "ToUOMId");

            migrationBuilder.AddForeignKey(
                name: "FK_UOMConversion_UOM_FromUOMId",
                table: "UOMConversion",
                column: "FromUOMId",
                principalTable: "UOM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UOMConversion_UOM_ToUOMId",
                table: "UOMConversion",
                column: "ToUOMId",
                principalTable: "UOM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UOMConversion_UOM_FromUOMId",
                table: "UOMConversion");

            migrationBuilder.DropForeignKey(
                name: "FK_UOMConversion_UOM_ToUOMId",
                table: "UOMConversion");

            migrationBuilder.DropIndex(
                name: "IX_UOMConversion_FromUOMId",
                table: "UOMConversion");

            migrationBuilder.DropIndex(
                name: "IX_UOMConversion_ToUOMId",
                table: "UOMConversion");

            migrationBuilder.DropColumn(
                name: "FromUOMId",
                table: "UOMConversion");

            migrationBuilder.DropColumn(
                name: "ToUOMId",
                table: "UOMConversion");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "UOMConversion",
                type: "decimal(28,8)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(28,8)");

            migrationBuilder.AddColumn<string>(
                name: "FromUOM",
                table: "UOMConversion",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToUOM",
                table: "UOMConversion",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
