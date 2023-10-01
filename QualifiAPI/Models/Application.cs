using System.ComponentModel.DataAnnotations;

namespace QualifiAPI.Models
{
    public class Application
    {
        [Required]
        [MinLength(5)]
        public string? Name { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        [Range(1, 19999)]
        public decimal Salary { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
