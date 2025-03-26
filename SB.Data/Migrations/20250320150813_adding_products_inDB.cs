using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SB.Data.Migrations
{
    /// <inheritdoc />
    public partial class adding_products_inDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("113e7663-2cac-45c6-b349-b6189d9c3f4d"), "Modern bycycle for ride", "Bicycle", 250.0 },
                    { new Guid("1a24b23a-4e82-4413-af4d-fcd45aecb01a"), "Working desk", "Desk", 190.0 },
                    { new Guid("21bbe837-b363-46c0-b3ad-41a5d4b7758a"), "Office chair", "Chair", 120.0 },
                    { new Guid("7d3c4e45-6103-4271-8438-a445220137e3"), "Apple smart phone", "Iphone 14", 750.0 },
                    { new Guid("aefcc042-ece1-472c-96be-26211771a5e5"), "Modern House Lamp", "Lamp", 60.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("113e7663-2cac-45c6-b349-b6189d9c3f4d"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("1a24b23a-4e82-4413-af4d-fcd45aecb01a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("21bbe837-b363-46c0-b3ad-41a5d4b7758a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7d3c4e45-6103-4271-8438-a445220137e3"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("aefcc042-ece1-472c-96be-26211771a5e5"));
        }
    }
}
