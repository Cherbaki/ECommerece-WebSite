using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealShop.Migrations
{
    public partial class AddImageToCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "MainIconId",
            //    table: "Categories",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Categories_MainIconId",
            //    table: "Categories",
            //    column: "MainIconId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Categories_Image_MainIconId",
            //    table: "Categories",
            //    column: "MainIconId",
            //    principalTable: "Image",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Categories_Image_MainIconId",
            //    table: "Categories");

            //migrationBuilder.DropIndex(
            //    name: "IX_Categories_MainIconId",
            //    table: "Categories");

            //migrationBuilder.DropColumn(
            //    name: "MainIconId",
            //    table: "Categories");
        }
    }
}
