using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElhawaryApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDepartment_MaintenanceStatus_MaintenanceId",
                table: "MaintenanceDepartment");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceDepartment_MaintenanceId",
                table: "MaintenanceDepartment");

            migrationBuilder.DropColumn(
                name: "MaintenanceTypeId",
                table: "MaintenanceDepartment");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceId",
                table: "MaintenanceDepartment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceId",
                table: "MaintenanceDepartment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceTypeId",
                table: "MaintenanceDepartment",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
