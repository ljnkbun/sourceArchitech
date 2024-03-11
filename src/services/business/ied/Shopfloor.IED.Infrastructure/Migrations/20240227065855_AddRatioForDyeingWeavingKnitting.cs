using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRatioForDyeingWeavingKnitting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Ratio",
                table: "RecipeChemical",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "KnittingOperationCode",
                table: "KnittingRouting",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Ratio",
                table: "DyeingTBRChemical",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "DyeingOperationCode",
                table: "DyeingRouting",
                type: "varchar(100)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ratio",
                table: "RecipeChemical");

            migrationBuilder.DropColumn(
                name: "KnittingOperationCode",
                table: "KnittingRouting");

            migrationBuilder.DropColumn(
                name: "Ratio",
                table: "DyeingTBRChemical");

            migrationBuilder.DropColumn(
                name: "DyeingOperationCode",
                table: "DyeingRouting");
        }
    }
}
