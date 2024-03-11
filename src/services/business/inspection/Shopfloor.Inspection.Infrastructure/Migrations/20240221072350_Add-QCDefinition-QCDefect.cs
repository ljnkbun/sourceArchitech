using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddQCDefinitionQCDefect : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProblemCorrectiveAction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameVN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NameEN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DivisonId = table.Column<int>(type: "int", nullable: true),
                    DivisonName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProcessId = table.Column<int>(type: "int", nullable: true),
                    ProcessName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InspectionType = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemCorrectiveAction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProblemRootCause",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameVN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NameEN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DivisonId = table.Column<int>(type: "int", nullable: true),
                    DivisonName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProcessId = table.Column<int>(type: "int", nullable: true),
                    ProcessName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InspectionType = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemRootCause", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProblemTimeline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameVN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NameEN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DivisonId = table.Column<int>(type: "int", nullable: true),
                    DivisonName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProcessId = table.Column<int>(type: "int", nullable: true),
                    ProcessName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SubCategoryId = table.Column<int>(type: "int", nullable: true),
                    SubCategoryName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InspectionType = table.Column<byte>(type: "tinyint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemTimeline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QCDefectType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QCDefectType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QCDefinition",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Buyer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AcceptanceValue = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    SamplingId = table.Column<int>(type: "int", nullable: false),
                    ConversionId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QCDefinition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QCDefinition_Conversion_ConversionId",
                        column: x => x.ConversionId,
                        principalTable: "Conversion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QCDefinition_Sampling_SamplingId",
                        column: x => x.SamplingId,
                        principalTable: "Sampling",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QCDefect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QCDefecTypeId = table.Column<int>(type: "int", nullable: false),
                    ParrentId = table.Column<int>(type: "int", nullable: true),
                    NameEN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DivisonId = table.Column<int>(type: "int", nullable: true),
                    DivisonName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProcessId = table.Column<int>(type: "int", nullable: true),
                    ProcessName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SubCategoryId = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SubCategoryName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    InspectionType = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QCDefect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QCDefect_QCDefectType_QCDefecTypeId",
                        column: x => x.QCDefecTypeId,
                        principalTable: "QCDefectType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QCDefinitionDefect",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QCDefinitionId = table.Column<int>(type: "int", nullable: false),
                    QCDefectId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QCDefinitionDefect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QCDefinitionDefect_QCDefect_QCDefectId",
                        column: x => x.QCDefectId,
                        principalTable: "QCDefect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QCDefinitionDefect_QCDefinition_QCDefinitionId",
                        column: x => x.QCDefinitionId,
                        principalTable: "QCDefinition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QCDefect_Code",
                table: "QCDefect",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QCDefect_QCDefecTypeId",
                table: "QCDefect",
                column: "QCDefecTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_QCDefectType_Code",
                table: "QCDefectType",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QCDefinition_Code",
                table: "QCDefinition",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QCDefinition_ConversionId",
                table: "QCDefinition",
                column: "ConversionId");

            migrationBuilder.CreateIndex(
                name: "IX_QCDefinition_SamplingId",
                table: "QCDefinition",
                column: "SamplingId");

            migrationBuilder.CreateIndex(
                name: "IX_QCDefinitionDefect_QCDefectId",
                table: "QCDefinitionDefect",
                column: "QCDefectId");

            migrationBuilder.CreateIndex(
                name: "IX_QCDefinitionDefect_QCDefinitionId",
                table: "QCDefinitionDefect",
                column: "QCDefinitionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProblemCorrectiveAction");

            migrationBuilder.DropTable(
                name: "ProblemRootCause");

            migrationBuilder.DropTable(
                name: "ProblemTimeline");

            migrationBuilder.DropTable(
                name: "QCDefinitionDefect");

            migrationBuilder.DropTable(
                name: "QCDefect");

            migrationBuilder.DropTable(
                name: "QCDefinition");

            migrationBuilder.DropTable(
                name: "QCDefectType");
        }
    }
}
