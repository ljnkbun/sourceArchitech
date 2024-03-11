using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRejectReason : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AnalysisDate",
                table: "WeavingIED",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AnalysisUser",
                table: "WeavingIED",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "WeavingIED",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "WeavingIED",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "SewingIED",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AnalysisDate",
                table: "KnittingIED",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AnalysisUser",
                table: "KnittingIED",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "KnittingIED",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "KnittingIED",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "KnittingIED",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WFXArticleId",
                table: "DyeingIED",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "AnalysisDate",
                table: "DyeingIED",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AnalysisUser",
                table: "DyeingIED",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "DyeingIED",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RejectReason",
                table: "DyeingIED",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnalysisDate",
                table: "WeavingIED");

            migrationBuilder.DropColumn(
                name: "AnalysisUser",
                table: "WeavingIED");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "WeavingIED");

            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "WeavingIED");

            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "SewingIED");

            migrationBuilder.DropColumn(
                name: "AnalysisDate",
                table: "KnittingIED");

            migrationBuilder.DropColumn(
                name: "AnalysisUser",
                table: "KnittingIED");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "KnittingIED");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "KnittingIED");

            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "KnittingIED");

            migrationBuilder.DropColumn(
                name: "AnalysisDate",
                table: "DyeingIED");

            migrationBuilder.DropColumn(
                name: "AnalysisUser",
                table: "DyeingIED");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "DyeingIED");

            migrationBuilder.DropColumn(
                name: "RejectReason",
                table: "DyeingIED");

            migrationBuilder.AlterColumn<int>(
                name: "WFXArticleId",
                table: "DyeingIED",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
