using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableRelationShip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroup_Category_CategoryId",
                table: "ProductGroup");

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "IsApparel",
                table: "MaterialType");

            migrationBuilder.DropColumn(
                name: "IsFabric",
                table: "MaterialType");

            migrationBuilder.DropColumn(
                name: "IsFiber",
                table: "MaterialType");

            migrationBuilder.DropColumn(
                name: "IsFixedAsset",
                table: "MaterialType");

            migrationBuilder.DropColumn(
                name: "IsMiscellaneous",
                table: "MaterialType");

            migrationBuilder.DropColumn(
                name: "IsServices",
                table: "MaterialType");

            migrationBuilder.DropColumn(
                name: "IsTrims",
                table: "MaterialType");

            migrationBuilder.DropColumn(
                name: "IsYarns",
                table: "MaterialType");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "ProductGroup",
                newName: "MaterialTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductGroup_CategoryId",
                table: "ProductGroup",
                newName: "IX_ProductGroup_MaterialTypeId");

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryGroupId",
                table: "SubCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "MaterialType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidFrom",
                table: "CompanyCurrency",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.CreateTable(
                name: "SubCategoryGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryGroup", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_SubCategoryGroupId",
                table: "SubCategory",
                column: "SubCategoryGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialType_CategoryId",
                table: "MaterialType",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialType_Category_CategoryId",
                table: "MaterialType",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroup_MaterialType_MaterialTypeId",
                table: "ProductGroup",
                column: "MaterialTypeId",
                principalTable: "MaterialType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategory_SubCategoryGroup_SubCategoryGroupId",
                table: "SubCategory",
                column: "SubCategoryGroupId",
                principalTable: "SubCategoryGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialType_Category_CategoryId",
                table: "MaterialType");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroup_MaterialType_MaterialTypeId",
                table: "ProductGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategory_SubCategoryGroup_SubCategoryGroupId",
                table: "SubCategory");

            migrationBuilder.DropTable(
                name: "SubCategoryGroup");

            migrationBuilder.DropIndex(
                name: "IX_SubCategory_SubCategoryGroupId",
                table: "SubCategory");

            migrationBuilder.DropIndex(
                name: "IX_MaterialType_CategoryId",
                table: "MaterialType");

            migrationBuilder.DropColumn(
                name: "SubCategoryGroupId",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "MaterialType");

            migrationBuilder.RenameColumn(
                name: "MaterialTypeId",
                table: "ProductGroup",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductGroup_MaterialTypeId",
                table: "ProductGroup",
                newName: "IX_ProductGroup_CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "SubCategory",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApparel",
                table: "MaterialType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFabric",
                table: "MaterialType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFiber",
                table: "MaterialType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFixedAsset",
                table: "MaterialType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMiscellaneous",
                table: "MaterialType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsServices",
                table: "MaterialType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTrims",
                table: "MaterialType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsYarns",
                table: "MaterialType",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidFrom",
                table: "CompanyCurrency",
                type: "datetime",
                nullable: false,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductGroup_Category_CategoryId",
                table: "ProductGroup",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
