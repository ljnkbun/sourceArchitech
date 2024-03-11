using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnForeignKeyRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DyeingTBRecipe_DyeingTBMaterialColorId",
                table: "DyeingTBRecipe");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingTBRecipe_DyeingTBMaterialColorId",
                table: "DyeingTBRecipe",
                column: "DyeingTBMaterialColorId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DyeingTBRecipe_DyeingTBMaterialColorId",
                table: "DyeingTBRecipe");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingTBRecipe_DyeingTBMaterialColorId",
                table: "DyeingTBRecipe",
                column: "DyeingTBMaterialColorId");
        }
    }
}
