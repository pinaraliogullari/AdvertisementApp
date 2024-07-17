using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdvertisementApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "Definition" },
                values: new object[,]
                {
                    { 3, "Admin" },
                    { 4, "Member" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "Definition" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Member" }
                });
        }
    }
}
