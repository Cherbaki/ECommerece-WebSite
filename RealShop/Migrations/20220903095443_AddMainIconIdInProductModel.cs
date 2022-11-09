using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealShop.Migrations
{
    public partial class AddMainIconIdInProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "MainIconId",
            //    table: "Products",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_MainIconId",
            //    table: "Products",
            //    column: "MainIconId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Products_Image_MainIconId",
            //    table: "Products",
            //    column: "MainIconId",
            //    principalTable: "Image",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Products_Image_MainIconId",
            //    table: "Products");

            //migrationBuilder.DropIndex(
            //    name: "IX_Products_MainIconId",
            //    table: "Products");

            //migrationBuilder.DropColumn(
            //    name: "MainIconId",
            //    table: "Products");
        }
    }
}
