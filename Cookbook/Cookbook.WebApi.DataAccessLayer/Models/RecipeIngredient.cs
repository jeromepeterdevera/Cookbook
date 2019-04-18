using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cookbook.WebApi.DataAccessLayer.Models
{
    [Table("RecipeIngredient", Schema = "Recipe")]
    public class RecipeIngredient
    {
        public RecipeIngredient()
        {
        }
        public int RecipeIngredientId { get; set; }

        public int RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public int IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}
