using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookbook.WebApi.DataAccessLayer.Migrations
{
    public partial class UpdatePreparedRecipeIngredientStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "PreparedWhen",
                schema: "Recipe",
                table: "PreparedRecipe",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreparedRecipeIngredient_IngredientId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreparedRecipeIngredient_Ingredient_IngredientId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient",
                column: "IngredientId",
                principalSchema: "Recipe",
                principalTable: "Ingredient",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreparedRecipeIngredient_Ingredient_IngredientId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient");

            migrationBuilder.DropIndex(
                name: "IX_PreparedRecipeIngredient_IngredientId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PreparedWhen",
                schema: "Recipe",
                table: "PreparedRecipe",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
