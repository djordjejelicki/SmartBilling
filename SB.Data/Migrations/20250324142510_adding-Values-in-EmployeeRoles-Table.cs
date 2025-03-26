using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SB.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingValuesinEmployeeRolesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "EmployeeId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("20b5d218-e87b-42cc-9568-ef69ab1b2945"), new Guid("9fb572cd-01e2-41b7-b4d9-4efaf06d9449") },
                    { new Guid("2b0bcf24-e190-403c-af44-c47cd4a9171d"), new Guid("2fa92b0d-9373-48e7-a28a-21af57c4b681") },
                    { new Guid("9ec8a24f-2002-482c-8d8a-12487a87ac6f"), new Guid("9fb572cd-01e2-41b7-b4d9-4efaf06d9449") },
                    { new Guid("bbe98bab-c759-446b-a16c-39442e9a0e88"), new Guid("aff40a81-7209-40ed-a5a2-15eb57acd250") },
                    { new Guid("fc8d4d36-6d32-4455-81ce-bca99786d515"), new Guid("6305cb2f-0746-4bbb-90c5-d60c2f88da6f") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumns: new[] { "EmployeeId", "RoleId" },
                keyValues: new object[] { new Guid("20b5d218-e87b-42cc-9568-ef69ab1b2945"), new Guid("9fb572cd-01e2-41b7-b4d9-4efaf06d9449") });

            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumns: new[] { "EmployeeId", "RoleId" },
                keyValues: new object[] { new Guid("2b0bcf24-e190-403c-af44-c47cd4a9171d"), new Guid("2fa92b0d-9373-48e7-a28a-21af57c4b681") });

            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumns: new[] { "EmployeeId", "RoleId" },
                keyValues: new object[] { new Guid("9ec8a24f-2002-482c-8d8a-12487a87ac6f"), new Guid("9fb572cd-01e2-41b7-b4d9-4efaf06d9449") });

            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumns: new[] { "EmployeeId", "RoleId" },
                keyValues: new object[] { new Guid("bbe98bab-c759-446b-a16c-39442e9a0e88"), new Guid("aff40a81-7209-40ed-a5a2-15eb57acd250") });

            migrationBuilder.DeleteData(
                table: "EmployeeRoles",
                keyColumns: new[] { "EmployeeId", "RoleId" },
                keyValues: new object[] { new Guid("fc8d4d36-6d32-4455-81ce-bca99786d515"), new Guid("6305cb2f-0746-4bbb-90c5-d60c2f88da6f") });
        }
    }
}
