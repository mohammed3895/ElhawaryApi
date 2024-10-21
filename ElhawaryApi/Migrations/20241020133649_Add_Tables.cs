using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ElhawaryApi.Migrations
{
    /// <inheritdoc />
    public partial class Add_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFixed",
                table: "MaintenanceDepartment");

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceTypeId",
                table: "MaintenanceDepartment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "MaintenanceDepartment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AccessoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceStatusTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceStatusTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    TechnicanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceStatus_MaintenanceStatusTypes_StatusId",
                        column: x => x.StatusId,
                        principalTable: "MaintenanceStatusTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceStatus_Technicans_TechnicanId",
                        column: x => x.TechnicanId,
                        principalTable: "Technicans",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AccessoryTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Battery" },
                    { 2, "Cover" },
                    { 3, "Screen Protector" },
                    { 4, "Data Transfer Kit" },
                    { 5, "Charge" },
                    { 6, "Other" }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceStatusTypes",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 1, "InProgress" },
                    { 2, "Done" },
                    { 3, "Refused" }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, (byte)0 },
                    { 2, (byte)1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDepartment_MaintenanceTypeId",
                table: "MaintenanceDepartment",
                column: "MaintenanceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceDepartment_StatusId",
                table: "MaintenanceDepartment",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceStatus_StatusId",
                table: "MaintenanceStatus",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceStatus_TechnicanId",
                table: "MaintenanceStatus",
                column: "TechnicanId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceDepartment_MaintenanceStatus_StatusId",
                table: "MaintenanceDepartment",
                column: "StatusId",
                principalTable: "MaintenanceStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceDepartment_MaintenanceTypes_MaintenanceTypeId",
                table: "MaintenanceDepartment",
                column: "MaintenanceTypeId",
                principalTable: "MaintenanceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.DropTable(
                name: "AccessoryTypes");

            migrationBuilder.DropTable(
                name: "MaintenanceStatus");

            migrationBuilder.DropTable(
                name: "MaintenanceTypes");

            migrationBuilder.DropTable(
                name: "MaintenanceStatusTypes");

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

            migrationBuilder.AddColumn<bool>(
                name: "IsFixed",
                table: "MaintenanceDepartment",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
