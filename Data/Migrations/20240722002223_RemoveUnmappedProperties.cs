using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BBC.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnmappedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerDetailsId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Games_GameDetailsId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerDetailsId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_GameDetailsId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerDetailsId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "GameDetailsId",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerDetailsId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameDetailsId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerDetailsId",
                table: "Orders",
                column: "CustomerDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_GameDetailsId",
                table: "Orders",
                column: "GameDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerDetailsId",
                table: "Orders",
                column: "CustomerDetailsId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Games_GameDetailsId",
                table: "Orders",
                column: "GameDetailsId",
                principalTable: "Games",
                principalColumn: "Id");
        }
    }
}
