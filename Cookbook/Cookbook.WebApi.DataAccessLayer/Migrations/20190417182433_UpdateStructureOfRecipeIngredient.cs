using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookbook.WebApi.DataAccessLayer.Migrations
{
    public partial class UpdateStructureOfRecipeIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreparedRecipeIngredient_RecipeIngredient_RecipeIngredientId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient");

            migrationBuilder.DropIndex(
                name: "IX_PreparedRecipeIngredient_RecipeIngredientId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient");

            migrationBuilder.DropColumn(
                name: "RecipeIngredientId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeIngredientId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreparedRecipeIngredient_RecipeIngredientId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient",
                column: "RecipeIngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreparedRecipeIngredient_RecipeIngredient_RecipeIngredientId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient",
                column: "RecipeIngredientId",
                principalSchema: "Recipe",
                principalTable: "RecipeIngredient",
                principalColumn: "RecipeIngredientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
