using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class create_sewingprocess_operation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SewingOperation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    ParentType = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalSMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    NonMachineTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LabourCost = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    QuatityPoints = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    QualityComments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Freq = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Effort = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    AllowedTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
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
                    table.PrimaryKey("PK_SewingOperation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SewingProcess",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestDivisionId = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    ArticleCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ArticleName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    AllowedTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    FactoryTime = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LabourCostOp = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    LabourCostFactory = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    FactoryOverheadAgainstLabourPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LabourCostFactoryIncludingOverhead = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SewingProcess", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingProcess_RequestDivision_RequestDivisionId",
                        column: x => x.RequestDivisionId,
                        principalTable: "RequestDivision",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SewingOperationDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SewingOperationId = table.Column<int>(type: "int", nullable: false),
                    LineNumber = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Freq = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ManualTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    MachineTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    BundleTMU = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    TotalSMV = table.Column<decimal>(type: "decimal(28,8)", nullable: false),
                    SewingTaskOrTaskGroupId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_SewingOperationDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SewingOperationDetail_SewingOperation_SewingOperationId",
                        column: x => x.SewingOperationId,
                        principalTable: "SewingOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SewingOperationDetail_SewingOperationId",
                table: "SewingOperationDetail",
                column: "SewingOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_SewingProcess_RequestDivisionId",
                table: "SewingProcess",
                column: "RequestDivisionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SewingOperationDetail");

            migrationBuilder.DropTable(
                name: "SewingProcess");

            migrationBuilder.DropTable(
                name: "SewingOperation");
        }
    }
}
