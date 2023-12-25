using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Material.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMaterialRequestDC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MaterialRequestDynamicColumn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialRequestId = table.Column<int>(type: "int", nullable: false),
                    DynamicColumnId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialRequestDynamicColumn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialRequestDynamicColumn_DynamicColumn_DynamicColumnId",
                        column: x => x.DynamicColumnId,
                        principalTable: "DynamicColumn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialRequestDynamicColumn_MaterialRequest_MaterialRequestId",
                        column: x => x.MaterialRequestId,
                        principalTable: "MaterialRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRequestDynamicColumn_DynamicColumnId",
                table: "MaterialRequestDynamicColumn",
                column: "DynamicColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRequestDynamicColumn_MaterialRequestId",
                table: "MaterialRequestDynamicColumn",
                column: "MaterialRequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialRequestDynamicColumn");
        }
    }
}
