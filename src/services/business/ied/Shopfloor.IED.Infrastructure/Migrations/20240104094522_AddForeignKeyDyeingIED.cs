using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyDyeingIED : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "DyeingIED");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "DyeingIED",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "WFXArticleId",
                table: "DyeingIED",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DyeingIED_RecipeId",
                table: "DyeingIED",
                column: "RecipeId",
                unique: true,
                filter: "[RecipeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DyeingIED_RequestArticleOutputId",
                table: "DyeingIED",
                column: "RequestArticleOutputId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DyeingIED_Recipe_RecipeId",
                table: "DyeingIED",
                column: "RecipeId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DyeingIED_RequestArticleOutput_RequestArticleOutputId",
                table: "DyeingIED",
                column: "RequestArticleOutputId",
                principalTable: "RequestArticleOutput",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DyeingIED_Recipe_RecipeId",
                table: "DyeingIED");

            migrationBuilder.DropForeignKey(
                name: "FK_DyeingIED_RequestArticleOutput_RequestArticleOutputId",
                table: "DyeingIED");

            migrationBuilder.DropIndex(
                name: "IX_DyeingIED_RecipeId",
                table: "DyeingIED");

            migrationBuilder.DropIndex(
                name: "IX_DyeingIED_RequestArticleOutputId",
                table: "DyeingIED");

            migrationBuilder.DropColumn(
                name: "WFXArticleId",
                table: "DyeingIED");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "DyeingIED",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleId",
                table: "DyeingIED",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
