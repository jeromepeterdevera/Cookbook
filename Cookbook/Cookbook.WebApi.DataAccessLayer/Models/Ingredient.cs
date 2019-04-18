using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cookbook.WebApi.DataAccessLayer.Models
{
    [Table("Ingredient", Schema = "Recipe")]
    public class Ingredient
    {
        public Ingredient()
        {
            RecipeIngredients = new List<RecipeIngredient>();
            PreparedRecipeIngredients = new List<PreparedRecipeIngredient>();
        }

        public int IngredientId { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public IEnumerable<RecipeIngredient> RecipeIngredients { get; set; }

        public IEnumerable<PreparedRecipeIngredient> PreparedRecipeIngredients { get; set; }
    }
}
