using Cookbook.WebApi.DataAccessLayer.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cookbook.WebApi.DataAccessLayer.DataContext
{
    public class CookbookDbContext : DbContext
    {
        public CookbookDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .HasIndex(r => new { r.Name, r.CookId })
                .IsUnique();

            modelBuilder.Entity<Ingredient>()
                .HasIndex(i => i.Name )
                .IsUnique();

            modelBuilder.Entity<RecipeIngredient>()
                .HasIndex(ri => new { ri.RecipeId, ri.IngredientId })
                .IsUnique();

            modelBuilder.Entity<PreparedRecipeIngredient>()
                .HasIndex(pri => new { pri.PreparedRecipeId, pri.IngredientId })
                .IsUnique();
        }

        public DbSet<Cook> cooks { get; set; }

        public DbSet<Ingredient> ingredients { get; set; }

        public DbSet<Recipe> recipes { get; set; }

        public DbSet<RecipeIngredient> recipeIngredients { get; set; }

        public DbSet<PreparedRecipe> preparedRecipes { get; set; }

        public DbSet<PreparedRecipeIngredient> preparedRecipeIngredients { get; set; }
    }
}
