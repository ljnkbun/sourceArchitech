using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_Table_StripFactoryDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MergeSplitPorDetail_PORDetail_FromPorDetailId",
                table: "MergeSplitPorDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_MergeSplitPorDetail_PORDetail_ToPorDetailId",
                table: "MergeSplitPorDetail");

            migrationBuilder.CreateTable(
                name: "StripFactoryDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PorDetailId = table.Column<int>(type: "int", nullable: false),
                    ColorName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SizeName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsPlanning = table.Column<bool>(type: "bit", nullable: true),
                    IsAllocated = table.Column<bool>(type: "bit", nullable: true),
                    StripFactoryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StripFactoryDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripFactoryDetail_StripFactory_StripFactoryId",
                        column: x => x.StripFactoryId,
                        principalTable: "StripFactory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StripFactoryDetail_StripFactoryId",
                table: "StripFactoryDetail",
                column: "StripFactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_MergeSplitPorDetail_PORDetail_FromPorDetailId",
                table: "MergeSplitPorDetail",
                column: "FromPorDetailId",
                principalTable: "PORDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MergeSplitPorDetail_PORDetail_ToPorDetailId",
                table: "MergeSplitPorDetail",
                column: "ToPorDetailId",
                principalTable: "PORDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MergeSplitPorDetail_PORDetail_FromPorDetailId",
                table: "MergeSplitPorDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_MergeSplitPorDetail_PORDetail_ToPorDetailId",
                table: "MergeSplitPorDetail");

            migrationBuilder.DropTable(
                name: "StripFactoryDetail");

            migrationBuilder.AddForeignKey(
                name: "FK_MergeSplitPorDetail_PORDetail_FromPorDetailId",
                table: "MergeSplitPorDetail",
                column: "FromPorDetailId",
                principalTable: "PORDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MergeSplitPorDetail_PORDetail_ToPorDetailId",
                table: "MergeSplitPorDetail",
                column: "ToPorDetailId",
                principalTable: "PORDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
