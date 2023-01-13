using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PollingApp.Migrations
{
    /// <inheritdoc />
    public partial class RolesCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d2bae0bc-69d9-43d5-93aa-ac3786bade40", "331d3545-65d4-4208-a7bd-e33a3b25afa3", "User", "USER" },
                    { "e042170e-fb45-44e7-8050-3aa2412157b0", "fe2c9281-5228-44da-857b-2af599d32738", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2bae0bc-69d9-43d5-93aa-ac3786bade40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e042170e-fb45-44e7-8050-3aa2412157b0");
        }
    }
}
