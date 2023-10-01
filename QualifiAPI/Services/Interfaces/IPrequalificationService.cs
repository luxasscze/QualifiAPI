using QualifiAPI.Models;

namespace QualifiAPI.Services.Interfaces
{
    public interface IPrequalificationService
    {
        /// <summary>
        /// Prequalify Applicant function to determine available credit card offers for the applicant
        /// </summary>
        /// <param name="application">Input data</param>
        /// <returns>List of available credit card offers</returns>
        public Task<List<CreditCard>?> PrequalifyApplicant(Application application);
    }
}
