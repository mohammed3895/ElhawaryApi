using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElhawaryApi.Migrations
{
    /// <inheritdoc />
    public partial class relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceStatus_MaintenanceStatusTypes_StatusTypeId",
                table: "MaintenanceStatus");

            migrationBuilder.DropColumn(
                name: "MaintenanceStatuseId",
                table: "MaintenanceStatusTypes");

            migrationBuilder.DropColumn(
                name: "MaintenanceStatusType",
                table: "MaintenanceStatus");

            migrationBuilder.RenameColumn(
                name: "StatusTypeId",
                table: "MaintenanceStatus",
                newName: "MaintenanceStatusTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceStatus_StatusTypeId",
                table: "MaintenanceStatus",
                newName: "IX_MaintenanceStatus_MaintenanceStatusTypeId");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceStatuseId",
                table: "MaintenanceDepartment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDepartment_MaintenanceStatuseId",
                table: "MaintenanceDepartment",
                column: "MaintenanceStatuseId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceDepartment_MaintenanceTypes_MaintenanceStatuseId",
                table: "MaintenanceDepartment",
                column: "MaintenanceStatuseId",
                principalTable: "MaintenanceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceStatus_MaintenanceStatusTypes_MaintenanceStatusTypeId",
                table: "MaintenanceStatus",
                column: "MaintenanceStatusTypeId",
                principalTable: "MaintenanceStatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDepartment_MaintenanceTypes_MaintenanceStatuseId",
                table: "MaintenanceDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceStatus_MaintenanceStatusTypes_MaintenanceStatusTypeId",
                table: "MaintenanceStatus");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceDepartment_MaintenanceStatuseId",
                table: "MaintenanceDepartment");

            migrationBuilder.DropColumn(
                name: "MaintenanceStatuseId",
                table: "MaintenanceDepartment");

            migrationBuilder.RenameColumn(
                name: "MaintenanceStatusTypeId",
                table: "MaintenanceStatus",
                newName: "StatusTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintenanceStatus_MaintenanceStatusTypeId",
                table: "MaintenanceStatus",
                newName: "IX_MaintenanceStatus_StatusTypeId");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceStatuseId",
                table: "MaintenanceStatusTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceStatusType",
                table: "MaintenanceStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "MaintenanceStatusTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaintenanceStatuseId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MaintenanceStatusTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaintenanceStatuseId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "MaintenanceStatusTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "MaintenanceStatuseId",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceStatus_MaintenanceStatusTypes_StatusTypeId",
                table: "MaintenanceStatus",
                column: "StatusTypeId",
                principalTable: "MaintenanceStatusTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
