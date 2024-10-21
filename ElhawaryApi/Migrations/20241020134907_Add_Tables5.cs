using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElhawaryApi.Migrations
{
    /// <inheritdoc />
    public partial class Add_Tables5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaintenanceId",
                table: "MaintenanceStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceId",
                table: "MaintenanceDepartment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDepartment_MaintenanceId",
                table: "MaintenanceDepartment",
                column: "MaintenanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceDepartment_MaintenanceStatus_MaintenanceId",
                table: "MaintenanceDepartment",
                column: "MaintenanceId",
                principalTable: "MaintenanceStatus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDepartment_MaintenanceStatus_MaintenanceId",
                table: "MaintenanceDepartment");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceDepartment_MaintenanceId",
                table: "MaintenanceDepartment");

            migrationBuilder.DropColumn(
                name: "MaintenanceId",
                table: "MaintenanceStatus");

            migrationBuilder.DropColumn(
                name: "MaintenanceId",
                table: "MaintenanceDepartment");
        }
    }
}
