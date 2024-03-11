using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifySewingEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SewingSubOperationWFXBOL");

            migrationBuilder.DropTable(
                name: "SewingSubOperationWFXResult");

            migrationBuilder.DropTable(
                name: "SewingSubOperationWFX");

            migrationBuilder.DropTable(
                name: "SewingOperationWFXVersion");

            migrationBuilder.DropTable(
                name: "SewingOperationWFX");

            migrationBuilder.CreateTable(
                name: "SewingIED",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestArticleOutputId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Buyer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StyleRef = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProductGroup = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SubCategory = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    AllowedTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    FactoryTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LabourCostOp = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LabourCostFactory = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    FactoryOverheadAgainstLabourPercent = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LabourCostFactoryIncludingOverhead = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnalysisDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnalysisUser = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_SewingIED", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingIED_RequestArticleOutput_RequestArticleOutputId",
                        column: x => x.RequestArticleOutputId,
                        principalTable: "RequestArticleOutput",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingRouting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingIEDId = table.Column<int>(type: "int", nullable: false),
                    WFXProcessCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WFXProcessName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    WFXOperationCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WFXOperationName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SewingRouting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingRouting_SewingIED_SewingIEDId",
                        column: x => x.SewingIEDId,
                        principalTable: "SewingIED",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingRoutingBOL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingRoutingId = table.Column<int>(type: "int", nullable: false),
                    SewingOperationId = table.Column<int>(type: "int", nullable: true),
                    SewingFeatureId = table.Column<int>(type: "int", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Freq = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingRoutingBOL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingRoutingBOL_SewingFeature_SewingFeatureId",
                        column: x => x.SewingFeatureId,
                        principalTable: "SewingFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SewingRoutingBOL_SewingOperation_SewingOperationId",
                        column: x => x.SewingOperationId,
                        principalTable: "SewingOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SewingRoutingBOL_SewingRouting_SewingRoutingId",
                        column: x => x.SewingRoutingId,
                        principalTable: "SewingRouting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingRoutingResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingRoutingId = table.Column<int>(type: "int", nullable: false),
                    TMUType = table.Column<byte>(type: "tinyint", nullable: false),
                    TMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BasicMunite = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    PersonalAllowance = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineDelay = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Contingency = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    SMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingRoutingResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingRoutingResult_SewingRouting_SewingRoutingId",
                        column: x => x.SewingRoutingId,
                        principalTable: "SewingRouting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SewingIED_RequestArticleOutputId",
                table: "SewingIED",
                column: "RequestArticleOutputId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SewingRouting_SewingIEDId",
                table: "SewingRouting",
                column: "SewingIEDId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingRoutingBOL_SewingFeatureId",
                table: "SewingRoutingBOL",
                column: "SewingFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingRoutingBOL_SewingOperationId",
                table: "SewingRoutingBOL",
                column: "SewingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingRoutingBOL_SewingRoutingId",
                table: "SewingRoutingBOL",
                column: "SewingRoutingId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingRoutingResult_SewingRoutingId_TMUType",
                table: "SewingRoutingResult",
                columns: new[] { "SewingRoutingId", "TMUType" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SewingRoutingBOL");

            migrationBuilder.DropTable(
                name: "SewingRoutingResult");

            migrationBuilder.DropTable(
                name: "SewingRouting");

            migrationBuilder.DropTable(
                name: "SewingIED");

            migrationBuilder.CreateTable(
                name: "SewingOperationWFX",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDivisionProcessId = table.Column<int>(type: "int", nullable: false),
                    AllowedTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Buyer = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CurrentVersionId = table.Column<int>(type: "int", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FactoryOverheadAgainstLabourPercent = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    FactoryTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LabourCostFactory = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LabourCostFactoryIncludingOverhead = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LabourCostOp = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductGroup = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ProductSubCategory = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    SMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Status = table.Column<byte>(type: "tinyint", nullable: false),
                    WFXProcessCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    WFXProcessName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperationWFX", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationWFX_RequestDivisionProcess_RequestDivisionProcessId",
                        column: x => x.RequestDivisionProcessId,
                        principalTable: "RequestDivisionProcess",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingOperationWFXVersion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingOperationWFXId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingOperationWFXVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationWFXVersion_SewingOperationWFX_SewingOperationWFXId",
                        column: x => x.SewingOperationWFXId,
                        principalTable: "SewingOperationWFX",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingSubOperationWFX",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingOperationWFXVersionId = table.Column<int>(type: "int", nullable: false),
                    AllowedTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Effort = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Freq = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LabourCost = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LineCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LineNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NonMachineTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    QualityComments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    QuatityPoints = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    TotalSMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    WFXProcessCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WFXProcessName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingSubOperationWFX", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingSubOperationWFX_SewingOperationWFXVersion_SewingOperationWFXVersionId",
                        column: x => x.SewingOperationWFXVersionId,
                        principalTable: "SewingOperationWFXVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingSubOperationWFXBOL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingFeatureId = table.Column<int>(type: "int", nullable: true),
                    SewingOperationId = table.Column<int>(type: "int", nullable: true),
                    SewingSubOperationWFXId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingSubOperationWFXBOL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingSubOperationWFXBOL_SewingFeature_SewingFeatureId",
                        column: x => x.SewingFeatureId,
                        principalTable: "SewingFeature",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SewingSubOperationWFXBOL_SewingOperation_SewingOperationId",
                        column: x => x.SewingOperationId,
                        principalTable: "SewingOperation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SewingSubOperationWFXBOL_SewingSubOperationWFX_SewingSubOperationWFXId",
                        column: x => x.SewingSubOperationWFXId,
                        principalTable: "SewingSubOperationWFX",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SewingSubOperationWFXResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingSubOperationWFXId = table.Column<int>(type: "int", nullable: false),
                    BasicMunite = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Contingency = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    MachineDelay = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PersonalAllowance = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    SMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TMUType = table.Column<byte>(type: "tinyint", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(28,8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingSubOperationWFXResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingSubOperationWFXResult_SewingSubOperationWFX_SewingSubOperationWFXId",
                        column: x => x.SewingSubOperationWFXId,
                        principalTable: "SewingSubOperationWFX",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationWFX_RequestDivisionProcessId",
                table: "SewingOperationWFX",
                column: "RequestDivisionProcessId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationWFXVersion_SewingOperationWFXId_Version",
                table: "SewingOperationWFXVersion",
                columns: new[] { "SewingOperationWFXId", "Version" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SewingSubOperationWFX_SewingOperationWFXVersionId",
                table: "SewingSubOperationWFX",
                column: "SewingOperationWFXVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingSubOperationWFXBOL_SewingFeatureId",
                table: "SewingSubOperationWFXBOL",
                column: "SewingFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingSubOperationWFXBOL_SewingOperationId",
                table: "SewingSubOperationWFXBOL",
                column: "SewingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingSubOperationWFXBOL_SewingSubOperationWFXId",
                table: "SewingSubOperationWFXBOL",
                column: "SewingSubOperationWFXId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingSubOperationWFXResult_SewingSubOperationWFXId_TMUType",
                table: "SewingSubOperationWFXResult",
                columns: new[] { "SewingSubOperationWFXId", "TMUType" },
                unique: true);
        }
    }
}
