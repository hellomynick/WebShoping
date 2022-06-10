using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDataLayer.Migrations
{
    public partial class NewDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalogBrand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogBrand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CatalogItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    MaxStockThreshold = table.Column<int>(type: "int", nullable: true),
                    AvailableStock = table.Column<int>(type: "int", nullable: false),
                    RestockThreshold = table.Column<int>(type: "int", nullable: true),
                    CatalogTypeId = table.Column<int>(type: "int", nullable: true),
                    CatalogBrandId = table.Column<int>(type: "int", nullable: true),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CatalogItem_CatalogBrand_CatalogBrandId",
                        column: x => x.CatalogBrandId,
                        principalTable: "CatalogBrand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CatalogItem_CatalogType_CatalogTypeId",
                        column: x => x.CatalogTypeId,
                        principalTable: "CatalogType",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "CatalogBrand",
                columns: new[] { "Id", "BrandName" },
                values: new object[,]
                {
                    { 1, "McDonald's" },
                    { 2, "KFC" },
                    { 3, "PaPaChicken" },
                    { 4, "Merino" }
                });

            migrationBuilder.InsertData(
                table: "CatalogType",
                columns: new[] { "Id", "TypeName" },
                values: new object[,]
                {
                    { 1, "Food" },
                    { 2, "Drink" },
                    { 3, "Ice Creame" }
                });

            migrationBuilder.InsertData(
                table: "CatalogItem",
                columns: new[] { "Id", "AvailableStock", "CatalogBrandId", "CatalogTypeId", "CreateOn", "Description", "Discount", "MaxStockThreshold", "Price", "PriceDiscount", "ProductName", "RestockThreshold", "Stock", "UpdateOn" },
                values: new object[] { 1, 100, 2, 1, new DateTime(2022, 6, 10, 13, 23, 44, 722, DateTimeKind.Local).AddTicks(2590), "Combo for 2 people", 0m, 100, 20m, 20m, "Combo Chicken KFC", null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItem_CatalogBrandId",
                table: "CatalogItem",
                column: "CatalogBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogItem_CatalogTypeId",
                table: "CatalogItem",
                column: "CatalogTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogItem");

            migrationBuilder.DropTable(
                name: "CatalogBrand");

            migrationBuilder.DropTable(
                name: "CatalogType");
        }
    }
}
