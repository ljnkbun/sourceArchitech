using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDyeingChemicalTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DCTemplate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DCTemplateTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DCTemplateId = table.Column<int>(type: "int", nullable: false),
                    TaskCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    TaskName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Temperature = table.Column<string>(type: "varchar(50)", nullable: true),
                    Time = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCTemplateTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DCTemplateTask_DCTemplate_DCTemplateId",
                        column: x => x.DCTemplateId,
                        principalTable: "DCTemplate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DCTemplateDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DCTemplateTaskId = table.Column<int>(type: "int", nullable: false),
                    ChemicalCode = table.Column<string>(type: "varchar(50)", nullable: true),
                    ChemicalName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Value = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DCTemplateDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DCTemplateDetail_DCTemplateTask_DCTemplateTaskId",
                        column: x => x.DCTemplateTaskId,
                        principalTable: "DCTemplateTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DCTemplateDetail_DCTemplateTaskId",
                table: "DCTemplateDetail",
                column: "DCTemplateTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_DCTemplateTask_DCTemplateId",
                table: "DCTemplateTask",
                column: "DCTemplateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DCTemplateDetail");

            migrationBuilder.DropTable(
                name: "DCTemplateTask");

            migrationBuilder.DropTable(
                name: "DCTemplate");
        }
    }
}
