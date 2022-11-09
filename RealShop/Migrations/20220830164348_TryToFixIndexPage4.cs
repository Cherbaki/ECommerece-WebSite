using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealShop.Migrations
{
    public partial class TryToFixIndexPage4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Image_IndexPage_IndexPageEntityIdForSpecImage",
            //    table: "Image");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Image_IndexPage_IndexPageEntityIdForTopImage",
            //    table: "Image");

            //migrationBuilder.DropTable(
            //    name: "IndexPage");

            //migrationBuilder.DropIndex(
            //    name: "IX_Image_IndexPageEntityIdForSpecImage",
            //    table: "Image");

            //migrationBuilder.DropIndex(
            //    name: "IX_Image_IndexPageEntityIdForTopImage",
            //    table: "Image");

            //migrationBuilder.DropColumn(
            //    name: "IndexPageEntityIdForSpecImage",
            //    table: "Image");

            //migrationBuilder.DropColumn(
            //    name: "IndexPageEntityIdForTopImage",
            //    table: "Image");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "IndexPageEntityIdForSpecImage",
            //    table: "Image",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.AddColumn<int>(
            //    name: "IndexPageEntityIdForTopImage",
            //    table: "Image",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "IndexPage",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SpecificImageProductId = table.Column<int>(type: "int", nullable: false),
            //        TopImageProduId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_IndexPage", x => x.Id);
            //    });

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
            //    principalColumn: "Id");
        }
    }
}
