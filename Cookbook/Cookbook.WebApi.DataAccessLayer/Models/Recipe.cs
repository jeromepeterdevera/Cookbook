using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cookbook.WebApi.DataAccessLayer.Models
{
    [Table("Recipe", Schema = "Recipe")]
    public class Recipe
    {
        public Recipe()
        {
            RecipeIngredients = new List<RecipeIngredient>();
            PreparedRecipes = new List<PreparedRecipe>();
        }

        public int RecipeId { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public IEnumerable<RecipeIngredient> RecipeIngredients { get; set; }

        public IEnumerable<PreparedRecipe> PreparedRecipes { get; set; }

        public int CookId { get; set; }

        public Cook Cook { get; set; }
    }
}
