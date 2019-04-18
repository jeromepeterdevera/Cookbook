using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Cookbook.WebApplication.Models
{
    [DataContract]
    public class IngredientViewModel
    {
        [DataMember]
        public int? IngredientId { get; set; }

        [DataMember]
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
    }
}
