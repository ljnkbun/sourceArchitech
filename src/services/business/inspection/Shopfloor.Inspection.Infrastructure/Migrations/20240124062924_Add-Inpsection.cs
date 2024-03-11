using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInpsection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestEntity");

            migrationBuilder.CreateTable(
                name: "AQLVersion",
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
                    table.PrimaryKey("PK_AQLVersion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conversion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Conversion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FabricWeight",
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
                    table.PrimaryKey("PK_FabricWeight", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FourPointSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Formula = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                    table.PrimaryKey("PK_FourPointSystem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inspection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    QCRequestArticleID = table.Column<int>(type: "int", nullable: true),
                    QCRequestNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SamplePlan = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SampleQty = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    DefaultResult = table.Column<bool>(type: "bit", nullable: false),
                    UserResult = table.Column<bool>(type: "bit", nullable: false),
                    MeasurementResult = table.Column<bool>(type: "bit", nullable: false),
                    MeasurementQty = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    InspectionQty = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Line = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TotalDefect = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    Stage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Style = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CuttingTable = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsCreatedFromProduction = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Buyer = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GroupType = table.Column<byte>(type: "tinyint", nullable: false),
                    Mandatory = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_TestGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AQL",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AQLVersionId = table.Column<int>(type: "int", nullable: false),
                    LotSizeFrom = table.Column<int>(type: "int", nullable: false),
                    LotSizeTo = table.Column<int>(type: "int", nullable: false),
                    SampleSize = table.Column<int>(type: "int", nullable: false),
                    Accept = table.Column<int>(type: "int", nullable: true),
                    Reject = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AQL", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AQL_AQLVersion_AQLVersionId",
                        column: x => x.AQLVersionId,
                        principalTable: "AQLVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OneHundredPointSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Point = table.Column<int>(type: "int", nullable: false),
                    DefectQuantityFrom = table.Column<int>(type: "int", nullable: false),
                    DefectQuantityTo = table.Column<int>(type: "int", nullable: true),
                    FabricWeightId = table.Column<int>(type: "int", nullable: false),
                    Soc = table.Column<int>(type: "int", nullable: true),
                    DefectCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneHundredPointSystem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneHundredPointSystem_FabricWeight_FabricWeightId",
                        column: x => x.FabricWeightId,
                        principalTable: "FabricWeight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sampling",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandardType = table.Column<byte>(type: "tinyint", nullable: false),
                    PercentQC = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    PercentAcceptance = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    FixedQty = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    AcceptanceQty = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    AQLVersionId = table.Column<int>(type: "int", nullable: true),
                    FourPointSystemId = table.Column<int>(type: "int", nullable: true),
                    FabricWeightId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Sampling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sampling_AQLVersion_AQLVersionId",
                        column: x => x.AQLVersionId,
                        principalTable: "AQLVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sampling_FabricWeight_FabricWeightId",
                        column: x => x.FabricWeightId,
                        principalTable: "FabricWeight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sampling_FourPointSystem_FourPointSystemId",
                        column: x => x.FourPointSystemId,
                        principalTable: "FourPointSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FileId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    FileType = table.Column<byte>(type: "tinyint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachment_Inspection_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionBySize",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ColorName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SizeCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SizeName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Shade = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Lot = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    GRNQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    PreInspectedQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LotQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    InspectionQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ActualQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    NoOfDefect = table.Column<int>(type: "int", nullable: false),
                    OKQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BGroupQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BGroupUsable = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    RejectedQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ExcessShortageQty = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ReasonforBGroup = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InspectionId = table.Column<int>(type: "int", nullable: false),
                    QCRequestDetailId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionBySize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionBySize_Inspection_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionDefectCapturing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Minor = table.Column<int>(type: "int", nullable: false),
                    Major = table.Column<int>(type: "int", nullable: false),
                    Critial = table.Column<int>(type: "int", nullable: false),
                    ProblemRootCauseId = table.Column<int>(type: "int", nullable: true),
                    ProblemCorrectiveActionId = table.Column<int>(type: "int", nullable: true),
                    ProblemTimelineId = table.Column<int>(type: "int", nullable: true),
                    PersonInChargeId = table.Column<int>(type: "int", nullable: true),
                    InspectionId = table.Column<int>(type: "int", nullable: false),
                    QCDefinitionDefectId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionDefectCapturing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionDefectCapturing_Inspection_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionDefectError",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspectionId = table.Column<int>(type: "int", nullable: false),
                    ErrorType = table.Column<byte>(type: "tinyint", nullable: false),
                    From = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    To = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionDefectError", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionDefectError_Inspection_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InspectionMesurement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Minor = table.Column<int>(type: "int", nullable: false),
                    Major = table.Column<int>(type: "int", nullable: false),
                    Critial = table.Column<int>(type: "int", nullable: false),
                    ProblemRootCauseId = table.Column<int>(type: "int", nullable: true),
                    ProblemCorrectiveActionId = table.Column<int>(type: "int", nullable: true),
                    ProblemTimelineId = table.Column<int>(type: "int", nullable: true),
                    PersonInChargeId = table.Column<int>(type: "int", nullable: true),
                    InspectionId = table.Column<int>(type: "int", nullable: false),
                    QCDefinitionDefectId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspectionMesurement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspectionMesurement_Inspection_InspectionId",
                        column: x => x.InspectionId,
                        principalTable: "Inspection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TestGroupId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Test", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Test_TestGroup_TestGroupId",
                        column: x => x.TestGroupId,
                        principalTable: "TestGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AQL_AQLVersionId",
                table: "AQL",
                column: "AQLVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_AQLVersion_Code",
                table: "AQLVersion",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_InspectionId",
                table: "Attachment",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Conversion_Code",
                table: "Conversion",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FabricWeight_Code",
                table: "FabricWeight",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FourPointSystem_Code",
                table: "FourPointSystem",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspectionBySize_InspectionId",
                table: "InspectionBySize",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionDefectCapturing_InspectionId",
                table: "InspectionDefectCapturing",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionDefectError_InspectionId",
                table: "InspectionDefectError",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_InspectionMesurement_InspectionId",
                table: "InspectionMesurement",
                column: "InspectionId");

            migrationBuilder.CreateIndex(
                name: "IX_OneHundredPointSystem_FabricWeightId",
                table: "OneHundredPointSystem",
                column: "FabricWeightId");

            migrationBuilder.CreateIndex(
                name: "IX_Sampling_AQLVersionId",
                table: "Sampling",
                column: "AQLVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sampling_Code",
                table: "Sampling",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sampling_FabricWeightId",
                table: "Sampling",
                column: "FabricWeightId");

            migrationBuilder.CreateIndex(
                name: "IX_Sampling_FourPointSystemId",
                table: "Sampling",
                column: "FourPointSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Test_Code",
                table: "Test",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Test_TestGroupId",
                table: "Test",
                column: "TestGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TestGroup_Code",
                table: "TestGroup",
                column: "Code",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AQL");

            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropTable(
                name: "Conversion");

            migrationBuilder.DropTable(
                name: "InspectionBySize");

            migrationBuilder.DropTable(
                name: "InspectionDefectCapturing");

            migrationBuilder.DropTable(
                name: "InspectionDefectError");

            migrationBuilder.DropTable(
                name: "InspectionMesurement");

            migrationBuilder.DropTable(
                name: "OneHundredPointSystem");

            migrationBuilder.DropTable(
                name: "Sampling");

            migrationBuilder.DropTable(
                name: "Test");

            migrationBuilder.DropTable(
                name: "Inspection");

            migrationBuilder.DropTable(
                name: "AQLVersion");

            migrationBuilder.DropTable(
                name: "FabricWeight");

            migrationBuilder.DropTable(
                name: "FourPointSystem");

            migrationBuilder.DropTable(
                name: "TestGroup");

            migrationBuilder.CreateTable(
                name: "TestEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Property01 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Property02 = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestEntity", x => x.Id);
                });
        }
    }
}
