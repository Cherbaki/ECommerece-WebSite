using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealShop.Migrations
{
    public partial class MakeImageCascadeForUser4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_UserId",
                table: "Image");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_UserId",
                table: "Image",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_AspNetUsers_UserId",
                table: "Image");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_AspNetUsers_UserId",
                table: "Image",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
