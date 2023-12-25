using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addTable_CategoryMapMaterialType_MaterialTypeMapProductGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialType_Category_CategoryId",
                table: "MaterialType");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductGroup_MaterialType_MaterialTypeId",
                table: "ProductGroup");

            migrationBuilder.DropIndex(
                name: "IX_ProductGroup_MaterialTypeId",
                table: "ProductGroup");

            migrationBuilder.DropIndex(
                name: "IX_MaterialType_CategoryId",
                table: "MaterialType");

            migrationBuilder.DropColumn(
                name: "MaterialTypeId",
                table: "ProductGroup");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "MaterialType",
                newName: "MaterialTypeMapProductGroupID");

            migrationBuilder.RenameColumn(
                name: "MaterialTypeId",
                table: "Category",
                newName: "CategoryMapMaterialTypeId");

            migrationBuilder.AddColumn<int>(
                name: "MaterialTypeMapProductGroupID",
                table: "ProductGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryMapMaterialTypeID",
                table: "MaterialType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoryMapMaterialType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    MaterialTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMapMaterialType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryMapMaterialType_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryMapMaterialType_MaterialType_MaterialTypeId",
                        column: x => x.MaterialTypeId,
                        principalTable: "MaterialType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialTypeMapProductGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductGroupId = table.Column<int>(type: "int", nullable: false),
                    MaterialTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialTypeMapProductGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialTypeMapProductGroup_MaterialType_MaterialTypeId",
                        column: x => x.MaterialTypeId,
                        principalTable: "MaterialType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialTypeMapProductGroup_ProductGroup_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMapMaterialType_CategoryId",
                table: "CategoryMapMaterialType",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryMapMaterialType_MaterialTypeId",
                table: "CategoryMapMaterialType",
                column: "MaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTypeMapProductGroup_MaterialTypeId",
                table: "MaterialTypeMapProductGroup",
                column: "MaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialTypeMapProductGroup_ProductGroupId",
                table: "MaterialTypeMapProductGroup",
                column: "ProductGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryMapMaterialType");

            migrationBuilder.DropTable(
                name: "MaterialTypeMapProductGroup");

            migrationBuilder.DropColumn(
                name: "MaterialTypeMapProductGroupID",
                table: "ProductGroup");

            migrationBuilder.DropColumn(
                name: "CategoryMapMaterialTypeID",
                table: "MaterialType");

            migrationBuilder.RenameColumn(
                name: "MaterialTypeMapProductGroupID",
                table: "MaterialType",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "CategoryMapMaterialTypeId",
                table: "Category",
                newName: "MaterialTypeId");

            migrationBuilder.AddColumn<int>(
                name: "MaterialTypeId",
                table: "ProductGroup",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_MaterialTypeId",
                table: "ProductGroup",
                column: "MaterialTypeId");

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
                principalColumn: "Id");
        }
    }
}
