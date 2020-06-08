using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyRecipes.Data.Migrations
{
    public partial class UpdateRecipeComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "RecipeComments",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "RecipeComments",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "RecipeComments");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "RecipeComments",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
