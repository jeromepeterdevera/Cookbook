using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cookbook.WebApi.BusinessLayer.Models
{
    public class Ingredient
    {
        public int? IngredientId { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }
    }
}
