using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDeleteBehavior_Category_ProducGroup_SubCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroup_MaterialType_MaterialTypeId",
                table: "ProductGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_ProductGroup_ProductGroupId",
                table: "SubCategory");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialTypeId",
                table: "ProductGroup",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaterialTypeId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductGroupId",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_CategoryId",
                table: "ProductGroup",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroup_Category_CategoryId",
                table: "ProductGroup",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroup_MaterialType_MaterialTypeId",
                table: "ProductGroup",
                column: "MaterialTypeId",
                principalTable: "MaterialType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_ProductGroup_ProductGroupId",
                table: "SubCategory",
                column: "ProductGroupId",
                principalTable: "ProductGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroup_Category_CategoryId",
                table: "ProductGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroup_MaterialType_MaterialTypeId",
                table: "ProductGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_ProductGroup_ProductGroupId",
                table: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_ProductGroup_CategoryId",
                table: "ProductGroup");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductGroup");

            migrationBuilder.DropColumn(
                name: "MaterialTypeId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ProductGroupId",
                table: "Category");

            migrationBuilder.AlterColumn<int>(
                name: "MaterialTypeId",
                table: "ProductGroup",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroup_MaterialType_MaterialTypeId",
                table: "ProductGroup",
                column: "MaterialTypeId",
                principalTable: "MaterialType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_ProductGroup_ProductGroupId",
                table: "SubCategory",
                column: "ProductGroupId",
                principalTable: "ProductGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
