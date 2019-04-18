using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cookbook.WebApi.DataAccessLayer.Migrations
{
    public partial class CreateDatabaseAndTablesForCookbook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Recipe");

            migrationBuilder.CreateTable(
                name: "Cook",
                schema: "Recipe",
                columns: table => new
                {
                    CookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    LastName = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cook", x => x.CookId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                schema: "Recipe",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                schema: "Recipe",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    CookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_Recipe_Cook_CookId",
                        column: x => x.CookId,
                        principalSchema: "Recipe",
                        principalTable: "Cook",
                        principalColumn: "CookId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreparedRecipe",
                schema: "Recipe",
                columns: table => new
                {
                    PreparedRecipeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Alias = table.Column<string>(maxLength: 25, nullable: false),
                    CookId = table.Column<int>(nullable: false),
                    PreparedWhen = table.Column<DateTime>(nullable: true),
                    Complete = table.Column<bool>(nullable: false),
                    RecipeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreparedRecipe", x => x.PreparedRecipeId);
                    table.ForeignKey(
                        name: "FK_PreparedRecipe_Cook_CookId",
                        column: x => x.CookId,
                        principalSchema: "Recipe",
                        principalTable: "Cook",
                        principalColumn: "CookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreparedRecipe_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "Recipe",
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                schema: "Recipe",
                columns: table => new
                {
                    RecipeIngredientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RecipeId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => x.RecipeIngredientId);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "Recipe",
                        principalTable: "Ingredient",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "Recipe",
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreparedRecipeIngredient",
                schema: "Recipe",
                columns: table => new
                {
                    PreparedRecipeIngredientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PreparedRecipeId = table.Column<int>(nullable: false),
                    RecipeIngredientId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreparedRecipeIngredient", x => x.PreparedRecipeIngredientId);
                    table.ForeignKey(
                        name: "FK_PreparedRecipeIngredient_PreparedRecipe_PreparedRecipeId",
                        column: x => x.PreparedRecipeId,
                        principalSchema: "Recipe",
                        principalTable: "PreparedRecipe",
                        principalColumn: "PreparedRecipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PreparedRecipeIngredient_RecipeIngredient_RecipeIngredientId",
                        column: x => x.RecipeIngredientId,
                        principalSchema: "Recipe",
                        principalTable: "RecipeIngredient",
                        principalColumn: "RecipeIngredientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_Name",
                schema: "Recipe",
                table: "Ingredient",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreparedRecipe_CookId",
                schema: "Recipe",
                table: "PreparedRecipe",
                column: "CookId");

            migrationBuilder.CreateIndex(
                name: "IX_PreparedRecipe_RecipeId",
                schema: "Recipe",
                table: "PreparedRecipe",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_PreparedRecipe_Alias_CookId",
                schema: "Recipe",
                table: "PreparedRecipe",
                columns: new[] { "Alias", "CookId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PreparedRecipeIngredient_PreparedRecipeId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient",
                column: "PreparedRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_PreparedRecipeIngredient_RecipeIngredientId",
                schema: "Recipe",
                table: "PreparedRecipeIngredient",
                column: "RecipeIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_CookId",
                schema: "Recipe",
                table: "Recipe",
                column: "CookId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_Name_CookId",
                schema: "Recipe",
                table: "Recipe",
                columns: new[] { "Name", "CookId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_IngredientId",
                schema: "Recipe",
                table: "RecipeIngredient",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipeId",
                schema: "Recipe",
                table: "RecipeIngredient",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreparedRecipeIngredient",
                schema: "Recipe");

            migrationBuilder.DropTable(
                name: "PreparedRecipe",
                schema: "Recipe");

            migrationBuilder.DropTable(
                name: "RecipeIngredient",
                schema: "Recipe");

            migrationBuilder.DropTable(
                name: "Ingredient",
                schema: "Recipe");

            migrationBuilder.DropTable(
                name: "Recipe",
                schema: "Recipe");

            migrationBuilder.DropTable(
                name: "Cook",
                schema: "Recipe");
        }
    }
}
