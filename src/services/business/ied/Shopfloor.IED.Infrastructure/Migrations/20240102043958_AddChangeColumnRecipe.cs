using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChangeColumnRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Minutes",
                table: "RecipeTask",
                newName: "DyeingProcessId");

            migrationBuilder.RenameColumn(
                name: "DyeingOpreation",
                table: "RecipeTask",
                newName: "DyeingProcessName");

            migrationBuilder.AddColumn<int>(
                name: "DyeingOperationId",
                table: "RecipeTask",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DyeingOperationName",
                table: "RecipeTask",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Time",
                table: "RecipeTask",
                type: "decimal(28,8)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ChemicalSubcategory",
                table: "RecipeChemical",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DyeingOperationId",
                table: "RecipeTask");

            migrationBuilder.DropColumn(
                name: "DyeingOperationName",
                table: "RecipeTask");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "RecipeTask");

            migrationBuilder.DropColumn(
                name: "ChemicalSubcategory",
                table: "RecipeChemical");

            migrationBuilder.RenameColumn(
                name: "DyeingProcessName",
                table: "RecipeTask",
                newName: "DyeingOpreation");

            migrationBuilder.RenameColumn(
                name: "DyeingProcessId",
                table: "RecipeTask",
                newName: "Minutes");
        }
    }
}
