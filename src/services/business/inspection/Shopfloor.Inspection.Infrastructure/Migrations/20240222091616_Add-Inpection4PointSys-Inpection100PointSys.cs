using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInpection4PointSysInpection100PointSys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inpection100PointSys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QCRequestArticleId = table.Column<int>(type: "int", nullable: true),
                    StockMovementNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CaptureMeter = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ActualWeight = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalDefect = table.Column<int>(type: "int", nullable: false),
                    TotalContDefect = table.Column<int>(type: "int", nullable: false),
                    TotalPoint = table.Column<int>(type: "int", nullable: false),
                    PointSquareMeter = table.Column<int>(type: "int", nullable: false),
                    WarpDensity = table.Column<int>(type: "int", nullable: true),
                    WeftDensity = table.Column<int>(type: "int", nullable: true),
                    PersonInChargeId = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AttachmentId = table.Column<int>(type: "int", nullable: true),
                    SystemResult = table.Column<bool>(type: "bit", nullable: false),
                    UserResult = table.Column<bool>(type: "bit", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    WeightGM2 = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    IsCreatedFromProduction = table.Column<bool>(type: "bit", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inpection100PointSys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inpection100PointSys_QCRequestArticle_QCRequestArticleId",
                        column: x => x.QCRequestArticleId,
                        principalTable: "QCRequestArticle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Inpection4PointSys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QCRequestArticleId = table.Column<int>(type: "int", nullable: true),
                    StockMovementNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CaptureMeter = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ActualWeight = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalDefect = table.Column<int>(type: "int", nullable: false),
                    TotalContDefect = table.Column<int>(type: "int", nullable: false),
                    TotalPoint = table.Column<int>(type: "int", nullable: false),
                    PointSquareMeter = table.Column<int>(type: "int", nullable: false),
                    WarpDensity = table.Column<int>(type: "int", nullable: true),
                    WeftDensity = table.Column<int>(type: "int", nullable: true),
                    PersonInChargeId = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AttachmentId = table.Column<int>(type: "int", nullable: true),
                    SystemResult = table.Column<bool>(type: "bit", nullable: false),
                    UserResult = table.Column<bool>(type: "bit", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    WeightGM2 = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    IsCreatedFromProduction = table.Column<bool>(type: "bit", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inpection4PointSys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inpection4PointSys_QCRequestArticle_QCRequestArticleId",
                        column: x => x.QCRequestArticleId,
                        principalTable: "QCRequestArticle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InpectionTCStandard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QCRequestArticleId = table.Column<int>(type: "int", nullable: false),
                    StockMovementNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Grade = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Result = table.Column<bool>(type: "bit", nullable: false),
                    PersonInChargeId = table.Column<int>(type: "int", nullable: false),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsCreatedFromProduction = table.Column<bool>(type: "bit", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InpectionTCStandard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InpectionTCStandard_QCRequestArticle_QCRequestArticleId",
                        column: x => x.QCRequestArticleId,
                        principalTable: "QCRequestArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionDefectError100PointSys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionDefectCapturing4PointSysId = table.Column<int>(type: "int", nullable: false),
                    ErrorType = table.Column<byte>(type: "tinyint", nullable: false),
                    From = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionDefectError100PointSys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InspectionDefectError4PointSys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionDefectCapturing4PointSysId = table.Column<int>(type: "int", nullable: false),
                    ErrorType = table.Column<byte>(type: "tinyint", nullable: false),
                    From = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionDefectError4PointSys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InspectionDefectCapturing100PointSys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inpection100PointSysId = table.Column<int>(type: "int", nullable: false),
                    QCDefectId = table.Column<int>(type: "int", nullable: false),
                    Minor = table.Column<int>(type: "int", nullable: true),
                    Major = table.Column<int>(type: "int", nullable: true),
                    Critial = table.Column<int>(type: "int", nullable: true),
                    AttachmentId = table.Column<int>(type: "int", nullable: true),
                    ProblemRootCauseId = table.Column<int>(type: "int", nullable: true),
                    ProblemCorrectiveActionId = table.Column<int>(type: "int", nullable: true),
                    ProblemTimelineId = table.Column<int>(type: "int", nullable: true),
                    PersonInChargeId = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionDefectCapturing100PointSys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionDefectCapturing100PointSys_Inpection100PointSys_Inpection100PointSysId",
                        column: x => x.Inpection100PointSysId,
                        principalTable: "Inpection100PointSys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionDefectCapturing4PointSys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inpection4PointSysId = table.Column<int>(type: "int", nullable: false),
                    QCDefectId = table.Column<int>(type: "int", nullable: false),
                    DefectQtyOne = table.Column<int>(type: "int", nullable: true),
                    DefectQtyTwo = table.Column<int>(type: "int", nullable: true),
                    DefectQtyThree = table.Column<int>(type: "int", nullable: true),
                    DefectQtyFour = table.Column<int>(type: "int", nullable: true),
                    MinorOne = table.Column<int>(type: "int", nullable: true),
                    MinorTwo = table.Column<int>(type: "int", nullable: true),
                    MinorThree = table.Column<int>(type: "int", nullable: true),
                    MinorFour = table.Column<int>(type: "int", nullable: true),
                    MajorOne = table.Column<int>(type: "int", nullable: true),
                    MajorTwo = table.Column<int>(type: "int", nullable: true),
                    MajorThree = table.Column<int>(type: "int", nullable: true),
                    MajorFour = table.Column<int>(type: "int", nullable: true),
                    ProblemRootCauseId = table.Column<int>(type: "int", nullable: true),
                    ProblemCorrectiveActionId = table.Column<int>(type: "int", nullable: true),
                    ProblemTimelineId = table.Column<int>(type: "int", nullable: true),
                    PersonInChargeId = table.Column<int>(type: "int", nullable: true),
                    AttachmentId = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionDefectCapturing4PointSys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionDefectCapturing4PointSys_Inpection4PointSys_Inpection4PointSysId",
                        column: x => x.Inpection4PointSysId,
                        principalTable: "Inpection4PointSys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionDefectCapturingTCStandard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InpectionTCStandardId = table.Column<int>(type: "int", nullable: false),
                    QCDefectId = table.Column<int>(type: "int", nullable: false),
                    Defect = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ProblemRootCauseId = table.Column<int>(type: "int", nullable: true),
                    ProblemCorrectiveActionId = table.Column<int>(type: "int", nullable: true),
                    ProblemTimelineId = table.Column<int>(type: "int", nullable: true),
                    PersonInChargeId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionDefectCapturingTCStandard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionDefectCapturingTCStandard_InpectionTCStandard_InpectionTCStandardId",
                        column: x => x.InpectionTCStandardId,
                        principalTable: "InpectionTCStandard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inpection100PointSys_QCRequestArticleId",
                table: "Inpection100PointSys",
                column: "QCRequestArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Inpection4PointSys_QCRequestArticleId",
                table: "Inpection4PointSys",
                column: "QCRequestArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_InpectionTCStandard_QCRequestArticleId",
                table: "InpectionTCStandard",
                column: "QCRequestArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionDefectCapturing100PointSys_Inpection100PointSysId",
                table: "InspectionDefectCapturing100PointSys",
                column: "Inpection100PointSysId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionDefectCapturing4PointSys_Inpection4PointSysId",
                table: "InspectionDefectCapturing4PointSys",
                column: "Inpection4PointSysId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionDefectCapturingTCStandard_InpectionTCStandardId",
                table: "InspectionDefectCapturingTCStandard",
                column: "InpectionTCStandardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InspectionDefectCapturing100PointSys");

            migrationBuilder.DropTable(
                name: "InspectionDefectCapturing4PointSys");

            migrationBuilder.DropTable(
                name: "InspectionDefectCapturingTCStandard");

            migrationBuilder.DropTable(
                name: "InspectionDefectError100PointSys");

            migrationBuilder.DropTable(
                name: "InspectionDefectError4PointSys");

            migrationBuilder.DropTable(
                name: "Inpection100PointSys");

            migrationBuilder.DropTable(
                name: "Inpection4PointSys");

            migrationBuilder.DropTable(
                name: "InpectionTCStandard");
        }
    }
}
