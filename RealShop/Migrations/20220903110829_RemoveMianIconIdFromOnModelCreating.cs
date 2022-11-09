using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealShop.Migrations
{
    public partial class RemoveMianIconIdFromOnModelCreating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Categories_CategoryId",
                table: "Image");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Categories_CategoryId",
                table: "Image",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Categories_CategoryId",
                table: "Image");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Categories_CategoryId",
                table: "Image",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
