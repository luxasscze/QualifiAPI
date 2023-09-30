using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace QualifiAPI.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string? CardName { get; set; }
        public string? Issuer { get; set; }
        public decimal? AnnualFee { get; set; }
        public decimal? MinSalary { get; set; }
        public string? Features { get; set; }
    }
}
