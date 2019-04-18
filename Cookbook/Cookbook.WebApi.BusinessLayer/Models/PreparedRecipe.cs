using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cookbook.WebApi.BusinessLayer.Models
{
    public class PreparedRecipe
    {
        public int? PreparedRecipeId { get; set; }

        [StringLength(50)]
        public string Alias { get; set; }

        public bool Complete { get; set; }

        public DateTime PreparedWhen { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
