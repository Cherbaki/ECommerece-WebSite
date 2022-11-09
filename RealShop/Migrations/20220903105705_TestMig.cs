using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealShop.Migrations
{
    public partial class TestMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Image_MainIconId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_MainIconId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MainIconId",
                table: "Products");

            //migrationBuilder.AddColumn<int>(
            //    name: "ProductId1",
            //    table: "Image",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Image_ProductId1",
            //    table: "Image",
            //    column: "ProductId1",
            //    unique: true,
            //    filter: "[ProductId1] IS NOT NULL");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Image_Products_ProductId1",
            //    table: "Image",
            //    column: "ProductId1",
            //    principalTable: "Products",
            //    principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Products_ProductId1",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_ProductId1",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Image");

            migrationBuilder.AddColumn<int>(
                name: "MainIconId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_MainIconId",
                table: "Products",
                column: "MainIconId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Image_MainIconId",
                table: "Products",
                column: "MainIconId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
