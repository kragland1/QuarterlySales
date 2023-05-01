using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QuarterlySales.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Firstname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfHire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SalesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quarter = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SalesId);
                    table.ForeignKey(
                        name: "FK_Sales_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DOB", "DateOfHire", "Firstname", "Lastname", "ManagerId" },
                values: new object[,]
                {
                    { 1, new DateTime(1977, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Billy Bob", "Jonah", 0 },
                    { 2, new DateTime(1989, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "Ferrari", 1 },
                    { 3, new DateTime(1988, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2006, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris", "Storm", 0 },
                    { 4, new DateTime(1977, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Billy Bob", "Jonah", 9 },
                    { 5, new DateTime(1994, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2016, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carter", "Hans", 0 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "SalesId", "Amount", "EmployeeId", "Quarter", "Year" },
                values: new object[,]
                {
                    { 1, 20.0, 0, 3, 2001 },
                    { 2, 500.0, 0, 3, 2011 },
                    { 3, 200.0, 0, 3, 2012 },
                    { 4, 400.0, 0, 3, 2006 },
                    { 5, 300.0, 0, 4, 2012 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sales_EmployeeId",
                table: "Sales",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
