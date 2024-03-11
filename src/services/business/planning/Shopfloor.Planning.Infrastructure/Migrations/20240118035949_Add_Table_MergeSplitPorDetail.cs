using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_MergeSplitPorDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "PORDetail");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "PORDetail",
                newName: "TypePORDetail");

            migrationBuilder.RenameColumn(
                name: "OrderedQty",
                table: "PORDetail",
                newName: "OrderedQuantity");

            migrationBuilder.AddColumn<byte>(
                name: "TypePOR",
                table: "POR",
                type: "tinyint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MergeSplitPorDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromPorDetailId = table.Column<int>(type: "int", nullable: true),
                    ToPorDetailId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MergeSplitPorDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MergeSplitPorDetail_PORDetail_FromPorDetailId",
                        column: x => x.FromPorDetailId,
                        principalTable: "PORDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MergeSplitPorDetail_PORDetail_ToPorDetailId",
                        column: x => x.ToPorDetailId,
                        principalTable: "PORDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MergeSplitPorDetail_FromPorDetailId",
                table: "MergeSplitPorDetail",
                column: "FromPorDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_MergeSplitPorDetail_ToPorDetailId",
                table: "MergeSplitPorDetail",
                column: "ToPorDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MergeSplitPorDetail");

            migrationBuilder.DropColumn(
                name: "TypePOR",
                table: "POR");

            migrationBuilder.RenameColumn(
                name: "TypePORDetail",
                table: "PORDetail",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "OrderedQuantity",
                table: "PORDetail",
                newName: "OrderedQty");

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "PORDetail",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
