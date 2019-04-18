using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cookbook.WebApi.DataAccessLayer.Models
{
    [Table("PreparedRecipeIngredient", Schema = "Recipe")]
    public class PreparedRecipeIngredient
    {
        public int PreparedRecipeIngredientId { get; set; }

        public int PreparedRecipeId { get; set; }

        public PreparedRecipe PreparedRecipe { get; set; }

        public int? IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}
