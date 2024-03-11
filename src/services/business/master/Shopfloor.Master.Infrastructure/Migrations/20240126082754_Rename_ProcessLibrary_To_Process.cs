using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Master.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Rename_ProcessLibrary_To_Process : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationLibrary_ProcessLibrary_ProcessLibraryId",
                table: "OperationLibrary");

            migrationBuilder.DropTable(
                name: "ProcessLibrary");

            migrationBuilder.RenameColumn(
                name: "ProcessLibraryId",
                table: "OperationLibrary",
                newName: "ProcessId");

            migrationBuilder.RenameIndex(
                name: "IX_OperationLibrary_ProcessLibraryId",
                table: "OperationLibrary",
                newName: "IX_OperationLibrary_ProcessId");

            migrationBuilder.CreateTable(
                name: "Process",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ProductGroupId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryGroupId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Process", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Process_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Process_ProductGroup_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Process_SubCategoryGroup_SubCategoryGroupId",
                        column: x => x.SubCategoryGroupId,
                        principalTable: "SubCategoryGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Process_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Process_CategoryId",
                table: "Process",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Process_Code",
                table: "Process",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Process_ProductGroupId",
                table: "Process",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Process_SubCategoryGroupId",
                table: "Process",
                column: "SubCategoryGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Process_SubCategoryId",
                table: "Process",
                column: "SubCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationLibrary_Process_ProcessId",
                table: "OperationLibrary",
                column: "ProcessId",
                principalTable: "Process",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationLibrary_Process_ProcessId",
                table: "OperationLibrary");

            migrationBuilder.DropTable(
                name: "Process");

            migrationBuilder.RenameColumn(
                name: "ProcessId",
                table: "OperationLibrary",
                newName: "ProcessLibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_OperationLibrary_ProcessId",
                table: "OperationLibrary",
                newName: "IX_OperationLibrary_ProcessLibraryId");

            migrationBuilder.CreateTable(
                name: "ProcessLibrary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    ProductGroupId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryGroupId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessLibrary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcessLibrary_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProcessLibrary_ProductGroup_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalTable: "ProductGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProcessLibrary_SubCategoryGroup_SubCategoryGroupId",
                        column: x => x.SubCategoryGroupId,
                        principalTable: "SubCategoryGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProcessLibrary_SubCategory_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcessLibrary_CategoryId",
                table: "ProcessLibrary",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcessLibrary_Code",
                table: "ProcessLibrary",
                column: "Code",
                unique: true);

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
                name: "FK_OperationLibrary_ProcessLibrary_ProcessLibraryId",
                table: "OperationLibrary",
                column: "ProcessLibraryId",
                principalTable: "ProcessLibrary",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
