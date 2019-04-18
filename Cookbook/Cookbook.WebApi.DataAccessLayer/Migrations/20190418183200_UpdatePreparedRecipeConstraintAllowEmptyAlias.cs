using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookbook.WebApi.DataAccessLayer.Migrations
{
    public partial class UpdatePreparedRecipeConstraintAllowEmptyAlias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PreparedRecipe_Alias_RecipeId",
                schema: "Recipe",
                table: "PreparedRecipe");

            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                schema: "Recipe",
                table: "PreparedRecipe",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 25);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Alias",
                schema: "Recipe",
                table: "PreparedRecipe",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreparedRecipe_Alias_RecipeId",
                schema: "Recipe",
                table: "PreparedRecipe",
                columns: new[] { "Alias", "RecipeId" },
                unique: true,
                filter: "[RecipeId] IS NOT NULL");
        }
    }
}
