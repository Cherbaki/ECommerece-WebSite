using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealShop.Migrations
{
    public partial class AllowsNullsForOrderAndProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Orders_AspNetUsers_UserId",
            //    table: "Orders");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Orders_Products_ProductId",
            //    table: "Orders");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Products_AspNetUsers_UserId",
            //    table: "Products");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Orders_AspNetUsers_UserId",
            //    table: "Orders",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.SetNull);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Orders_Products_ProductId",
            //    table: "Orders",
            //    column: "ProductId",
            //    principalTable: "Products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.SetNull);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Products_AspNetUsers_UserId",
            //    table: "Products",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Orders_AspNetUsers_UserId",
            //    table: "Orders");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Orders_Products_ProductId",
            //    table: "Orders");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Products_AspNetUsers_UserId",
            //    table: "Products");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Orders_AspNetUsers_UserId",
            //    table: "Orders",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Orders_Products_ProductId",
            //    table: "Orders",
            //    column: "ProductId",
            //    principalTable: "Products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Products_AspNetUsers_UserId",
            //    table: "Products",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
