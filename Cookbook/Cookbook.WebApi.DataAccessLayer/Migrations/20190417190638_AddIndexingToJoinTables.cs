using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookbook.WebApi.DataAccessLayer.Migrations
{
    public partial class AddIndexingToJoinTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredient_RecipeId",
                schema: "Recipe",
                table: "RecipeIngredient");

            migrationBuilder.DropIndex(
                name: "IX_PreparedRecipeIngredient_PreparedRecipeId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipeId_IngredientId",
                schema: "Recipe",
                table: "RecipeIngredient",
                columns: new[] { "RecipeId", "IngredientId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreparedRecipeIngredient_PreparedRecipeId_IngredientId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient",
                columns: new[] { "PreparedRecipeId", "IngredientId" },
                unique: true,
                filter: "[IngredientId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredient_RecipeId_IngredientId",
                schema: "Recipe",
                table: "RecipeIngredient");

            migrationBuilder.DropIndex(
                name: "IX_PreparedRecipeIngredient_PreparedRecipeId_IngredientId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipeId",
                schema: "Recipe",
                table: "RecipeIngredient",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_PreparedRecipeIngredient_PreparedRecipeId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient",
                column: "PreparedRecipeId");
        }
    }
}
