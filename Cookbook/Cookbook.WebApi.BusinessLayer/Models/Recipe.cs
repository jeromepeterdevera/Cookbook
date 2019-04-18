using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cookbook.WebApi.BusinessLayer.Models
{
    public class Recipe
    {
        public int? RecipeId { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public IEnumerable<Ingredient> Ingredients { get; set; }

        public IEnumerable<PreparedRecipe> PreparedRecipes { get; set; }
    }
}
