using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SwaggerExample.Migrations
{
    public partial class shoppinghistoryaddshopdatecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ShopDate",
                table: "ShoppingHistories",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShopDate",
                table: "ShoppingHistories");
        }
    }
}
