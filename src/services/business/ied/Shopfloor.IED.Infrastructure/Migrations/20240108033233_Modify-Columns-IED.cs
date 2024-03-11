using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyColumnsIED : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "RequestArticleOutput",
                newName: "WFXArticleId");

            migrationBuilder.RenameColumn(
                name: "ArticleId",
                table: "RequestArticleInput",
                newName: "WFXArticleId");

            migrationBuilder.RenameColumn(
                name: "ConeQuality",
                table: "KnittingYarn",
                newName: "Weight");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpectedDate",
                table: "RequestDivision",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpectedDate",
                table: "RequestDivision");

            migrationBuilder.RenameColumn(
                name: "WFXArticleId",
                table: "RequestArticleOutput",
                newName: "ArticleId");

            migrationBuilder.RenameColumn(
                name: "WFXArticleId",
                table: "RequestArticleInput",
                newName: "ArticleId");

            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "KnittingYarn",
                newName: "ConeQuality");
        }
    }
}
