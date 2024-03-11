using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnRatioRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ratio",
                table: "RecipeChemical");

            migrationBuilder.DropColumn(
                name: "Ratio",
                table: "DyeingTBRChemical");

            migrationBuilder.AddColumn<decimal>(
                name: "Ratio",
                table: "RecipeTask",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Ratio",
                table: "DyeingTBRTask",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "FabricStyleRef",
                table: "DyeingTBMaterial",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ratio",
                table: "RecipeTask");

            migrationBuilder.DropColumn(
                name: "Ratio",
                table: "DyeingTBRTask");

            migrationBuilder.DropColumn(
                name: "FabricStyleRef",
                table: "DyeingTBMaterial");

            migrationBuilder.AddColumn<decimal>(
                name: "Ratio",
                table: "RecipeChemical",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Ratio",
                table: "DyeingTBRChemical",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
