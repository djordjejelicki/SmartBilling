using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SB.Data.Migrations
{
    /// <inheritdoc />
    public partial class adding_Customer_inDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                column: "Id",
                values: new object[]
                {
                    new Guid("6b29fc40-68a2-4b80-91b4-914a5f2b7f04"),
                    new Guid("a5d8f1ea-66b9-4f4e-bc9b-8f6395f5d2f2"),
                    new Guid("c7e04f65-3b97-4b11-99b8-09d56dc8d25a"),
                    new Guid("e3f4a9b2-2d78-4db8-8bfc-cd08c2a7a9f3"),
                    new Guid("f3b1d4a8-7c2d-4f84-81df-2a5e3b671e1b")
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("6b29fc40-68a2-4b80-91b4-914a5f2b7f04"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("a5d8f1ea-66b9-4f4e-bc9b-8f6395f5d2f2"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("c7e04f65-3b97-4b11-99b8-09d56dc8d25a"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("e3f4a9b2-2d78-4db8-8bfc-cd08c2a7a9f3"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("f3b1d4a8-7c2d-4f84-81df-2a5e3b671e1b"));
        }
    }
}
