using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shopfloor.IED.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRelationshipDyeingProcessChemical : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DyeingProcessChemical_DyeingRouting_DyeingRoutingId",
                table: "DyeingProcessChemical");

            migrationBuilder.DropIndex(
                name: "IX_DyeingProcessChemical_DyeingRoutingId",
                table: "DyeingProcessChemical");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DyeingProcessChemical_DyeingRoutingId",
                table: "DyeingProcessChemical",
                column: "DyeingRoutingId");

            migrationBuilder.AddForeignKey(
                name: "FK_DyeingProcessChemical_DyeingRouting_DyeingRoutingId",
                table: "DyeingProcessChemical",
                column: "DyeingRoutingId",
                principalTable: "DyeingRouting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
