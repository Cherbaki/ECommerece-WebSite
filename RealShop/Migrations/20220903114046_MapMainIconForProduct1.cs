using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealShop.Migrations
{
    public partial class MapMainIconForProduct1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductIdForMainIcon",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductIdForMainIcon",
                table: "Image",
                column: "ProductIdForMainIcon",
                unique: true,
                filter: "[ProductIdForMainIcon] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Products_ProductIdForMainIcon",
                table: "Image",
                column: "ProductIdForMainIcon",
                principalTable: "Products",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Products_ProductIdForMainIcon",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_ProductIdForMainIcon",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ProductIdForMainIcon",
                table: "Image");
        }
    }
}
