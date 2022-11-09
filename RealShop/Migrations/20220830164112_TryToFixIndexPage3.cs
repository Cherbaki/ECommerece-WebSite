using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealShop.Migrations
{
    public partial class TryToFixIndexPage3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Image_IndexPage_IndexPageEntityIdForTopImage",
            //    table: "Image");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Image_IndexPage_IndexPageEntityIdForTopImage",
            //    table: "Image",
            //    column: "IndexPageEntityIdForTopImage",
            //    principalTable: "IndexPage",
            //    principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Image_IndexPage_IndexPageEntityIdForTopImage",
            //    table: "Image");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Image_IndexPage_IndexPageEntityIdForTopImage",
            //    table: "Image",
            //    column: "IndexPageEntityIdForTopImage",
            //    principalTable: "IndexPage",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
