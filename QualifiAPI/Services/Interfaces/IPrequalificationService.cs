using QualifiAPI.Models;

namespace QualifiAPI.Services.Interfaces
{
    public interface IPrequalificationService
    {
        public Task<bool> PrequalificationRequestSave(PrequalificationRequest request);
    }
}
