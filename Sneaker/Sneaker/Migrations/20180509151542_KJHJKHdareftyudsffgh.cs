using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Sneaker.Migrations
{
    public partial class KJHJKHdareftyudsffgh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductSizes",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Number",
                table: "ProductSizes",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductSizes");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "ProductSizes");
        }
    }
}
