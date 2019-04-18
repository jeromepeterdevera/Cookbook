using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cookbook.WebApi.BusinessLayer.Models
{
    public class Cook
    {
        public int? CookId { get; set; }

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
    }
}
