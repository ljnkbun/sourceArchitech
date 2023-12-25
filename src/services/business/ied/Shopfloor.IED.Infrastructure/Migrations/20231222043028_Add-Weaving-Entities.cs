using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddWeavingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeavingIED",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDivisionId = table.Column<int>(type: "int", nullable: false),
                    RequestNo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingIED", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingIED_RequestDivision_RequestDivisionId",
                        column: x => x.RequestDivisionId,
                        principalTable: "RequestDivision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeavingArticle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingIEDId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ArticleName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "WeavingDetailStructure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingArticleId = table.Column<int>(type: "int", nullable: false),
                    StructureType = table.Column<byte>(type: "tinyint", nullable: false),
                    CombString = table.Column<int>(type: "int", nullable: false),
                    SlotNumber = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingDetailStructure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingDetailStructure_WeavingArticle_WeavingArticleId",
                        column: x => x.WeavingArticleId,
                        principalTable: "WeavingArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeavingRappo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingArticleId = table.Column<int>(type: "int", nullable: false),
                    NumOfLine = table.Column<int>(type: "int", nullable: false),
                    YarnOfBorder = table.Column<int>(type: "int", nullable: false),
                    YarnOfBackground = table.Column<int>(type: "int", nullable: false),
                    NumOfRappo = table.Column<int>(type: "int", nullable: false),
                    VerticalRappoComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorizontalRappoComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingRappo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingRappo_WeavingArticle_WeavingArticleId",
                        column: x => x.WeavingArticleId,
                        principalTable: "WeavingArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeavingRouting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingArticleId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    WeavingProcess = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    WeavingOperation = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MachineType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingRouting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingRouting_WeavingArticle_WeavingArticleId",
                        column: x => x.WeavingArticleId,
                        principalTable: "WeavingArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeavingRusticFabricSpec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingArticleId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    BackgroundType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BackgroundLoomFrame = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BorderType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BorderLoomFrame = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    WeightGM = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    WeightGM2 = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    VerticalShrinkage = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    HorizontalShrinkage = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineType = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    RPM = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    CombNum = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    CombSize = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    VerticalDensity = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    HorizontalDensity = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    RusticSize = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    HorizontalDensitySetting = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingRusticFabricSpec", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingRusticFabricSpec_WeavingArticle_WeavingArticleId",
                        column: x => x.WeavingArticleId,
                        principalTable: "WeavingArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeavingRappoMark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingRappoId = table.Column<int>(type: "int", nullable: false),
                    ColumnNo = table.Column<int>(type: "int", nullable: false),
                    PatternIndex = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingRappoMark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingRappoMark_WeavingRappo_WeavingRappoId",
                        column: x => x.WeavingRappoId,
                        principalTable: "WeavingRappo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeavingYarn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingArticleId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    YarnType = table.Column<byte>(type: "tinyint", nullable: false),
                    YarnCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YarnName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    YarnInRappo = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    YarnRatio = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    SizingRatio = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ScaleRatio = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ScrapRatio = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    WeavingRappoId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingYarn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingYarn_WeavingArticle_WeavingArticleId",
                        column: x => x.WeavingArticleId,
                        principalTable: "WeavingArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeavingYarn_WeavingRappo_WeavingRappoId",
                        column: x => x.WeavingRappoId,
                        principalTable: "WeavingRappo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WeavingRappoMatric",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeavingRappoId = table.Column<int>(type: "int", nullable: false),
                    RowIndex = table.Column<int>(type: "int", nullable: false),
                    ColumnIndex = table.Column<int>(type: "int", nullable: false),
                    LoopIndex = table.Column<int>(type: "int", nullable: false),
                    HorizontalYarnId = table.Column<int>(type: "int", nullable: false),
                    VerticleYarnId = table.Column<int>(type: "int", nullable: false),
                    BackgroundType = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeavingRappoMatric", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeavingRappoMatric_WeavingRappo_WeavingRappoId",
                        column: x => x.WeavingRappoId,
                        principalTable: "WeavingRappo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeavingRappoMatric_WeavingYarn_HorizontalYarnId",
                        column: x => x.HorizontalYarnId,
                        principalTable: "WeavingYarn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WeavingRappoMatric_WeavingYarn_VerticleYarnId",
                        column: x => x.VerticleYarnId,
                        principalTable: "WeavingYarn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WeavingArticle_WeavingIEDId",
                table: "WeavingArticle",
                column: "WeavingIEDId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingDetailStructure_WeavingArticleId",
                table: "WeavingDetailStructure",
                column: "WeavingArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingIED_RequestDivisionId",
                table: "WeavingIED",
                column: "RequestDivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRappo_WeavingArticleId",
                table: "WeavingRappo",
                column: "WeavingArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRappoMark_WeavingRappoId",
                table: "WeavingRappoMark",
                column: "WeavingRappoId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRappoMatric_HorizontalYarnId",
                table: "WeavingRappoMatric",
                column: "HorizontalYarnId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRappoMatric_VerticleYarnId",
                table: "WeavingRappoMatric",
                column: "VerticleYarnId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRappoMatric_WeavingRappoId",
                table: "WeavingRappoMatric",
                column: "WeavingRappoId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRouting_WeavingArticleId",
                table: "WeavingRouting",
                column: "WeavingArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingRusticFabricSpec_WeavingArticleId",
                table: "WeavingRusticFabricSpec",
                column: "WeavingArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingYarn_WeavingArticleId",
                table: "WeavingYarn",
                column: "WeavingArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_WeavingYarn_WeavingRappoId",
                table: "WeavingYarn",
                column: "WeavingRappoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeavingDetailStructure");

            migrationBuilder.DropTable(
                name: "WeavingRappoMark");

            migrationBuilder.DropTable(
                name: "WeavingRappoMatric");

            migrationBuilder.DropTable(
                name: "WeavingRouting");

            migrationBuilder.DropTable(
                name: "WeavingRusticFabricSpec");

            migrationBuilder.DropTable(
                name: "WeavingYarn");

            migrationBuilder.DropTable(
                name: "WeavingRappo");

            migrationBuilder.DropTable(
                name: "WeavingArticle");

            migrationBuilder.DropTable(
                name: "WeavingIED");
        }
    }
}
