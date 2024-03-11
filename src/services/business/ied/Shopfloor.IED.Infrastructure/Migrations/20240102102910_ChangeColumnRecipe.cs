using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DyeingTBRVersionId",
                table: "Recipe");

            migrationBuilder.RenameColumn(
                name: "DyeingTBRequestId",
                table: "Recipe",
                newName: "DyeingTBRecipeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DyeingTBRecipeId",
                table: "Recipe",
                newName: "DyeingTBRequestId");

            migrationBuilder.AddColumn<int>(
                name: "DyeingTBRVersionId",
                table: "Recipe",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
