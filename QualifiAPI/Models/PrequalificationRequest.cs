using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace QualifiAPI.Models
{
    public class PrequalificationRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public DateTime Dob { get; set; }
        public decimal? Salary { get; set; }
        [Column]
        public string CreditCardIdsJson
        {
            get => JsonSerializer.Serialize(CreditCardIds);
            set => CreditCardIds = JsonSerializer.Deserialize<List<int>?>(value);
        }
        [NotMapped]
        public List<int>? CreditCardIds { get; set; }
        public DateTime Created { get; set; }
    }
}
