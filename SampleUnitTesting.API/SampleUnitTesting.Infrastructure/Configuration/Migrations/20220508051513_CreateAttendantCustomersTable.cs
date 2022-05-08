using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SampleUnitTesting.Infrastructure.Configuration.Migrations
{
    public partial class CreateAttendantCustomersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "SampleUnitTesting",
                table: "Customers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 5, 15, 13, 666, DateTimeKind.Utc).AddTicks(5280),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 5, 8, 4, 58, 57, 52, DateTimeKind.Utc).AddTicks(7779));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "SampleUnitTesting",
                table: "Customers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 5, 15, 13, 666, DateTimeKind.Utc).AddTicks(5173),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 5, 8, 4, 58, 57, 52, DateTimeKind.Utc).AddTicks(7620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "SampleUnitTesting",
                table: "Attendants",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 5, 15, 13, 666, DateTimeKind.Utc).AddTicks(4525),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 5, 8, 4, 58, 57, 52, DateTimeKind.Utc).AddTicks(6929));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "SampleUnitTesting",
                table: "Attendants",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 5, 15, 13, 666, DateTimeKind.Utc).AddTicks(4408),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 5, 8, 4, 58, 57, 52, DateTimeKind.Utc).AddTicks(6800));

            migrationBuilder.CreateTable(
                name: "AttendantCustomer",
                columns: table => new
                {
                    AttendantId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendantCustomer", x => new { x.AttendantId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_AttendantCustomer_Attendants_AttendantId",
                        column: x => x.AttendantId,
                        principalSchema: "SampleUnitTesting",
                        principalTable: "Attendants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendantCustomer_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "SampleUnitTesting",
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttendantCustomer_CustomerId",
                table: "AttendantCustomer",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttendantCustomer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "SampleUnitTesting",
                table: "Customers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 4, 58, 57, 52, DateTimeKind.Utc).AddTicks(7779),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 5, 8, 5, 15, 13, 666, DateTimeKind.Utc).AddTicks(5280));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "SampleUnitTesting",
                table: "Customers",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 4, 58, 57, 52, DateTimeKind.Utc).AddTicks(7620),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 5, 8, 5, 15, 13, 666, DateTimeKind.Utc).AddTicks(5173));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                schema: "SampleUnitTesting",
                table: "Attendants",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 4, 58, 57, 52, DateTimeKind.Utc).AddTicks(6929),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 5, 8, 5, 15, 13, 666, DateTimeKind.Utc).AddTicks(4525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "SampleUnitTesting",
                table: "Attendants",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 8, 4, 58, 57, 52, DateTimeKind.Utc).AddTicks(6800),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2022, 5, 8, 5, 15, 13, 666, DateTimeKind.Utc).AddTicks(4408));
        }
    }
}
