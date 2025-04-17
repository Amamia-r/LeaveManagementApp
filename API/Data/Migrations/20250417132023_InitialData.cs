using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Department = table.Column<string>(type: "TEXT", nullable: false),
                    JoiningDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    LeaveType = table.Column<string>(type: "TEXT", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Department", "FullName", "JoiningDate" },
                values: new object[,]
                {
                    { 1, "IT", "Harry Potter", new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "HR", "Hermione Granger", new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Finance", "Ron Weasley", new DateTime(2019, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "Id", "CreatedAt", "EmployeeId", "EndDate", "LeaveType", "Reason", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 17, 16, 20, 21, 114, DateTimeKind.Local).AddTicks(7486), 1, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual", "Vacation", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved" },
                    { 2, new DateTime(2025, 4, 17, 16, 20, 21, 114, DateTimeKind.Local).AddTicks(7502), 1, new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual", "Family trip", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" },
                    { 3, new DateTime(2025, 4, 17, 16, 20, 21, 114, DateTimeKind.Local).AddTicks(7506), 2, new DateTime(2024, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sick", "Flu symptoms", new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved" },
                    { 4, new DateTime(2025, 4, 17, 16, 20, 21, 114, DateTimeKind.Local).AddTicks(7509), 2, new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Other", "Personal business trip", new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rejected" },
                    { 5, new DateTime(2025, 4, 17, 16, 20, 21, 114, DateTimeKind.Local).AddTicks(7512), 3, new DateTime(2024, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual", "Europe trip", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved" },
                    { 6, new DateTime(2025, 4, 17, 16, 20, 21, 114, DateTimeKind.Local).AddTicks(7515), 3, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Annual", "Staycation", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Approved" },
                    { 7, new DateTime(2025, 4, 17, 16, 20, 21, 114, DateTimeKind.Local).AddTicks(7518), 3, new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sick", "", new DateTime(2024, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_EmployeeId",
                table: "LeaveRequests",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
