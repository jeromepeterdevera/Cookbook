using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookbook.WebApi.DataAccessLayer.Migrations
{
    public partial class AlterIndexOfPreparedRecipeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PreparedRecipe_Alias_CookId",
                schema: "Recipe",
                table: "PreparedRecipe");

            migrationBuilder.CreateIndex(
                name: "IX_PreparedRecipe_Alias_RecipeId",
                schema: "Recipe",
                table: "PreparedRecipe",
                columns: new[] { "Alias", "RecipeId" },
                unique: true,
                filter: "[RecipeId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PreparedRecipe_Alias_RecipeId",
                schema: "Recipe",
                table: "PreparedRecipe");

            migrationBuilder.CreateIndex(
                name: "IX_PreparedRecipe_Alias_CookId",
                schema: "Recipe",
                table: "PreparedRecipe",
                columns: new[] { "Alias", "CookId" },
                unique: true);
        }
    }
}
