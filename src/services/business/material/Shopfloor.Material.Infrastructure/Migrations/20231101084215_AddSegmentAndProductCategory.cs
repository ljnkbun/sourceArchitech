using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSegmentAndProductCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessSegment",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ProductCategory",
                table: "Supplier");

            migrationBuilder.AddColumn<string>(
                name: "ApproveName",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApproveUserId",
                table: "Supplier",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyId",
                table: "Supplier",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomHouse",
                table: "Supplier",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBrand",
                table: "Supplier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsBuying",
                table: "Supplier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsComposition",
                table: "Supplier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsManufacture",
                table: "Supplier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOther",
                table: "Supplier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRetailer",
                table: "Supplier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsServiceProvider",
                table: "Supplier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsTransporter",
                table: "Supplier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWholesaler",
                table: "Supplier",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Pan",
                table: "Supplier",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductCategoryId",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SegmentOther",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupplierType",
                table: "Supplier",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tin",
                table: "Supplier",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ApproveUserId",
                table: "PriceList",
                type: "uniqueidentifier",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);
                       
            migrationBuilder.CreateTable(
                name: "SupplierProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(200)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierProductCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierProductCategory_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierProductCategory_SupplierId",
                table: "SupplierProductCategory",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplierProductCategory");

            migrationBuilder.DropColumn(
                name: "ApproveName",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ApproveUserId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CustomHouse",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "IsBrand",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "IsBuying",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "IsComposition",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "IsManufacture",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "IsOther",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "IsRetailer",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "IsServiceProvider",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "IsTransporter",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "IsWholesaler",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Pan",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SegmentOther",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SupplierType",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Tin",
                table: "Supplier");
                    
            migrationBuilder.AddColumn<string>(
                name: "BusinessSegment",
                table: "Supplier",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductCategory",
                table: "Supplier",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApproveUserId",
                table: "PriceList",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
