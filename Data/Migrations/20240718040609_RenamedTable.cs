using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BBC.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Customer_CustomerDetailsId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Game_GameDetailsId",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Games");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameIndex(
                name: "IX_Order_GameDetailsId",
                table: "Orders",
                newName: "IX_Orders_GameDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_CustomerDetailsId",
                table: "Orders",
                newName: "IX_Orders_CustomerDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerDetailsId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Games_GameDetailsId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Game");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_GameDetailsId",
                table: "Order",
                newName: "IX_Order_GameDetailsId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_CustomerDetailsId",
                table: "Order",
                newName: "IX_Order_CustomerDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Customer_CustomerDetailsId",
                table: "Order",
                column: "CustomerDetailsId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Game_GameDetailsId",
                table: "Order",
                column: "GameDetailsId",
                principalTable: "Game",
                principalColumn: "Id");
        }
    }
}
