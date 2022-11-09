using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealShop.Migrations
{
    public partial class SetUserProductUserIdsToNullable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Image_AspNetUsers_UserId",
            //    table: "Image");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Image_Products_ProductId",
            //    table: "Image");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Image_AspNetUsers_UserId",
            //    table: "Image",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.SetNull);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Image_Products_ProductId",
            //    table: "Image",
            //    column: "ProductId",
            //    principalTable: "Products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Image_AspNetUsers_UserId",
            //    table: "Image");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Image_Products_ProductId",
            //    table: "Image");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Image_AspNetUsers_UserId",
            //    table: "Image",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Image_Products_ProductId",
            //    table: "Image",
            //    column: "ProductId",
            //    principalTable: "Products",
            //    principalColumn: "Id");
        }
    }
}
