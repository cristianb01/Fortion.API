using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fortion.API.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WarehouseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Width = table.Column<double>(type: "double", nullable: false),
                    Length = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseTypes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WarehouseTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_warehouses_WarehouseTypes_WarehouseTypeId",
                        column: x => x.WarehouseTypeId,
                        principalTable: "WarehouseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "WarehouseTypes",
                columns: new[] { "Id", "Length", "Width" },
                values: new object[,]
                {
                    { 1, 4.0, 4.0 },
                    { 2, 1.0, 1.0 },
                    { 3, 2.0, 2.0 },
                    { 4, 3.0, 3.0 },
                    { 5, 5.0, 5.0 }
                });

            migrationBuilder.InsertData(
                table: "warehouses",
                columns: new[] { "Id", "Description", "ImageUrl", "WarehouseTypeId" },
                values: new object[] { 1, "Beautiful wharehouse", "https://www.prologis.com/sites/corporate/files/images/2019/09/large-ontario_dc9_3_11.jpg", 1 });

            migrationBuilder.InsertData(
                table: "warehouses",
                columns: new[] { "Id", "Description", "ImageUrl", "WarehouseTypeId" },
                values: new object[] { 3, "Beautiful wharehouse", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRFUF7sF6E0m-8enGRPS0RHn-FbCraPQLkeeg&usqp=CAU", 3 });

            migrationBuilder.InsertData(
                table: "warehouses",
                columns: new[] { "Id", "Description", "ImageUrl", "WarehouseTypeId" },
                values: new object[] { 2, "Another beautiful wharehouse", "https://www.americanwarehouses.com/hubfs/AmericanWarehouses_Blog_TheBestApproachToLeasingWarehouseSpace.jpg", 4 });

            migrationBuilder.CreateIndex(
                name: "IX_warehouses_WarehouseTypeId",
                table: "warehouses",
                column: "WarehouseTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "warehouses");

            migrationBuilder.DropTable(
                name: "WarehouseTypes");
        }
    }
}
