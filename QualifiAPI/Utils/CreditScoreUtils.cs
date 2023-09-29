using QualifiAPI.Enums;

namespace QualifiAPI.Utils
{
    public static class CreditScoreUtils
    {
        public static CreditScore GetCreditScoreFromSalary(decimal? salary)
        {
            if (salary <= 1500) return CreditScore.Poor;
            else if (salary <= 1700 && salary > 1500) return CreditScore.Bad;
            else if (salary <= 1800 && salary > 1700) return CreditScore.Good;
            else if (salary > 1800) return CreditScore.Excellent;
            else return CreditScore.None;
        }
    }
}
