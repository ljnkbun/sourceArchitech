using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.Production.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class modifyTblDefectcapturing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectActionId",
                table: "Measurement");

            migrationBuilder.DropColumn(
                name: "PersonInChargeId",
                table: "Measurement");

            migrationBuilder.DropColumn(
                name: "Timeline",
                table: "Measurement");

            migrationBuilder.DropColumn(
                name: "CorrectActionId",
                table: "DefectCapturing4Points");

            migrationBuilder.DropColumn(
                name: "PersonInChargeId",
                table: "DefectCapturing4Points");

            migrationBuilder.DropColumn(
                name: "Timeline",
                table: "DefectCapturing4Points");

            migrationBuilder.DropColumn(
                name: "CorrectActionId",
                table: "DefectCapturing100Points");

            migrationBuilder.DropColumn(
                name: "PersonInChargeId",
                table: "DefectCapturing100Points");

            migrationBuilder.DropColumn(
                name: "Timeline",
                table: "DefectCapturing100Points");

            migrationBuilder.DropColumn(
                name: "CorrectActionId",
                table: "DefectCapturing");

            migrationBuilder.DropColumn(
                name: "PersonInChargeId",
                table: "DefectCapturing");

            migrationBuilder.DropColumn(
                name: "Timeline",
                table: "DefectCapturing");

            migrationBuilder.RenameColumn(
                name: "RootCausesName",
                table: "Measurement",
                newName: "RootCauseIds");

            migrationBuilder.RenameColumn(
                name: "RootCausesId",
                table: "Measurement",
                newName: "TimelineId");

            migrationBuilder.RenameColumn(
                name: "PersonInChargeName",
                table: "Measurement",
                newName: "PersonInChargeIds");

            migrationBuilder.RenameColumn(
                name: "CorrectActionName",
                table: "Measurement",
                newName: "CorrectActionIds");

            migrationBuilder.RenameColumn(
                name: "RootCausesName",
                table: "DefectCapturing4Points",
                newName: "RootCauseName");

            migrationBuilder.RenameColumn(
                name: "RootCausesId",
                table: "DefectCapturing4Points",
                newName: "TimelineId");

            migrationBuilder.RenameColumn(
                name: "RootCausesName",
                table: "DefectCapturing100Points",
                newName: "RootCauseName");

            migrationBuilder.RenameColumn(
                name: "RootCausesId",
                table: "DefectCapturing100Points",
                newName: "TimelineId");

            migrationBuilder.RenameColumn(
                name: "RootCausesName",
                table: "DefectCapturing",
                newName: "RootCauseName");

            migrationBuilder.RenameColumn(
                name: "RootCausesId",
                table: "DefectCapturing",
                newName: "TimelineId");

            migrationBuilder.AddColumn<string>(
                name: "CorrectActionIds",
                table: "DefectCapturing4Points",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonInChargeIds",
                table: "DefectCapturing4Points",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RootCauseIds",
                table: "DefectCapturing4Points",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CorrectActionIds",
                table: "DefectCapturing100Points",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonInChargeIds",
                table: "DefectCapturing100Points",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RootCauseIds",
                table: "DefectCapturing100Points",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CorrectActionIds",
                table: "DefectCapturing",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonInChargeIds",
                table: "DefectCapturing",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RootCauseIds",
                table: "DefectCapturing",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrectActionIds",
                table: "DefectCapturing4Points");

            migrationBuilder.DropColumn(
                name: "PersonInChargeIds",
                table: "DefectCapturing4Points");

            migrationBuilder.DropColumn(
                name: "RootCauseIds",
                table: "DefectCapturing4Points");

            migrationBuilder.DropColumn(
                name: "CorrectActionIds",
                table: "DefectCapturing100Points");

            migrationBuilder.DropColumn(
                name: "PersonInChargeIds",
                table: "DefectCapturing100Points");

            migrationBuilder.DropColumn(
                name: "RootCauseIds",
                table: "DefectCapturing100Points");

            migrationBuilder.DropColumn(
                name: "CorrectActionIds",
                table: "DefectCapturing");

            migrationBuilder.DropColumn(
                name: "PersonInChargeIds",
                table: "DefectCapturing");

            migrationBuilder.DropColumn(
                name: "RootCauseIds",
                table: "DefectCapturing");

            migrationBuilder.RenameColumn(
                name: "TimelineId",
                table: "Measurement",
                newName: "RootCausesId");

            migrationBuilder.RenameColumn(
                name: "RootCauseIds",
                table: "Measurement",
                newName: "RootCausesName");

            migrationBuilder.RenameColumn(
                name: "PersonInChargeIds",
                table: "Measurement",
                newName: "PersonInChargeName");

            migrationBuilder.RenameColumn(
                name: "CorrectActionIds",
                table: "Measurement",
                newName: "CorrectActionName");

            migrationBuilder.RenameColumn(
                name: "TimelineId",
                table: "DefectCapturing4Points",
                newName: "RootCausesId");

            migrationBuilder.RenameColumn(
                name: "RootCauseName",
                table: "DefectCapturing4Points",
                newName: "RootCausesName");

            migrationBuilder.RenameColumn(
                name: "TimelineId",
                table: "DefectCapturing100Points",
                newName: "RootCausesId");

            migrationBuilder.RenameColumn(
                name: "RootCauseName",
                table: "DefectCapturing100Points",
                newName: "RootCausesName");

            migrationBuilder.RenameColumn(
                name: "TimelineId",
                table: "DefectCapturing",
                newName: "RootCausesId");

            migrationBuilder.RenameColumn(
                name: "RootCauseName",
                table: "DefectCapturing",
                newName: "RootCausesName");

            migrationBuilder.AddColumn<int>(
                name: "CorrectActionId",
                table: "Measurement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonInChargeId",
                table: "Measurement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timeline",
                table: "Measurement",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<int>(
                name: "CorrectActionId",
                table: "DefectCapturing4Points",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonInChargeId",
                table: "DefectCapturing4Points",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timeline",
                table: "DefectCapturing4Points",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<int>(
                name: "CorrectActionId",
                table: "DefectCapturing100Points",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonInChargeId",
                table: "DefectCapturing100Points",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timeline",
                table: "DefectCapturing100Points",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())");

            migrationBuilder.AddColumn<int>(
                name: "CorrectActionId",
                table: "DefectCapturing",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonInChargeId",
                table: "DefectCapturing",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Timeline",
                table: "DefectCapturing",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())");
        }
    }
}
