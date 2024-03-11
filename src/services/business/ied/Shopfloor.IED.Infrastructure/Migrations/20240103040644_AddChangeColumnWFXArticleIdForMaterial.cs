using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChangeColumnWFXArticleIdForMaterial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "DyeingTBMaterial");

            migrationBuilder.AddColumn<int>(
                name: "WFXArticleId",
                table: "DyeingTBMaterial",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WFXArticleId",
                table: "DyeingTBMaterial");

            migrationBuilder.AddColumn<string>(
                name: "ArticleId",
                table: "DyeingTBMaterial",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);
        }
    }
}
