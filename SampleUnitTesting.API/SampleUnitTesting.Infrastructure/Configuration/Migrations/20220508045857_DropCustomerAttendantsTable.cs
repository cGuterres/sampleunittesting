using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleUnitTesting.Infrastructure.Configuration.Migrations
{
    public partial class DropCustomerAttendantsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerAttendants",
                schema: "SampleUnitTesting");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "SampleUnitTesting",
                table: "Customers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 4, 58, 57, 52, DateTimeKind.Utc).AddTicks(7779),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 5, 8, 4, 2, 20, 755, DateTimeKind.Utc).AddTicks(7008));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "SampleUnitTesting",
                table: "Customers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 4, 58, 57, 52, DateTimeKind.Utc).AddTicks(7620),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 5, 8, 4, 2, 20, 755, DateTimeKind.Utc).AddTicks(6885));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "SampleUnitTesting",
                table: "Attendants",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 4, 58, 57, 52, DateTimeKind.Utc).AddTicks(6929),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 5, 8, 4, 2, 20, 755, DateTimeKind.Utc).AddTicks(6196));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "SampleUnitTesting",
                table: "Attendants",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 4, 58, 57, 52, DateTimeKind.Utc).AddTicks(6800),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 5, 8, 4, 2, 20, 755, DateTimeKind.Utc).AddTicks(6071));

            migrationBuilder.CreateTable(
                name: "AttendantCustomer",
                schema: "SampleUnitTesting",
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
                        principalSchema: "SampleUnitTesting",
                        principalTable: "Attendants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendantCustomer_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalSchema: "SampleUnitTesting",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendantCustomer_CustomersId",
                schema: "SampleUnitTesting",
                table: "AttendantCustomer",
                column: "CustomersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendantCustomer",
                schema: "SampleUnitTesting");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "SampleUnitTesting",
                table: "Customers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 4, 2, 20, 755, DateTimeKind.Utc).AddTicks(7008),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 5, 8, 4, 58, 57, 52, DateTimeKind.Utc).AddTicks(7779));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "SampleUnitTesting",
                table: "Customers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 4, 2, 20, 755, DateTimeKind.Utc).AddTicks(6885),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 5, 8, 4, 58, 57, 52, DateTimeKind.Utc).AddTicks(7620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "SampleUnitTesting",
                table: "Attendants",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 4, 2, 20, 755, DateTimeKind.Utc).AddTicks(6196),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 5, 8, 4, 58, 57, 52, DateTimeKind.Utc).AddTicks(6929));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "SampleUnitTesting",
                table: "Attendants",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 4, 2, 20, 755, DateTimeKind.Utc).AddTicks(6071),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 5, 8, 4, 58, 57, 52, DateTimeKind.Utc).AddTicks(6800));

            migrationBuilder.CreateTable(
                name: "CustomerAttendants",
                schema: "SampleUnitTesting",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    AttendantId = table.Column<int>(type: "int", nullable: false)
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
    }
}
