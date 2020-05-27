using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRecipes.Data.Migrations
{
    public partial class Added_Views : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                table: "Recipes");
        }
    }
}
