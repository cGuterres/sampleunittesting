using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleUnitTesting.Infrastructure.Configuration.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 5, 8, 5, 58, 31, 942, DateTimeKind.Utc).AddTicks(2732)),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 5, 8, 5, 58, 31, 942, DateTimeKind.Utc).AddTicks(2899))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 5, 8, 5, 58, 31, 942, DateTimeKind.Utc).AddTicks(3617)),
                    UpdatedOn = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2022, 5, 8, 5, 58, 31, 942, DateTimeKind.Utc).AddTicks(3746))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendantCustomer",
                columns: table => new
                {
                    AttendantsId = table.Column<int>(type: "int", nullable: false),
                    CustomersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendantCustomer", x => new { x.AttendantsId, x.CustomersId });
                    table.ForeignKey(
                        name: "FK_AttendantCustomer_Attendants_AttendantsId",
                        column: x => x.AttendantsId,
                        principalTable: "Attendants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendantCustomer_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendantCustomer_CustomersId",
                table: "AttendantCustomer",
                column: "CustomersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendantCustomer");

            migrationBuilder.DropTable(
                name: "Attendants");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
