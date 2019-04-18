using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Cookbook.WebApplication.Models
{
    [DataContract]
    public class CookViewModel
    {
        [DataMember]
        public int? CookId { get; set; }

        [DataMember]
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Email { get; set; }

        [DataMember]
        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [DataMember]
        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        [DataMember]
        public IEnumerable<RecipeViewModel> Recipes { get; set; }
    }
}
