using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnDyeingProcess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DyeingRouting_DyeingArticle_DyeingArticleId",
                table: "DyeingRouting");

            migrationBuilder.DropTable(
                name: "DyeingArticle");

            migrationBuilder.RenameColumn(
                name: "DyeingArticleId",
                table: "DyeingRouting",
                newName: "DyeingIEDId");

            migrationBuilder.RenameIndex(
                name: "IX_DyeingRouting_DyeingArticleId",
                table: "DyeingRouting",
                newName: "IX_DyeingRouting_DyeingIEDId");

            migrationBuilder.RenameColumn(
                name: "RequestDivisionId",
                table: "DyeingIED",
                newName: "RequestArticleOutputId");

            migrationBuilder.AddColumn<string>(
                name: "ArticleCode",
                table: "DyeingIED",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleId",
                table: "DyeingIED",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleName",
                table: "DyeingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer",
                table: "DyeingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "DyeingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColorRef",
                table: "DyeingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductGroup",
                table: "DyeingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "DyeingIED",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubCategory",
                table: "DyeingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DyeingRouting_DyeingIED_DyeingIEDId",
                table: "DyeingRouting",
                column: "DyeingIEDId",
                principalTable: "DyeingIED",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DyeingRouting_DyeingIED_DyeingIEDId",
                table: "DyeingRouting");

            migrationBuilder.DropColumn(
                name: "ArticleCode",
                table: "DyeingIED");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "DyeingIED");

            migrationBuilder.DropColumn(
                name: "ArticleName",
                table: "DyeingIED");

            migrationBuilder.DropColumn(
                name: "Buyer",
                table: "DyeingIED");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "DyeingIED");

            migrationBuilder.DropColumn(
                name: "ColorRef",
                table: "DyeingIED");

            migrationBuilder.DropColumn(
                name: "ProductGroup",
                table: "DyeingIED");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "DyeingIED");

            migrationBuilder.DropColumn(
                name: "SubCategory",
                table: "DyeingIED");

            migrationBuilder.RenameColumn(
                name: "DyeingIEDId",
                table: "DyeingRouting",
                newName: "DyeingArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_DyeingRouting_DyeingIEDId",
                table: "DyeingRouting",
                newName: "IX_DyeingRouting_DyeingArticleId");

            migrationBuilder.RenameColumn(
                name: "RequestArticleOutputId",
                table: "DyeingIED",
                newName: "RequestDivisionId");

            migrationBuilder.CreateTable(
                name: "DyeingArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DyeingIEDId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RecipeId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RecipeNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DyeingArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DyeingArticle_DyeingIED_DyeingIEDId",
                        column: x => x.DyeingIEDId,
                        principalTable: "DyeingIED",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DyeingArticle_DyeingIEDId",
                table: "DyeingArticle",
                column: "DyeingIEDId");

            migrationBuilder.AddForeignKey(
                name: "FK_DyeingRouting_DyeingArticle_DyeingArticleId",
                table: "DyeingRouting",
                column: "DyeingArticleId",
                principalTable: "DyeingArticle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
