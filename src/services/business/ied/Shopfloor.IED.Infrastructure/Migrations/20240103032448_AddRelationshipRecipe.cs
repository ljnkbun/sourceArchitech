using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationshipRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Recipe_DyeingTBRecipeId",
                table: "Recipe",
                column: "DyeingTBRecipeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_DyeingTBRecipe_DyeingTBRecipeId",
                table: "Recipe",
                column: "DyeingTBRecipeId",
                principalTable: "DyeingTBRecipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_DyeingTBRecipe_DyeingTBRecipeId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_Recipe_DyeingTBRecipeId",
                table: "Recipe");
        }
    }
}
