﻿using Microsoft.Extensions.Diagnostics.HealthChecks;
using QualifiAPI.Enums;

namespace QualifiAPI.Models
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string? CardName { get; set; }
        public string? Issuer { get; set; }
        public decimal? AnnualFee { get; set; }
        public CreditScore CreditScoreRequirement { get; set; }
        public string? Features { get; set; }
    }
}
