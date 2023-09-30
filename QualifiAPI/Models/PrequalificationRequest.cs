namespace QualifiAPI.Models
{
    public class PrequalificationRequest
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public DateTime Dob { get; set; }
        public decimal? Salary { get; set; }
        public IList<CreditCard>? CreditCards { get; set; }
        public DateTime Created { get; set; }
    }
}
