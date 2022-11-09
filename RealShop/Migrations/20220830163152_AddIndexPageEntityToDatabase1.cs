using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealShop.Migrations
{
    public partial class AddIndexPageEntityToDatabase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            //migrationBuilder.RenameColumn(
            //    name: "IndexPageEntityId1",
            //    table: "Image",
            //    newName: "IndexPageEntityIdForTopImage");

            //migrationBuilder.RenameColumn(
            //    name: "IndexPageEntityId",
            //    table: "Image",
            //    newName: "IndexPageEntityIdForSpecImage");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Image_IndexPageEntityIdForSpecImage",
            //    table: "Image",
            //    column: "IndexPageEntityIdForSpecImage",
            //    unique: true,
            //    filter: "[IndexPageEntityIdForSpecImage] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Image_IndexPageEntityIdForTopImage",
            //    table: "Image",
            //    column: "IndexPageEntityIdForTopImage",
            //    unique: true,
            //    filter: "[IndexPageEntityIdForTopImage] IS NOT NULL");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Image_IndexPage_IndexPageEntityIdForSpecImage",
            //    table: "Image",
            //    column: "IndexPageEntityIdForSpecImage",
            //    principalTable: "IndexPage",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Image_IndexPage_IndexPageEntityIdForTopImage",
            //    table: "Image",
            //    column: "IndexPageEntityIdForTopImage",
            //    principalTable: "IndexPage",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Image_IndexPage_IndexPageEntityIdForSpecImage",
            //    table: "Image");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Image_IndexPage_IndexPageEntityIdForTopImage",
            //    table: "Image");

            //migrationBuilder.DropIndex(
            //    name: "IX_Image_IndexPageEntityIdForSpecImage",
            //    table: "Image");

            //migrationBuilder.DropIndex(
            //    name: "IX_Image_IndexPageEntityIdForTopImage",
            //    table: "Image");

            //migrationBuilder.RenameColumn(
            //    name: "IndexPageEntityIdForTopImage",
            //    table: "Image",
            //    newName: "IndexPageEntityId1");

            //migrationBuilder.RenameColumn(
            //    name: "IndexPageEntityIdForSpecImage",
            //    table: "Image",
            //    newName: "IndexPageEntityId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Image_IndexPageEntityId",
            //    table: "Image",
            //    column: "IndexPageEntityId",
            //    unique: true,
            //    filter: "[IndexPageEntityId] IS NOT NULL");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Image_IndexPageEntityId1",
            //    table: "Image",
            //    column: "IndexPageEntityId1",
            //    unique: true,
            //    filter: "[IndexPageEntityId1] IS NOT NULL");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Image_IndexPage_IndexPageEntityId",
            //    table: "Image",
            //    column: "IndexPageEntityId",
            //    principalTable: "IndexPage",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Image_IndexPage_IndexPageEntityId1",
            //    table: "Image",
            //    column: "IndexPageEntityId1",
            //    principalTable: "IndexPage",
            //    principalColumn: "Id");
        }
    }
}
