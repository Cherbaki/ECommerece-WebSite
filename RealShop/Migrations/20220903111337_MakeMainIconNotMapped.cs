using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealShop.Migrations
{
    public partial class MakeMainIconNotMapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Image_Products_ProductId1",
            //    table: "Image");

            //migrationBuilder.DropIndex(
            //    name: "IX_Image_ProductId1",
            //    table: "Image");

            //migrationBuilder.DropColumn(
            //    name: "ProductId1",
            //    table: "Image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProductId1",
                table: "Image",
                column: "ProductId1",
                unique: true,
                filter: "[ProductId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Products_ProductId1",
                table: "Image",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
