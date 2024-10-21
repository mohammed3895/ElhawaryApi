using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElhawaryApi.Migrations
{
    /// <inheritdoc />
    public partial class refactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceDepartment_StatusId",
                table: "MaintenanceDepartment");

            migrationBuilder.DropColumn(
                name: "MaintenanceTypeId",
                table: "MaintenanceDepartment");

            migrationBuilder.DropColumn(
                name: "StatusId",
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

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleveredAt",
                table: "MaintenanceDepartment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "MaintenanceType",
                table: "MaintenanceDepartment",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "MaintenanceDepartment",
                type: "nvarchar(max)",
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
                name: "DeleveredAt",
                table: "MaintenanceDepartment");

            migrationBuilder.DropColumn(
                name: "MaintenanceType",
                table: "MaintenanceDepartment");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "MaintenanceDepartment");

            migrationBuilder.AlterColumn<int>(
                name: "MaintenanceId",
                table: "MaintenanceStatus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceTypeId",
                table: "MaintenanceDepartment",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "MaintenanceDepartment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDepartment_MaintenanceTypeId",
                table: "MaintenanceDepartment",
                column: "MaintenanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDepartment_StatusId",
                table: "MaintenanceDepartment",
                column: "StatusId");

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
    }
}
