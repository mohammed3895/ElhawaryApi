using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElhawaryApi.Migrations
{
    /// <inheritdoc />
    public partial class Add_Tables1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceStatus_MaintenanceStatusTypes_StatusId",
                table: "MaintenanceStatus");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "MaintenanceStatus",
                newName: "StatusTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceStatus_StatusId",
                table: "MaintenanceStatus",
                newName: "IX_MaintenanceStatus_StatusTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceStatus_MaintenanceStatusTypes_StatusTypeId",
                table: "MaintenanceStatus",
                column: "StatusTypeId",
                principalTable: "MaintenanceStatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceStatus_MaintenanceStatusTypes_StatusTypeId",
                table: "MaintenanceStatus");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "MaintenanceStatus",
                newName: "StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceStatus_StatusTypeId",
                table: "MaintenanceStatus",
                newName: "IX_MaintenanceStatus_StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceStatus_MaintenanceStatusTypes_StatusId",
                table: "MaintenanceStatus",
                column: "StatusId",
                principalTable: "MaintenanceStatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
