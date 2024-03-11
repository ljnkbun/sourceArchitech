using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyRelationshipRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DyeingIED_Recipe_RecipeId",
                table: "DyeingIED");

            migrationBuilder.DropIndex(
                name: "IX_DyeingIED_RecipeId",
                table: "DyeingIED");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingIED_RecipeId",
                table: "DyeingIED",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DyeingIED_Recipe_RecipeId",
                table: "DyeingIED",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DyeingIED_Recipe_RecipeId",
                table: "DyeingIED");

            migrationBuilder.DropIndex(
                name: "IX_DyeingIED_RecipeId",
                table: "DyeingIED");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingIED_RecipeId",
                table: "DyeingIED",
                column: "RecipeId",
                unique: true,
                filter: "[RecipeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DyeingIED_Recipe_RecipeId",
                table: "DyeingIED",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
