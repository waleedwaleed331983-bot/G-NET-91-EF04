using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_Core_04.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataForBranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Code", "ManagerId", "Name", "PhoneNumber", "Address_City", "Address_Country", "Address_Street" },
                values: new object[,]
                {
                    { 2, 2, "SecondBranch", "01478523691", "Alex", "Egypt", "MoharemBek" },
                    { 3, 3, "SecondBranch", "01478523691", "Cairo", "Egypt", "El-Dokki" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Code",
                keyValue: 3);
        }
    }
}
