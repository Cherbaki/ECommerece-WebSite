﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealShop.Migrations
{
    public partial class SetUserIdOfOrderToRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Orders_AspNetUsers_UserId",
            //    table: "Orders");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Orders_AspNetUsers_UserId",
            //    table: "Orders",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Orders_AspNetUsers_UserId",
            //    table: "Orders");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Orders_AspNetUsers_UserId",
            //    table: "Orders",
            //    column: "UserId",
            //    principalTable: "AspNetUsers",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
