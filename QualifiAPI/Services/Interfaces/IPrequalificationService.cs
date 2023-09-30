using QualifiAPI.Models;

namespace QualifiAPI.Services.Interfaces
{
    public interface IPrequalificationService
    {
        public Task<List<CreditCard>?> PrequalifyApplicant(Application application);
        public Task<List<CreditCard>?> GetAllCreditCards();
        public Task<List<PrequalificationRequest>> GetAllRequests();
    }
}
