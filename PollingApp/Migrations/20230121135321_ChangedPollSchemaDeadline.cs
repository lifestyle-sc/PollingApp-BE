using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PollingApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPollSchemaDeadline : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2bae0bc-69d9-43d5-93aa-ac3786bade40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e042170e-fb45-44e7-8050-3aa2412157b0");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Polls");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cfb0f76e-543c-4406-9656-8b989555e11b", "1155a60a-f17a-4d07-a73c-66a2121f8ceb", "User", "USER" },
                    { "e38ead72-b64a-42ae-8903-038a7096e0cc", "5656c609-360e-4fd9-a98b-0f63bfe82f73", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cfb0f76e-543c-4406-9656-8b989555e11b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e38ead72-b64a-42ae-8903-038a7096e0cc");

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Polls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d2bae0bc-69d9-43d5-93aa-ac3786bade40", "331d3545-65d4-4208-a7bd-e33a3b25afa3", "User", "USER" },
                    { "e042170e-fb45-44e7-8050-3aa2412157b0", "fe2c9281-5228-44da-857b-2af599d32738", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
