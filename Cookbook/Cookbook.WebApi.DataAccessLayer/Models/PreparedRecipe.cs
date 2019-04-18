using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cookbook.WebApi.DataAccessLayer.Models
{
    [Table("PreparedRecipe", Schema = "Recipe")]
    public class PreparedRecipe
    {
        public PreparedRecipe()
        {
            this.PreparedRecipeIngredients = new List<PreparedRecipeIngredient>();
        }

        public int PreparedRecipeId { get; set; }

        [StringLength(25)]
        public string Alias { get; set; }

        [Required]
        public int CookId { get; set; }

        public Cook Cook { get; set; }

        public int? RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        public DateTime PreparedWhen { get; set; }

        public bool Complete { get; set; }

        public IEnumerable<PreparedRecipeIngredient> PreparedRecipeIngredients { get; set; }
    }
}
