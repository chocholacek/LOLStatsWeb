using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class SearchBoxModel
    {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}