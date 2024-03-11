using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyWeavingKnittingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KnittingIED_RequestDivision_RequestDivisionId",
                table: "KnittingIED");

            migrationBuilder.DropForeignKey(
                name: "FK_WeavingDetailStructure_WeavingArticle_WeavingArticleId",
                table: "WeavingDetailStructure");

            migrationBuilder.DropForeignKey(
                name: "FK_WeavingIED_RequestDivision_RequestDivisionId",
                table: "WeavingIED");

            migrationBuilder.DropForeignKey(
                name: "FK_WeavingRappo_WeavingArticle_WeavingArticleId",
                table: "WeavingRappo");

            migrationBuilder.DropForeignKey(
                name: "FK_WeavingRouting_WeavingArticle_WeavingArticleId",
                table: "WeavingRouting");

            migrationBuilder.DropForeignKey(
                name: "FK_WeavingRusticFabricSpec_WeavingArticle_WeavingArticleId",
                table: "WeavingRusticFabricSpec");

            migrationBuilder.DropForeignKey(
                name: "FK_WeavingYarn_WeavingArticle_WeavingArticleId",
                table: "WeavingYarn");

            migrationBuilder.DropTable(
                name: "WeavingArticle");

            migrationBuilder.DropIndex(
                name: "IX_KnittingIED_RequestDivisionId",
                table: "KnittingIED");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "SewingIED");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "KnittingIED");

            migrationBuilder.RenameColumn(
                name: "WeavingArticleId",
                table: "WeavingYarn",
                newName: "WeavingIEDId");

            migrationBuilder.RenameIndex(
                name: "IX_WeavingYarn_WeavingArticleId",
                table: "WeavingYarn",
                newName: "IX_WeavingYarn_WeavingIEDId");

            migrationBuilder.RenameColumn(
                name: "WeavingArticleId",
                table: "WeavingRusticFabricSpec",
                newName: "WeavingIEDId");

            migrationBuilder.RenameIndex(
                name: "IX_WeavingRusticFabricSpec_WeavingArticleId",
                table: "WeavingRusticFabricSpec",
                newName: "IX_WeavingRusticFabricSpec_WeavingIEDId");

            migrationBuilder.RenameColumn(
                name: "WeavingArticleId",
                table: "WeavingRouting",
                newName: "WeavingIEDId");

            migrationBuilder.RenameIndex(
                name: "IX_WeavingRouting_WeavingArticleId",
                table: "WeavingRouting",
                newName: "IX_WeavingRouting_WeavingIEDId");

            migrationBuilder.RenameColumn(
                name: "WeavingArticleId",
                table: "WeavingRappo",
                newName: "WeavingIEDId");

            migrationBuilder.RenameIndex(
                name: "IX_WeavingRappo_WeavingArticleId",
                table: "WeavingRappo",
                newName: "IX_WeavingRappo_WeavingIEDId");

            migrationBuilder.RenameColumn(
                name: "RequestNo",
                table: "WeavingIED",
                newName: "ArticleCode");

            migrationBuilder.RenameColumn(
                name: "RequestDivisionId",
                table: "WeavingIED",
                newName: "RequestArticleOutputId");

            migrationBuilder.RenameIndex(
                name: "IX_WeavingIED_RequestDivisionId",
                table: "WeavingIED",
                newName: "IX_WeavingIED_RequestArticleOutputId");

            migrationBuilder.RenameColumn(
                name: "WeavingArticleId",
                table: "WeavingDetailStructure",
                newName: "WeavingIEDId");

            migrationBuilder.RenameIndex(
                name: "IX_WeavingDetailStructure_WeavingArticleId",
                table: "WeavingDetailStructure",
                newName: "IX_WeavingDetailStructure_WeavingIEDId");

            migrationBuilder.RenameColumn(
                name: "RequestDivisionId",
                table: "KnittingIED",
                newName: "RequestArticleOutputId");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "WeavingIED",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleName",
                table: "WeavingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer",
                table: "WeavingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductGroup",
                table: "WeavingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCategory",
                table: "WeavingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WFXArticleId",
                table: "WeavingIED",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WFXArticleId",
                table: "SewingIED",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleName",
                table: "KnittingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleCode",
                table: "KnittingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AddColumn<string>(
                name: "Buyer",
                table: "KnittingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductGroup",
                table: "KnittingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCategory",
                table: "KnittingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WFXArticleId",
                table: "KnittingIED",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KnittingIED_RequestArticleOutputId",
                table: "KnittingIED",
                column: "RequestArticleOutputId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KnittingIED_RequestArticleOutput_RequestArticleOutputId",
                table: "KnittingIED",
                column: "RequestArticleOutputId",
                principalTable: "RequestArticleOutput",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeavingDetailStructure_WeavingIED_WeavingIEDId",
                table: "WeavingDetailStructure",
                column: "WeavingIEDId",
                principalTable: "WeavingIED",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeavingIED_RequestArticleOutput_RequestArticleOutputId",
                table: "WeavingIED",
                column: "RequestArticleOutputId",
                principalTable: "RequestArticleOutput",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeavingRappo_WeavingIED_WeavingIEDId",
                table: "WeavingRappo",
                column: "WeavingIEDId",
                principalTable: "WeavingIED",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeavingRouting_WeavingIED_WeavingIEDId",
                table: "WeavingRouting",
                column: "WeavingIEDId",
                principalTable: "WeavingIED",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeavingRusticFabricSpec_WeavingIED_WeavingIEDId",
                table: "WeavingRusticFabricSpec",
                column: "WeavingIEDId",
                principalTable: "WeavingIED",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeavingYarn_WeavingIED_WeavingIEDId",
                table: "WeavingYarn",
                column: "WeavingIEDId",
                principalTable: "WeavingIED",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KnittingIED_RequestArticleOutput_RequestArticleOutputId",
                table: "KnittingIED");

            migrationBuilder.DropForeignKey(
                name: "FK_WeavingDetailStructure_WeavingIED_WeavingIEDId",
                table: "WeavingDetailStructure");

            migrationBuilder.DropForeignKey(
                name: "FK_WeavingIED_RequestArticleOutput_RequestArticleOutputId",
                table: "WeavingIED");

            migrationBuilder.DropForeignKey(
                name: "FK_WeavingRappo_WeavingIED_WeavingIEDId",
                table: "WeavingRappo");

            migrationBuilder.DropForeignKey(
                name: "FK_WeavingRouting_WeavingIED_WeavingIEDId",
                table: "WeavingRouting");

            migrationBuilder.DropForeignKey(
                name: "FK_WeavingRusticFabricSpec_WeavingIED_WeavingIEDId",
                table: "WeavingRusticFabricSpec");

            migrationBuilder.DropForeignKey(
                name: "FK_WeavingYarn_WeavingIED_WeavingIEDId",
                table: "WeavingYarn");

            migrationBuilder.DropIndex(
                name: "IX_KnittingIED_RequestArticleOutputId",
                table: "KnittingIED");

            migrationBuilder.DropColumn(
                name: "ArticleName",
                table: "WeavingIED");

            migrationBuilder.DropColumn(
                name: "Buyer",
                table: "WeavingIED");

            migrationBuilder.DropColumn(
                name: "ProductGroup",
                table: "WeavingIED");

            migrationBuilder.DropColumn(
                name: "SubCategory",
                table: "WeavingIED");

            migrationBuilder.DropColumn(
                name: "WFXArticleId",
                table: "WeavingIED");

            migrationBuilder.DropColumn(
                name: "WFXArticleId",
                table: "SewingIED");

            migrationBuilder.DropColumn(
                name: "Buyer",
                table: "KnittingIED");

            migrationBuilder.DropColumn(
                name: "ProductGroup",
                table: "KnittingIED");

            migrationBuilder.DropColumn(
                name: "SubCategory",
                table: "KnittingIED");

            migrationBuilder.DropColumn(
                name: "WFXArticleId",
                table: "KnittingIED");

            migrationBuilder.RenameColumn(
                name: "WeavingIEDId",
                table: "WeavingYarn",
                newName: "WeavingArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_WeavingYarn_WeavingIEDId",
                table: "WeavingYarn",
                newName: "IX_WeavingYarn_WeavingArticleId");

            migrationBuilder.RenameColumn(
                name: "WeavingIEDId",
                table: "WeavingRusticFabricSpec",
                newName: "WeavingArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_WeavingRusticFabricSpec_WeavingIEDId",
                table: "WeavingRusticFabricSpec",
                newName: "IX_WeavingRusticFabricSpec_WeavingArticleId");

            migrationBuilder.RenameColumn(
                name: "WeavingIEDId",
                table: "WeavingRouting",
                newName: "WeavingArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_WeavingRouting_WeavingIEDId",
                table: "WeavingRouting",
                newName: "IX_WeavingRouting_WeavingArticleId");

            migrationBuilder.RenameColumn(
                name: "WeavingIEDId",
                table: "WeavingRappo",
                newName: "WeavingArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_WeavingRappo_WeavingIEDId",
                table: "WeavingRappo",
                newName: "IX_WeavingRappo_WeavingArticleId");

            migrationBuilder.RenameColumn(
                name: "RequestArticleOutputId",
                table: "WeavingIED",
                newName: "RequestDivisionId");

            migrationBuilder.RenameColumn(
                name: "ArticleCode",
                table: "WeavingIED",
                newName: "RequestNo");

            migrationBuilder.RenameIndex(
                name: "IX_WeavingIED_RequestArticleOutputId",
                table: "WeavingIED",
                newName: "IX_WeavingIED_RequestDivisionId");

            migrationBuilder.RenameColumn(
                name: "WeavingIEDId",
                table: "WeavingDetailStructure",
                newName: "WeavingArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_WeavingDetailStructure_WeavingIEDId",
                table: "WeavingDetailStructure",
                newName: "IX_WeavingDetailStructure_WeavingArticleId");

            migrationBuilder.RenameColumn(
                name: "RequestArticleOutputId",
                table: "KnittingIED",
                newName: "RequestDivisionId");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "WeavingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "SewingIED",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleName",
                table: "KnittingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleCode",
                table: "KnittingIED",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ArticleId",
                table: "KnittingIED",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WeavingArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingIEDId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingArticle_WeavingIED_WeavingIEDId",
                        column: x => x.WeavingIEDId,
                        principalTable: "WeavingIED",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KnittingIED_RequestDivisionId",
                table: "KnittingIED",
                column: "RequestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingArticle_WeavingIEDId",
                table: "WeavingArticle",
                column: "WeavingIEDId");

            migrationBuilder.AddForeignKey(
                name: "FK_KnittingIED_RequestDivision_RequestDivisionId",
                table: "KnittingIED",
                column: "RequestDivisionId",
                principalTable: "RequestDivision",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WeavingDetailStructure_WeavingArticle_WeavingArticleId",
                table: "WeavingDetailStructure",
                column: "WeavingArticleId",
                principalTable: "WeavingArticle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeavingIED_RequestDivision_RequestDivisionId",
                table: "WeavingIED",
                column: "RequestDivisionId",
                principalTable: "RequestDivision",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeavingRappo_WeavingArticle_WeavingArticleId",
                table: "WeavingRappo",
                column: "WeavingArticleId",
                principalTable: "WeavingArticle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeavingRouting_WeavingArticle_WeavingArticleId",
                table: "WeavingRouting",
                column: "WeavingArticleId",
                principalTable: "WeavingArticle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeavingRusticFabricSpec_WeavingArticle_WeavingArticleId",
                table: "WeavingRusticFabricSpec",
                column: "WeavingArticleId",
                principalTable: "WeavingArticle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeavingYarn_WeavingArticle_WeavingArticleId",
                table: "WeavingYarn",
                column: "WeavingArticleId",
                principalTable: "WeavingArticle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
