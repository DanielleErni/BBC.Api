using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BBC.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class GameNCustomerSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "ContanctNumber", "Name" },
                values: new object[,]
                {
                    { 1, 901, "Kyla" },
                    { 2, 902, "Sean" },
                    { 3, 903, "Jojo" },
                    { 4, 904, "Niks" },
                    { 5, 905, "Mat" }
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Genre", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Action", 59.99m, "Red Dead Redemption 2" },
                    { 2, "Fps", 69.69m, "Stalker" },
                    { 3, "Survival Horror", 120.25m, "Fear and Hunger" },
                    { 4, "Rpg", 75.05m, "Black Souls" },
                    { 5, "Rts", 59.99m, "StarCraft" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Game",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
