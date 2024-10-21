using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElhawaryApi.Migrations
{
    /// <inheritdoc />
    public partial class rel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaintenanceStatuseId",
                table: "MaintenanceStatusTypes");

            migrationBuilder.DropColumn(
                name: "MaintenanceStatusType",
                table: "MaintenanceStatus");
        }
    }
}
