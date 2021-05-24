using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddIsDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eats_Receipts_ReceiptId",
                table: "Eats");

            migrationBuilder.DropTable(
                name: "MContainers");

            migrationBuilder.DropIndex(
                name: "IX_Eats_ReceiptId",
                table: "Eats");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "Eats");

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FixedLoadingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    EatId = table.Column<int>(type: "int", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false),
                    ReceiptId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Containers_Eats_EatId",
                        column: x => x.EatId,
                        principalTable: "Eats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Containers_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Containers_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Containers",
                columns: new[] { "Id", "EatId", "FixedLoadingTime", "IsDeleted", "MachineId", "ReceiptId" },
                values: new object[] { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null });

            migrationBuilder.InsertData(
                table: "Containers",
                columns: new[] { "Id", "EatId", "FixedLoadingTime", "IsDeleted", "MachineId", "ReceiptId" },
                values: new object[] { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "ADGjgVNFqMy8qsaVNwuhPyW96mam0F6+zuAgkLjiNTc7YFfz4zoo4YWk7qnFTCciPg==");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_EatId",
                table: "Containers",
                column: "EatId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_MachineId",
                table: "Containers",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_ReceiptId",
                table: "Containers",
                column: "ReceiptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "Eats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MContainers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EatId = table.Column<int>(type: "int", nullable: false),
                    FixedLoadingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsEmpty = table.Column<bool>(type: "bit", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MContainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MContainers_Eats_EatId",
                        column: x => x.EatId,
                        principalTable: "Eats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MContainers_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MContainers",
                columns: new[] { "Id", "EatId", "FixedLoadingTime", "IsEmpty", "MachineId" },
                values: new object[] { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1 });

            migrationBuilder.InsertData(
                table: "MContainers",
                columns: new[] { "Id", "EatId", "FixedLoadingTime", "IsEmpty", "MachineId" },
                values: new object[] { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "ACyBeIkSb0oWhRvS0Wd3lVwbcRi+OO8jO968vxtmub0WYRDUA6CuUxB4PStpoO5+TA==");

            migrationBuilder.CreateIndex(
                name: "IX_Eats_ReceiptId",
                table: "Eats",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_MContainers_EatId",
                table: "MContainers",
                column: "EatId");

            migrationBuilder.CreateIndex(
                name: "IX_MContainers_MachineId",
                table: "MContainers",
                column: "MachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eats_Receipts_ReceiptId",
                table: "Eats",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
