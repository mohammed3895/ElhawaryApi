using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElhawaryApi.Migrations
{
    /// <inheritdoc />
    public partial class relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDepartment_MaintenanceStatus_StatusId",
                table: "MaintenanceDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDepartment_MaintenanceTypes_MaintenanceStatuseId",
                table: "MaintenanceDepartment");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceDepartment_MaintenanceStatuseId",
                table: "MaintenanceDepartment");

            migrationBuilder.DropColumn(
                name: "MaintenanceStatuseId",
                table: "MaintenanceDepartment");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceId",
                table: "MaintenanceStatus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "MaintenanceDepartment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDepartment_MaintenanceTypeId",
                table: "MaintenanceDepartment",
                column: "MaintenanceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceDepartment_MaintenanceStatus_StatusId",
                table: "MaintenanceDepartment",
                column: "StatusId",
                principalTable: "MaintenanceStatus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceDepartment_MaintenanceTypes_MaintenanceTypeId",
                table: "MaintenanceDepartment",
                column: "MaintenanceTypeId",
                principalTable: "MaintenanceTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDepartment_MaintenanceStatus_StatusId",
                table: "MaintenanceDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceDepartment_MaintenanceTypes_MaintenanceTypeId",
                table: "MaintenanceDepartment");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceDepartment_MaintenanceTypeId",
                table: "MaintenanceDepartment");

            migrationBuilder.DropColumn(
                name: "MaintenanceTypeId",
                table: "MaintenanceDepartment");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceId",
                table: "MaintenanceStatus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "MaintenanceDepartment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceId",
                table: "MaintenanceDepartment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "FK_MaintenanceDepartment_MaintenanceStatus_StatusId",
                table: "MaintenanceDepartment",
                column: "StatusId",
                principalTable: "MaintenanceStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceDepartment_MaintenanceTypes_MaintenanceStatuseId",
                table: "MaintenanceDepartment",
                column: "MaintenanceStatuseId",
                principalTable: "MaintenanceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
