using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnProcessOperationRecipeTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequestType",
                table: "DyeingTBRequest",
                newName: "RecipeCategoryId");

            migrationBuilder.AddColumn<string>(
                name: "DyeingOperationCode",
                table: "RecipeTask",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DyeingProcessCode",
                table: "RecipeTask",
                type: "varchar(100)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DyeingOperationCode",
                table: "RecipeTask");

            migrationBuilder.DropColumn(
                name: "DyeingProcessCode",
                table: "RecipeTask");

            migrationBuilder.RenameColumn(
                name: "RecipeCategoryId",
                table: "DyeingTBRequest",
                newName: "RequestType");
        }
    }
}
