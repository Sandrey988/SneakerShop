using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sneaker.Migrations
{
    public partial class qwe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sneakers_SneakerId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "SneakerId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sneakers_SneakerId",
                table: "Products",
                column: "SneakerId",
                principalTable: "Sneakers",
                principalColumn: "SneakerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Sneakers_SneakerId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "SneakerId",
                table: "Products",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Sneakers_SneakerId",
                table: "Products",
                column: "SneakerId",
                principalTable: "Sneakers",
                principalColumn: "SneakerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
