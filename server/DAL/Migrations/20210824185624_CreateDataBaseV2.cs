using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class CreateDataBaseV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eats_Receipts_ReceiptId",
                table: "Eats");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Machines_MachineId",
                table: "Receipts");

            migrationBuilder.DropTable(
                name: "MContainers");

            migrationBuilder.DropIndex(
                name: "IX_Eats_ReceiptId",
                table: "Eats");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "Eats");

            migrationBuilder.RenameColumn(
                name: "MachineId",
                table: "Receipts",
                newName: "ContainerId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_MachineId",
                table: "Receipts",
                newName: "IX_Receipts_ContainerId");

            migrationBuilder.RenameColumn(
                name: "TimeExpiredMin",
                table: "Eats",
                newName: "TimeExpired");

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeCreated",
                table: "Receipts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Machines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                table: "Machines",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsBought = table.Column<bool>(type: "bit", nullable: false),
                    EatId = table.Column<int>(type: "int", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Preorders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimePreorder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preorders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preorders_Eats_EatId",
                        column: x => x.EatId,
                        principalTable: "Eats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Preorders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Lang = table.Column<double>(type: "float", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BonusEats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EatId = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonusEats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonusEats_Eats_EatId",
                        column: x => x.EatId,
                        principalTable: "Eats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BonusEats_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recalls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RestaurantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recalls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recalls_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recalls_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Containers",
                columns: new[] { "Id", "CreatedTime", "EatId", "IsBought", "MachineId" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, false, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 1 }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Country", "Lang", "Lat", "Name" },
                values: new object[] { 1, "Ukraine", 131.04400000000001, -25.363, "Test" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DOB", "Login", "Money", "Name", "Password", "RoleId" },
                values: new object[] { new DateTime(2021, 8, 24, 21, 56, 23, 550, DateTimeKind.Local).AddTicks(8368), "IEUqJGtlFGBjefSpvP5xug==", 0m, "IEUqJGtlFGBjefSpvP5xug==", "ADGjgVNFqMy8qsaVNwuhPyW96mam0F6+zuAgkLjiNTc7YFfz4zoo4YWk7qnFTCciPg==", 1 });

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "RestaurantId", "Value" },
                values: new object[] { 1, 20 });

            migrationBuilder.CreateIndex(
                name: "IX_Machines_RestaurantId",
                table: "Machines",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_BonusEats_EatId",
                table: "BonusEats",
                column: "EatId");

            migrationBuilder.CreateIndex(
                name: "IX_BonusEats_RestaurantId",
                table: "BonusEats",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_EatId",
                table: "Containers",
                column: "EatId");

            migrationBuilder.CreateIndex(
                name: "IX_Containers_MachineId",
                table: "Containers",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Preorders_EatId",
                table: "Preorders",
                column: "EatId");

            migrationBuilder.CreateIndex(
                name: "IX_Preorders_UserId",
                table: "Preorders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recalls_RestaurantId",
                table: "Recalls",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Recalls_UserId",
                table: "Recalls",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Restaurants_RestaurantId",
                table: "Machines",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Machines_Restaurants_RestaurantId",
                table: "Machines");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Containers_ContainerId",
                table: "Receipts");

            migrationBuilder.DropTable(
                name: "BonusEats");

            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropTable(
                name: "Preorders");

            migrationBuilder.DropTable(
                name: "Recalls");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Machines_RestaurantId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateTimeCreated",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "Machines");

            migrationBuilder.RenameColumn(
                name: "ContainerId",
                table: "Receipts",
                newName: "MachineId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_ContainerId",
                table: "Receipts",
                newName: "IX_Receipts_MachineId");

            migrationBuilder.RenameColumn(
                name: "TimeExpired",
                table: "Eats",
                newName: "TimeExpiredMin");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Machines",
                type: "nvarchar(max)",
                nullable: true);

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
                values: new object[,]
                {
                    { 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1 },
                    { 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, 1 }
                });

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "State",
                value: "test");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Login", "Money", "Name", "Password", "RoleId" },
                values: new object[] { "Test", 100m, "Test", "", 2 });

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
