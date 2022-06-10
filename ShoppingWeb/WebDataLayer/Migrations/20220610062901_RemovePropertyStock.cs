using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDataLayer.Migrations
{
    public partial class RemovePropertyStock : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stock",
                table: "CatalogItem");

            migrationBuilder.UpdateData(
                table: "CatalogItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateOn",
                value: new DateTime(2022, 6, 10, 13, 29, 1, 339, DateTimeKind.Local).AddTicks(4309));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "CatalogItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "CatalogItem",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateOn",
                value: new DateTime(2022, 6, 10, 13, 23, 44, 722, DateTimeKind.Local).AddTicks(2590));
        }
    }
}
