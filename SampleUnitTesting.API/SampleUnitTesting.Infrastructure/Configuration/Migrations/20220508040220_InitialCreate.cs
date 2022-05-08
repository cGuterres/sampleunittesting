using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleUnitTesting.Infrastructure.Configuration.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SampleUnitTesting");

            migrationBuilder.CreateTable(
                name: "Attendants",
                schema: "SampleUnitTesting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 5, 8, 4, 2, 20, 755, DateTimeKind.Utc).AddTicks(6071)),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 5, 8, 4, 2, 20, 755, DateTimeKind.Utc).AddTicks(6196))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "SampleUnitTesting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 5, 8, 4, 2, 20, 755, DateTimeKind.Utc).AddTicks(6885)),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 5, 8, 4, 2, 20, 755, DateTimeKind.Utc).AddTicks(7008))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAttendants",
                schema: "SampleUnitTesting",
                columns: table => new
                {
                    AttendantId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAttendants", x => new { x.CustomerId, x.AttendantId });
                    table.ForeignKey(
                        name: "FK_CustomerAttendants_Attendants_AttendantId",
                        column: x => x.AttendantId,
                        principalSchema: "SampleUnitTesting",
                        principalTable: "Attendants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerAttendants_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "SampleUnitTesting",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAttendants_AttendantId",
                schema: "SampleUnitTesting",
                table: "CustomerAttendants",
                column: "AttendantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAttendants",
                schema: "SampleUnitTesting");

            migrationBuilder.DropTable(
                name: "Attendants",
                schema: "SampleUnitTesting");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "SampleUnitTesting");
        }
    }
}
