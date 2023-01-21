using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PollingApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPollSchemaDeadlineUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "65b787d6-29d6-4bf3-80a6-1116ebf46d5e", "f528d18c-988b-4723-91e0-b7c2c5aa421e", "User", "USER" },
                    { "b6a5647a-61bd-4fed-88a7-750794a91a6b", "dfac5ee1-def5-48c1-bcba-2e13e9184272", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65b787d6-29d6-4bf3-80a6-1116ebf46d5e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6a5647a-61bd-4fed-88a7-750794a91a6b");

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
    }
}
