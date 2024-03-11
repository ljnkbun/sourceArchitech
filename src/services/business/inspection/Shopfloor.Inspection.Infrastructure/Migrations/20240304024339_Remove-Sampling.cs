using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveSampling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OneHundredPointSystem_FabricWeight_FabricWeightId",
                table: "OneHundredPointSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_QCDefinition_Sampling_SamplingId",
                table: "QCDefinition");

            migrationBuilder.DropTable(
                name: "Sampling");

            migrationBuilder.DropTable(
                name: "DefectScoringMethod");

            migrationBuilder.DropTable(
                name: "FabricClassification");

            migrationBuilder.DropIndex(
                name: "IX_QCDefinition_SamplingId",
                table: "QCDefinition");

            migrationBuilder.DropColumn(
                name: "SamplingId",
                table: "QCDefinition");

            migrationBuilder.DropColumn(
                name: "DefectCode",
                table: "OneHundredPointSystem");

            migrationBuilder.DropColumn(
                name: "DefectQuantityFrom",
                table: "OneHundredPointSystem");

            migrationBuilder.DropColumn(
                name: "DefectQuantityTo",
                table: "OneHundredPointSystem");

            migrationBuilder.DropColumn(
                name: "Point",
                table: "OneHundredPointSystem");

            migrationBuilder.DropColumn(
                name: "Soc",
                table: "OneHundredPointSystem");

            migrationBuilder.AddColumn<int>(
                name: "AQLVersionId",
                table: "QCDefinition",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AcceptanceQty",
                table: "QCDefinition",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FabricWeightId",
                table: "QCDefinition",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "FixedQty",
                table: "QCDefinition",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FourPointsSystemId",
                table: "QCDefinition",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OneHundredPointSystemId",
                table: "QCDefinition",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PercentAcceptance",
                table: "QCDefinition",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PercentQC",
                table: "QCDefinition",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "QCDefinition",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FabricWeightId",
                table: "OneHundredPointSystem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "OneHundredPointSystem",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OneHundredPointSystem",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FourPointsSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductGroup = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_FourPointsSystem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OneHundredPointSystemDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromKg = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    ToKg = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    FromDefect = table.Column<int>(type: "int", nullable: true),
                    ToDefect = table.Column<int>(type: "int", nullable: true),
                    Point = table.Column<byte>(type: "tinyint", nullable: false),
                    OneHundredPointSystemId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OneHundredPointSystemDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OneHundredPointSystemDetail_OneHundredPointSystem_OneHundredPointSystemId",
                        column: x => x.OneHundredPointSystemId,
                        principalTable: "OneHundredPointSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FourPointsSystemDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    To = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    GradeType = table.Column<byte>(type: "tinyint", nullable: false),
                    FourPointsSystemId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FourPointsSystemDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FourPointsSystemDetail_FourPointsSystem_FourPointsSystemId",
                        column: x => x.FourPointsSystemId,
                        principalTable: "FourPointsSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QCDefinition_AQLVersionId",
                table: "QCDefinition",
                column: "AQLVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_QCDefinition_FabricWeightId",
                table: "QCDefinition",
                column: "FabricWeightId");

            migrationBuilder.CreateIndex(
                name: "IX_QCDefinition_FourPointsSystemId",
                table: "QCDefinition",
                column: "FourPointsSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_QCDefinition_OneHundredPointSystemId",
                table: "QCDefinition",
                column: "OneHundredPointSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_OneHundredPointSystem_Code",
                table: "OneHundredPointSystem",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FourPointsSystem_Code",
                table: "FourPointsSystem",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FourPointsSystemDetail_FourPointsSystemId",
                table: "FourPointsSystemDetail",
                column: "FourPointsSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_OneHundredPointSystemDetail_OneHundredPointSystemId",
                table: "OneHundredPointSystemDetail",
                column: "OneHundredPointSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OneHundredPointSystem_FabricWeight_FabricWeightId",
                table: "OneHundredPointSystem",
                column: "FabricWeightId",
                principalTable: "FabricWeight",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QCDefinition_AQLVersion_AQLVersionId",
                table: "QCDefinition",
                column: "AQLVersionId",
                principalTable: "AQLVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QCDefinition_FabricWeight_FabricWeightId",
                table: "QCDefinition",
                column: "FabricWeightId",
                principalTable: "FabricWeight",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_QCDefinition_FourPointsSystem_FourPointsSystemId",
                table: "QCDefinition",
                column: "FourPointsSystemId",
                principalTable: "FourPointsSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QCDefinition_OneHundredPointSystem_OneHundredPointSystemId",
                table: "QCDefinition",
                column: "OneHundredPointSystemId",
                principalTable: "OneHundredPointSystem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OneHundredPointSystem_FabricWeight_FabricWeightId",
                table: "OneHundredPointSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_QCDefinition_AQLVersion_AQLVersionId",
                table: "QCDefinition");

            migrationBuilder.DropForeignKey(
                name: "FK_QCDefinition_FabricWeight_FabricWeightId",
                table: "QCDefinition");

            migrationBuilder.DropForeignKey(
                name: "FK_QCDefinition_FourPointsSystem_FourPointsSystemId",
                table: "QCDefinition");

            migrationBuilder.DropForeignKey(
                name: "FK_QCDefinition_OneHundredPointSystem_OneHundredPointSystemId",
                table: "QCDefinition");

            migrationBuilder.DropTable(
                name: "FourPointsSystemDetail");

            migrationBuilder.DropTable(
                name: "OneHundredPointSystemDetail");

            migrationBuilder.DropTable(
                name: "FourPointsSystem");

            migrationBuilder.DropIndex(
                name: "IX_QCDefinition_AQLVersionId",
                table: "QCDefinition");

            migrationBuilder.DropIndex(
                name: "IX_QCDefinition_FabricWeightId",
                table: "QCDefinition");

            migrationBuilder.DropIndex(
                name: "IX_QCDefinition_FourPointsSystemId",
                table: "QCDefinition");

            migrationBuilder.DropIndex(
                name: "IX_QCDefinition_OneHundredPointSystemId",
                table: "QCDefinition");

            migrationBuilder.DropIndex(
                name: "IX_OneHundredPointSystem_Code",
                table: "OneHundredPointSystem");

            migrationBuilder.DropColumn(
                name: "AQLVersionId",
                table: "QCDefinition");

            migrationBuilder.DropColumn(
                name: "AcceptanceQty",
                table: "QCDefinition");

            migrationBuilder.DropColumn(
                name: "FabricWeightId",
                table: "QCDefinition");

            migrationBuilder.DropColumn(
                name: "FixedQty",
                table: "QCDefinition");

            migrationBuilder.DropColumn(
                name: "FourPointsSystemId",
                table: "QCDefinition");

            migrationBuilder.DropColumn(
                name: "OneHundredPointSystemId",
                table: "QCDefinition");

            migrationBuilder.DropColumn(
                name: "PercentAcceptance",
                table: "QCDefinition");

            migrationBuilder.DropColumn(
                name: "PercentQC",
                table: "QCDefinition");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "QCDefinition");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "OneHundredPointSystem");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "OneHundredPointSystem");

            migrationBuilder.AddColumn<int>(
                name: "SamplingId",
                table: "QCDefinition",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "FabricWeightId",
                table: "OneHundredPointSystem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DefectCode",
                table: "OneHundredPointSystem",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DefectQuantityFrom",
                table: "OneHundredPointSystem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DefectQuantityTo",
                table: "OneHundredPointSystem",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Point",
                table: "OneHundredPointSystem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Soc",
                table: "OneHundredPointSystem",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DefectScoringMethod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DirectionType = table.Column<byte>(type: "tinyint", nullable: false),
                    FourPointType = table.Column<byte>(type: "tinyint", nullable: false),
                    From = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    To = table.Column<decimal>(type: "decimal(28,8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefectScoringMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FabricClassification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FabricType = table.Column<byte>(type: "tinyint", nullable: false),
                    From = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    To = table.Column<decimal>(type: "decimal(28,8)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FabricClassification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sampling",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AQLVersionId = table.Column<int>(type: "int", nullable: true),
                    DefectScoringMethodId = table.Column<int>(type: "int", nullable: true),
                    FabricClassificationId = table.Column<int>(type: "int", nullable: true),
                    FabricWeightId = table.Column<int>(type: "int", nullable: true),
                    AcceptanceQty = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FixedQty = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PercentAcceptance = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    PercentQC = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(28,8)", nullable: true),
                    StandardType = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sampling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sampling_AQLVersion_AQLVersionId",
                        column: x => x.AQLVersionId,
                        principalTable: "AQLVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sampling_DefectScoringMethod_DefectScoringMethodId",
                        column: x => x.DefectScoringMethodId,
                        principalTable: "DefectScoringMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sampling_FabricClassification_FabricClassificationId",
                        column: x => x.FabricClassificationId,
                        principalTable: "FabricClassification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sampling_FabricWeight_FabricWeightId",
                        column: x => x.FabricWeightId,
                        principalTable: "FabricWeight",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QCDefinition_SamplingId",
                table: "QCDefinition",
                column: "SamplingId");

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
                name: "IX_Sampling_DefectScoringMethodId",
                table: "Sampling",
                column: "DefectScoringMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Sampling_FabricClassificationId",
                table: "Sampling",
                column: "FabricClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Sampling_FabricWeightId",
                table: "Sampling",
                column: "FabricWeightId");

            migrationBuilder.AddForeignKey(
                name: "FK_OneHundredPointSystem_FabricWeight_FabricWeightId",
                table: "OneHundredPointSystem",
                column: "FabricWeightId",
                principalTable: "FabricWeight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QCDefinition_Sampling_SamplingId",
                table: "QCDefinition",
                column: "SamplingId",
                principalTable: "Sampling",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
