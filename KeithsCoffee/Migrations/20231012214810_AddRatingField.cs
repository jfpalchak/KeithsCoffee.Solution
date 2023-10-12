using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeithsCoffee.Migrations
{
    public partial class AddRatingField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "CoffeeShopDrinks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "CoffeeShopDrinks");
        }
    }
}
