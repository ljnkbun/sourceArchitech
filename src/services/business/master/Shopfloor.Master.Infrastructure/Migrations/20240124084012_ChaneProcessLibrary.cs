using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChaneProcessLibrary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProcessLibrary",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductGroupId",
                table: "ProcessLibrary",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryGroupId",
                table: "ProcessLibrary",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "ProcessLibrary",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessLibrary_CategoryId",
                table: "ProcessLibrary",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessLibrary_ProductGroupId",
                table: "ProcessLibrary",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessLibrary_SubCategoryGroupId",
                table: "ProcessLibrary",
                column: "SubCategoryGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessLibrary_SubCategoryId",
                table: "ProcessLibrary",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessLibrary_Category_CategoryId",
                table: "ProcessLibrary",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessLibrary_ProductGroup_ProductGroupId",
                table: "ProcessLibrary",
                column: "ProductGroupId",
                principalTable: "ProductGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessLibrary_SubCategoryGroup_SubCategoryGroupId",
                table: "ProcessLibrary",
                column: "SubCategoryGroupId",
                principalTable: "SubCategoryGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessLibrary_SubCategory_SubCategoryId",
                table: "ProcessLibrary",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessLibrary_Category_CategoryId",
                table: "ProcessLibrary");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessLibrary_ProductGroup_ProductGroupId",
                table: "ProcessLibrary");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessLibrary_SubCategoryGroup_SubCategoryGroupId",
                table: "ProcessLibrary");

            migrationBuilder.DropForeignKey(
                name: "FK_ProcessLibrary_SubCategory_SubCategoryId",
                table: "ProcessLibrary");

            migrationBuilder.DropIndex(
                name: "IX_ProcessLibrary_CategoryId",
                table: "ProcessLibrary");

            migrationBuilder.DropIndex(
                name: "IX_ProcessLibrary_ProductGroupId",
                table: "ProcessLibrary");

            migrationBuilder.DropIndex(
                name: "IX_ProcessLibrary_SubCategoryGroupId",
                table: "ProcessLibrary");

            migrationBuilder.DropIndex(
                name: "IX_ProcessLibrary_SubCategoryId",
                table: "ProcessLibrary");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProcessLibrary");

            migrationBuilder.DropColumn(
                name: "ProductGroupId",
                table: "ProcessLibrary");

            migrationBuilder.DropColumn(
                name: "SubCategoryGroupId",
                table: "ProcessLibrary");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "ProcessLibrary");
        }
    }
}
