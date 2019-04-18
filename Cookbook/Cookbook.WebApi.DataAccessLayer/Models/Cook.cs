using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Cookbook.WebApi.DataAccessLayer.Models
{
    [Table("Cook", Schema = "Recipe")]
    public class Cook
    {
        public Cook()
        {
            Recipes = new List<Recipe>();
            PreparedRecipes = new List<PreparedRecipe>();
        }

        public int CookId { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        public IEnumerable<Recipe> Recipes { get; set; }

        public IEnumerable<PreparedRecipe> PreparedRecipes { get; set; }
    }
}
