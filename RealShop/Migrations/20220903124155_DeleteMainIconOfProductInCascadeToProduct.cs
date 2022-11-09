using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealShop.Migrations
{
    public partial class DeleteMainIconOfProductInCascadeToProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Image_Products_ProductIdForMainIcon",
            //    table: "Image");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Image_Products_ProductIdForMainIcon",
            //    table: "Image",
            //    column: "ProductIdForMainIcon",
            //    principalTable: "Products",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Image_Products_ProductIdForMainIcon",
            //    table: "Image");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Image_Products_ProductIdForMainIcon",
            //    table: "Image",
            //    column: "ProductIdForMainIcon",
            //    principalTable: "Products",
            //    principalColumn: "Id");
        }
    }
}
