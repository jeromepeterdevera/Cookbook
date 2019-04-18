using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Cookbook.WebApplication.Models
{
    [DataContract]
    public class RecipeViewModel
    {
        [DataMember]
        public int? RecipeId { get; set; }

        [DataMember]
        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        [DataMember]
        [StringLength(250)]
        public string Description { get; set; }

        [DataMember]
        [Required]
        public IEnumerable<IngredientViewModel> Ingredients { get; set; }

        [DataMember]
        public IEnumerable<PreparedRecipeViewModel> PreparedRecipes { get; set; }
    }
}
