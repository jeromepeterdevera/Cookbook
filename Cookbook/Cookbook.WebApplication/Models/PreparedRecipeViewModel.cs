using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Cookbook.WebApplication.Models
{
    [DataContract]
    public class PreparedRecipeViewModel
    {
        [DataMember]
        public int? PreparedRecipeId { get; set; }

        [DataMember]
        [Required]
        [StringLength(50)]
        public string Alias { get; set; }

        [DataMember]
        public bool Complete { get; set; }

        [DataMember]
        public DateTime PreparedWhen { get; set; }

        [DataMember]
        public IEnumerable<IngredientViewModel> Ingredients { get; set; }
    }
}
