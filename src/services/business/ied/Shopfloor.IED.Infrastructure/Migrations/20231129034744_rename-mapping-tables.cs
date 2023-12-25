using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renamemappingtables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SewingFeatureMapLibs");

            migrationBuilder.DropTable(
                name: "SewingMacroMapLibs");

            migrationBuilder.DropTable(
                name: "SewingOperationMacroMapLibs");

            migrationBuilder.DropTable(
                name: "SewingOperationTaskMapLibs");

            migrationBuilder.CreateTable(
                name: "SewingFeatureLibBOLs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingOperationLibId = table.Column<int>(type: "int", nullable: false),
                    SewingFeatureLibId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingFeatureLibBOLs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingFeatureLibBOLs_SewingFeatureLibs_SewingFeatureLibId",
                        column: x => x.SewingFeatureLibId,
                        principalTable: "SewingFeatureLibs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingFeatureLibBOLs_SewingOperationLibs_SewingOperationLibId",
                        column: x => x.SewingOperationLibId,
                        principalTable: "SewingOperationLibs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingMacroLibBOLs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingTaskLibId = table.Column<int>(type: "int", nullable: false),
                    SewingMacroLibId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingMacroLibBOLs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingMacroLibBOLs_SewingMacroLib_SewingMacroLibId",
                        column: x => x.SewingMacroLibId,
                        principalTable: "SewingMacroLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingMacroLibBOLs_SewingTaskLib_SewingTaskLibId",
                        column: x => x.SewingTaskLibId,
                        principalTable: "SewingTaskLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingOperationLibBOLs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingOperationLibId = table.Column<int>(type: "int", nullable: false),
                    SewingTaskLibId = table.Column<int>(type: "int", nullable: true),
                    SewingMacroLibId = table.Column<int>(type: "int", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperationLibBOLs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationLibBOLs_SewingOperationLibs_SewingOperationLibId",
                        column: x => x.SewingOperationLibId,
                        principalTable: "SewingOperationLibs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingOperationLibBOLs_SewingTaskLib_SewingTaskLibId",
                        column: x => x.SewingTaskLibId,
                        principalTable: "SewingTaskLib",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureLibBOLs_SewingFeatureLibId",
                table: "SewingFeatureLibBOLs",
                column: "SewingFeatureLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureLibBOLs_SewingOperationLibId",
                table: "SewingFeatureLibBOLs",
                column: "SewingOperationLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMacroLibBOLs_SewingMacroLibId",
                table: "SewingMacroLibBOLs",
                column: "SewingMacroLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMacroLibBOLs_SewingTaskLibId",
                table: "SewingMacroLibBOLs",
                column: "SewingTaskLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationLibBOLs_SewingOperationLibId",
                table: "SewingOperationLibBOLs",
                column: "SewingOperationLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationLibBOLs_SewingTaskLibId",
                table: "SewingOperationLibBOLs",
                column: "SewingTaskLibId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SewingFeatureLibBOLs");

            migrationBuilder.DropTable(
                name: "SewingMacroLibBOLs");

            migrationBuilder.DropTable(
                name: "SewingOperationLibBOLs");

            migrationBuilder.CreateTable(
                name: "SewingFeatureMapLibs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingFeatureLibId = table.Column<int>(type: "int", nullable: false),
                    SewingOperationLibId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingFeatureMapLibs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingFeatureMapLibs_SewingFeatureLibs_SewingFeatureLibId",
                        column: x => x.SewingFeatureLibId,
                        principalTable: "SewingFeatureLibs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingFeatureMapLibs_SewingOperationLibs_SewingOperationLibId",
                        column: x => x.SewingOperationLibId,
                        principalTable: "SewingOperationLibs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingMacroMapLibs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingMacroLibId = table.Column<int>(type: "int", nullable: false),
                    SewingTaskLibId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingMacroMapLibs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingMacroMapLibs_SewingMacroLib_SewingMacroLibId",
                        column: x => x.SewingMacroLibId,
                        principalTable: "SewingMacroLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingMacroMapLibs_SewingTaskLib_SewingTaskLibId",
                        column: x => x.SewingTaskLibId,
                        principalTable: "SewingTaskLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingOperationMacroMapLibs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingMacroLibId = table.Column<int>(type: "int", nullable: false),
                    SewingOperationLibId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperationMacroMapLibs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationMacroMapLibs_SewingMacroLib_SewingMacroLibId",
                        column: x => x.SewingMacroLibId,
                        principalTable: "SewingMacroLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingOperationMacroMapLibs_SewingOperationLibs_SewingOperationLibId",
                        column: x => x.SewingOperationLibId,
                        principalTable: "SewingOperationLibs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingOperationTaskMapLibs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingOperationLibId = table.Column<int>(type: "int", nullable: false),
                    SewingTaskLibId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperationTaskMapLibs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationTaskMapLibs_SewingOperationLibs_SewingOperationLibId",
                        column: x => x.SewingOperationLibId,
                        principalTable: "SewingOperationLibs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingOperationTaskMapLibs_SewingTaskLib_SewingTaskLibId",
                        column: x => x.SewingTaskLibId,
                        principalTable: "SewingTaskLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureMapLibs_SewingFeatureLibId",
                table: "SewingFeatureMapLibs",
                column: "SewingFeatureLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingFeatureMapLibs_SewingOperationLibId",
                table: "SewingFeatureMapLibs",
                column: "SewingOperationLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMacroMapLibs_SewingMacroLibId",
                table: "SewingMacroMapLibs",
                column: "SewingMacroLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingMacroMapLibs_SewingTaskLibId",
                table: "SewingMacroMapLibs",
                column: "SewingTaskLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationMacroMapLibs_SewingMacroLibId",
                table: "SewingOperationMacroMapLibs",
                column: "SewingMacroLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationMacroMapLibs_SewingOperationLibId",
                table: "SewingOperationMacroMapLibs",
                column: "SewingOperationLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationTaskMapLibs_SewingOperationLibId",
                table: "SewingOperationTaskMapLibs",
                column: "SewingOperationLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationTaskMapLibs_SewingTaskLibId",
                table: "SewingOperationTaskMapLibs",
                column: "SewingTaskLibId");
        }
    }
}
