using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealShop.Migrations
{
    public partial class AddImageToCategories1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Image",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_CategoryId",
                table: "Image",
                column: "CategoryId",
                unique: true,
                filter: "[CategoryId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Image_Categories_CategoryId",
                table: "Image",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Image_Categories_CategoryId",
                table: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Image_CategoryId",
                table: "Image");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Image");

            migrationBuilder.AddColumn<int>(
                name: "MainIconId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_MainIconId",
                table: "Categories",
                column: "MainIconId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Image_MainIconId",
                table: "Categories",
                column: "MainIconId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
