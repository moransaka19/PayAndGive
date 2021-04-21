using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddMachine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Eats",
                columns: new[] { "Id", "Name", "Price", "ReceiptId", "TimeExpiredMin" },
                values: new object[] { 2, "Eat2", 2, null, 5 });

            migrationBuilder.InsertData(
                table: "Eats",
                columns: new[] { "Id", "Name", "Price", "ReceiptId", "TimeExpiredMin" },
                values: new object[] { 1, "Eat1", 10, null, 10 });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "State" },
                values: new object[] { 1, "test" });

            migrationBuilder.InsertData(
                table: "MContainers",
                columns: new[] { "Id", "EatId", "FixedLoadingTime", "IsEmpty", "MachineId" },
                values: new object[] { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1 });

            migrationBuilder.InsertData(
                table: "MContainers",
                columns: new[] { "Id", "EatId", "FixedLoadingTime", "IsEmpty", "MachineId" },
                values: new object[] { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MContainers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MContainers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Eats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Eats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
