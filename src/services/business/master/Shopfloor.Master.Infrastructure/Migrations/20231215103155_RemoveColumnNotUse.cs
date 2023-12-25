using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColumnNotUse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialTypeMapProductGroupID",
                table: "ProductGroup");

            migrationBuilder.DropColumn(
                name: "CategoryMapMaterialTypeID",
                table: "MaterialType");

            migrationBuilder.DropColumn(
                name: "MaterialTypeMapProductGroupID",
                table: "MaterialType");

            migrationBuilder.DropColumn(
                name: "CategoryMapMaterialTypeId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ProductGroupId",
                table: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "MaterialTypeMapProductGroupID",
                table: "MaterialType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryMapMaterialTypeId",
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
        }
    }
}
