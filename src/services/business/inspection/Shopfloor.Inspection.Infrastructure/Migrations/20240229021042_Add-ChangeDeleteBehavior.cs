using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Inspection.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChangeDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AQL_AQLVersion_AQLVersionId",
                table: "AQL");

            migrationBuilder.DropForeignKey(
                name: "FK_OneHundredPointSystem_FabricWeight_FabricWeightId",
                table: "OneHundredPointSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_QCDefect_QCDefectType_QCDefecTypeId",
                table: "QCDefect");

            migrationBuilder.DropForeignKey(
                name: "FK_QCDefinitionDefect_QCDefect_QCDefectId",
                table: "QCDefinitionDefect");

            migrationBuilder.DropForeignKey(
                name: "FK_QCDefinitionDefect_QCDefinition_QCDefinitionId",
                table: "QCDefinitionDefect");

            migrationBuilder.DropForeignKey(
                name: "FK_Sampling_AQLVersion_AQLVersionId",
                table: "Sampling");

            migrationBuilder.DropForeignKey(
                name: "FK_Sampling_DefectScoringMethod_DefectScoringMethodId",
                table: "Sampling");

            migrationBuilder.DropForeignKey(
                name: "FK_Sampling_FabricClassification_FabricClassificationId",
                table: "Sampling");

            migrationBuilder.DropForeignKey(
                name: "FK_Sampling_FabricWeight_FabricWeightId",
                table: "Sampling");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_TestGroup_TestGroupId",
                table: "Test");

            migrationBuilder.AddForeignKey(
                name: "FK_AQL_AQLVersion_AQLVersionId",
                table: "AQL",
                column: "AQLVersionId",
                principalTable: "AQLVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OneHundredPointSystem_FabricWeight_FabricWeightId",
                table: "OneHundredPointSystem",
                column: "FabricWeightId",
                principalTable: "FabricWeight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QCDefect_QCDefectType_QCDefecTypeId",
                table: "QCDefect",
                column: "QCDefecTypeId",
                principalTable: "QCDefectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QCDefinitionDefect_QCDefect_QCDefectId",
                table: "QCDefinitionDefect",
                column: "QCDefectId",
                principalTable: "QCDefect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QCDefinitionDefect_QCDefinition_QCDefinitionId",
                table: "QCDefinitionDefect",
                column: "QCDefinitionId",
                principalTable: "QCDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sampling_AQLVersion_AQLVersionId",
                table: "Sampling",
                column: "AQLVersionId",
                principalTable: "AQLVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sampling_DefectScoringMethod_DefectScoringMethodId",
                table: "Sampling",
                column: "DefectScoringMethodId",
                principalTable: "DefectScoringMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sampling_FabricClassification_FabricClassificationId",
                table: "Sampling",
                column: "FabricClassificationId",
                principalTable: "FabricClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sampling_FabricWeight_FabricWeightId",
                table: "Sampling",
                column: "FabricWeightId",
                principalTable: "FabricWeight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Test_TestGroup_TestGroupId",
                table: "Test",
                column: "TestGroupId",
                principalTable: "TestGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AQL_AQLVersion_AQLVersionId",
                table: "AQL");

            migrationBuilder.DropForeignKey(
                name: "FK_OneHundredPointSystem_FabricWeight_FabricWeightId",
                table: "OneHundredPointSystem");

            migrationBuilder.DropForeignKey(
                name: "FK_QCDefect_QCDefectType_QCDefecTypeId",
                table: "QCDefect");

            migrationBuilder.DropForeignKey(
                name: "FK_QCDefinitionDefect_QCDefect_QCDefectId",
                table: "QCDefinitionDefect");

            migrationBuilder.DropForeignKey(
                name: "FK_QCDefinitionDefect_QCDefinition_QCDefinitionId",
                table: "QCDefinitionDefect");

            migrationBuilder.DropForeignKey(
                name: "FK_Sampling_AQLVersion_AQLVersionId",
                table: "Sampling");

            migrationBuilder.DropForeignKey(
                name: "FK_Sampling_DefectScoringMethod_DefectScoringMethodId",
                table: "Sampling");

            migrationBuilder.DropForeignKey(
                name: "FK_Sampling_FabricClassification_FabricClassificationId",
                table: "Sampling");

            migrationBuilder.DropForeignKey(
                name: "FK_Sampling_FabricWeight_FabricWeightId",
                table: "Sampling");

            migrationBuilder.DropForeignKey(
                name: "FK_Test_TestGroup_TestGroupId",
                table: "Test");

            migrationBuilder.AddForeignKey(
                name: "FK_AQL_AQLVersion_AQLVersionId",
                table: "AQL",
                column: "AQLVersionId",
                principalTable: "AQLVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OneHundredPointSystem_FabricWeight_FabricWeightId",
                table: "OneHundredPointSystem",
                column: "FabricWeightId",
                principalTable: "FabricWeight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QCDefect_QCDefectType_QCDefecTypeId",
                table: "QCDefect",
                column: "QCDefecTypeId",
                principalTable: "QCDefectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QCDefinitionDefect_QCDefect_QCDefectId",
                table: "QCDefinitionDefect",
                column: "QCDefectId",
                principalTable: "QCDefect",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QCDefinitionDefect_QCDefinition_QCDefinitionId",
                table: "QCDefinitionDefect",
                column: "QCDefinitionId",
                principalTable: "QCDefinition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sampling_AQLVersion_AQLVersionId",
                table: "Sampling",
                column: "AQLVersionId",
                principalTable: "AQLVersion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sampling_DefectScoringMethod_DefectScoringMethodId",
                table: "Sampling",
                column: "DefectScoringMethodId",
                principalTable: "DefectScoringMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sampling_FabricClassification_FabricClassificationId",
                table: "Sampling",
                column: "FabricClassificationId",
                principalTable: "FabricClassification",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sampling_FabricWeight_FabricWeightId",
                table: "Sampling",
                column: "FabricWeightId",
                principalTable: "FabricWeight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Test_TestGroup_TestGroupId",
                table: "Test",
                column: "TestGroupId",
                principalTable: "TestGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
