using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removerelationshipsonArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_Category_CategoryId",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Article_MaterialType_MaterialTypeId",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Article_ProductGroup_ProductGroupId",
                table: "Article");

            migrationBuilder.DropForeignKey(
                name: "FK_Article_SubCategory_SubCategoryId",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_CategoryId",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_MaterialTypeId",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_ProductGroupId",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_SubCategoryId",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "MaterialTypeId",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "ProductGroupId",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "Article");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaterialTypeId",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductGroupId",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "Article",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Article_CategoryId",
                table: "Article",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_MaterialTypeId",
                table: "Article",
                column: "MaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_ProductGroupId",
                table: "Article",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_SubCategoryId",
                table: "Article",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_Category_CategoryId",
                table: "Article",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_MaterialType_MaterialTypeId",
                table: "Article",
                column: "MaterialTypeId",
                principalTable: "MaterialType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_ProductGroup_ProductGroupId",
                table: "Article",
                column: "ProductGroupId",
                principalTable: "ProductGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_SubCategory_SubCategoryId",
                table: "Article",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
