using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Planning.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Table_PorDetail_StripFactoryDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StripFactoryDetail_StripFactory_StripFactoryId",
                table: "StripFactoryDetail");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "StripFactoryDetail");

            migrationBuilder.DropColumn(
                name: "IsAllocated",
                table: "StripFactoryDetail");

            migrationBuilder.DropColumn(
                name: "IsPlanning",
                table: "StripFactoryDetail");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "StripFactoryDetail");

            migrationBuilder.RenameColumn(
                name: "SizeName",
                table: "StripFactoryDetail",
                newName: "UOM");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "StripFactoryDetail",
                newName: "RemainingQuantity");

            migrationBuilder.RenameColumn(
                name: "ColorName",
                table: "StripFactoryDetail",
                newName: "Color");

            migrationBuilder.AddColumn<decimal>(
                name: "OrderedQuantity",
                table: "StripFactoryDetail",
                type: "decimal(28,8)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "StripFactoryDetail",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "TypePORDetail",
                table: "StripFactoryDetail",
                type: "tinyint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StripFactoryDetail_PorDetailId",
                table: "StripFactoryDetail",
                column: "PorDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactoryDetail_PORDetail_PorDetailId",
                table: "StripFactoryDetail",
                column: "PorDetailId",
                principalTable: "PORDetail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactoryDetail_StripFactory_StripFactoryId",
                table: "StripFactoryDetail",
                column: "StripFactoryId",
                principalTable: "StripFactory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StripFactoryDetail_PORDetail_PorDetailId",
                table: "StripFactoryDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_StripFactoryDetail_StripFactory_StripFactoryId",
                table: "StripFactoryDetail");

            migrationBuilder.DropIndex(
                name: "IX_StripFactoryDetail_PorDetailId",
                table: "StripFactoryDetail");

            migrationBuilder.DropColumn(
                name: "OrderedQuantity",
                table: "StripFactoryDetail");

            migrationBuilder.DropColumn(
                name: "Size",
                table: "StripFactoryDetail");

            migrationBuilder.DropColumn(
                name: "TypePORDetail",
                table: "StripFactoryDetail");

            migrationBuilder.RenameColumn(
                name: "UOM",
                table: "StripFactoryDetail",
                newName: "SizeName");

            migrationBuilder.RenameColumn(
                name: "RemainingQuantity",
                table: "StripFactoryDetail",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "StripFactoryDetail",
                newName: "ColorName");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "StripFactoryDetail",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAllocated",
                table: "StripFactoryDetail",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPlanning",
                table: "StripFactoryDetail",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "StripFactoryDetail",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StripFactoryDetail_StripFactory_StripFactoryId",
                table: "StripFactoryDetail",
                column: "StripFactoryId",
                principalTable: "StripFactory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
