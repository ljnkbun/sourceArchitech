using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class renametaskgrouptomacro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SewingOperationTaskGroupMapLibs");

            migrationBuilder.DropTable(
                name: "SewingTaskGroupMapLibs");

            migrationBuilder.DropTable(
                name: "SewingTaskGroupLib");

            migrationBuilder.CreateTable(
                name: "SewingMacroLib",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FolderTreeId = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingMacroLib", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingMacroLib_FolderTree_FolderTreeId",
                        column: x => x.FolderTreeId,
                        principalTable: "FolderTree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingMacroMapLibs",
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
                    SewingOperationLibId = table.Column<int>(type: "int", nullable: false),
                    SewingMacroLibId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_SewingMacroLib_FolderTreeId",
                table: "SewingMacroLib",
                column: "FolderTreeId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SewingMacroMapLibs");

            migrationBuilder.DropTable(
                name: "SewingOperationMacroMapLibs");

            migrationBuilder.DropTable(
                name: "SewingMacroLib");

            migrationBuilder.CreateTable(
                name: "SewingTaskGroupLib",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FolderTreeId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingTaskGroupLib", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingTaskGroupLib_FolderTree_FolderTreeId",
                        column: x => x.FolderTreeId,
                        principalTable: "FolderTree",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingOperationTaskGroupMapLibs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingOperationLibId = table.Column<int>(type: "int", nullable: false),
                    SewingTaskGroupLibId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperationTaskGroupMapLibs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationTaskGroupMapLibs_SewingOperationLibs_SewingOperationLibId",
                        column: x => x.SewingOperationLibId,
                        principalTable: "SewingOperationLibs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingOperationTaskGroupMapLibs_SewingTaskGroupLib_SewingTaskGroupLibId",
                        column: x => x.SewingTaskGroupLibId,
                        principalTable: "SewingTaskGroupLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingTaskGroupMapLibs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingTaskGroupLibId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SewingTaskGroupMapLibs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingTaskGroupMapLibs_SewingTaskGroupLib_SewingTaskGroupLibId",
                        column: x => x.SewingTaskGroupLibId,
                        principalTable: "SewingTaskGroupLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SewingTaskGroupMapLibs_SewingTaskLib_SewingTaskLibId",
                        column: x => x.SewingTaskLibId,
                        principalTable: "SewingTaskLib",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationTaskGroupMapLibs_SewingOperationLibId",
                table: "SewingOperationTaskGroupMapLibs",
                column: "SewingOperationLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationTaskGroupMapLibs_SewingTaskGroupLibId",
                table: "SewingOperationTaskGroupMapLibs",
                column: "SewingTaskGroupLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingTaskGroupLib_FolderTreeId",
                table: "SewingTaskGroupLib",
                column: "FolderTreeId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingTaskGroupMapLibs_SewingTaskGroupLibId",
                table: "SewingTaskGroupMapLibs",
                column: "SewingTaskGroupLibId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingTaskGroupMapLibs_SewingTaskLibId",
                table: "SewingTaskGroupMapLibs",
                column: "SewingTaskLibId");
        }
    }
}
