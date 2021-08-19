using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class RepairReceiptsController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Containers_Receipts_ReceiptId",
                table: "Containers");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Machines_MachineId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Containers_ReceiptId",
                table: "Containers");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "Containers");

            migrationBuilder.RenameColumn(
                name: "MachineId",
                table: "Receipts",
                newName: "ContainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_MachineId",
                table: "Receipts",
                newName: "IX_Receipts_ContainerId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Money",
                table: "Users",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Money", "Name" },
                values: new object[] { "IEUqJGtlFGBjefSpvP5xug==", 0m, "IEUqJGtlFGBjefSpvP5xug==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Containers_ContainerId",
                table: "Receipts",
                column: "ContainerId",
                principalTable: "Containers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Containers_ContainerId",
                table: "Receipts");

            migrationBuilder.RenameColumn(
                name: "ContainerId",
                table: "Receipts",
                newName: "MachineId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_ContainerId",
                table: "Receipts",
                newName: "IX_Receipts_MachineId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Money",
                table: "Users",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "Containers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Money", "Name" },
                values: new object[] { "B+Gr3a0vFHVijzv0Pu9vXw==", null, "B+Gr3a0vFHVijzv0Pu9vXw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Containers_ReceiptId",
                table: "Containers",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Containers_Receipts_ReceiptId",
                table: "Containers",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Machines_MachineId",
                table: "Receipts",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
