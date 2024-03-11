using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MachineType",
                table: "RecipeTask",
                newName: "MachineName");

            migrationBuilder.AddColumn<string>(
                name: "MachineCode",
                table: "RecipeTask",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Recipe",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TBRecipeName",
                table: "DyeingTBRecipe",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MachineCode",
                table: "RecipeTask");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Recipe");

            migrationBuilder.DropColumn(
                name: "TBRecipeName",
                table: "DyeingTBRecipe");

            migrationBuilder.RenameColumn(
                name: "MachineName",
                table: "RecipeTask",
                newName: "MachineType");
        }
    }
}
