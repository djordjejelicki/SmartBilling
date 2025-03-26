using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SB.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingvaluesinRolesEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Name", "Surname" },
                values: new object[,]
                {
                    { new Guid("20b5d218-e87b-42cc-9568-ef69ab1b2945"), "Djordje", "Jelicki" },
                    { new Guid("2b0bcf24-e190-403c-af44-c47cd4a9171d"), "Stanimir", "Blazin" },
                    { new Guid("9ec8a24f-2002-482c-8d8a-12487a87ac6f"), "Igor", "Skrofanov" },
                    { new Guid("bbe98bab-c759-446b-a16c-39442e9a0e88"), "Luka", "Miladinovc" },
                    { new Guid("fc8d4d36-6d32-4455-81ce-bca99786d515"), "Matija", "Vrebalov" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[,]
                {
                    { new Guid("2fa92b0d-9373-48e7-a28a-21af57c4b681"), "Cash register manager" },
                    { new Guid("6305cb2f-0746-4bbb-90c5-d60c2f88da6f"), "Security officer" },
                    { new Guid("9fb572cd-01e2-41b7-b4d9-4efaf06d9449"), "Cash register officer" },
                    { new Guid("aff40a81-7209-40ed-a5a2-15eb57acd250"), "Exchange officer" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("20b5d218-e87b-42cc-9568-ef69ab1b2945"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("2b0bcf24-e190-403c-af44-c47cd4a9171d"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("9ec8a24f-2002-482c-8d8a-12487a87ac6f"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("bbe98bab-c759-446b-a16c-39442e9a0e88"));

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: new Guid("fc8d4d36-6d32-4455-81ce-bca99786d515"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2fa92b0d-9373-48e7-a28a-21af57c4b681"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("6305cb2f-0746-4bbb-90c5-d60c2f88da6f"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("9fb572cd-01e2-41b7-b4d9-4efaf06d9449"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("aff40a81-7209-40ed-a5a2-15eb57acd250"));
        }
    }
}
