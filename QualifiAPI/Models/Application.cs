using System.ComponentModel.DataAnnotations;

namespace QualifiAPI.Models
{
    public class Application
    {
        [Required]
        public string? Name { get; set; }
        [Required]
        public DateTime Dob { get; set; }
        [Required]
        public decimal Salary { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
