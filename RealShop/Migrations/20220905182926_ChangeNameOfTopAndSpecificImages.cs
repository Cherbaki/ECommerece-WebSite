using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealShop.Migrations
{
    public partial class ChangeNameOfTopAndSpecificImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Products_ProductIdForMainIcon",
                table: "Image");

            migrationBuilder.RenameColumn(
                name: "TopImageProduId",
                table: "IndexPage",
                newName: "TopImageId");

            migrationBuilder.RenameColumn(
                name: "SpecificImageProductId",
                table: "IndexPage",
                newName: "SpecificImageId");

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

            migrationBuilder.RenameColumn(
                name: "TopImageId",
                table: "IndexPage",
                newName: "TopImageProduId");

            migrationBuilder.RenameColumn(
                name: "SpecificImageId",
                table: "IndexPage",
                newName: "SpecificImageProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Products_ProductIdForMainIcon",
                table: "Image",
                column: "ProductIdForMainIcon",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
