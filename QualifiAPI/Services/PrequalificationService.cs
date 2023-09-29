using Microsoft.EntityFrameworkCore;
using QualifiAPI.Data;
using QualifiAPI.Models;
using QualifiAPI.Services.Interfaces;
using QualifiAPI.Utils;
using System;

namespace QualifiAPI.Services
{
    public class PrequalificationService : IPrequalificationService
    {
        public ApplicationContext _context;

        public PrequalificationService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> PrequalificationRequestSave(PrequalificationRequest request)
        {
            if (request == null)
            {
                return false;
            }
            
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<CreditCard>?> PrequalifyApplicant(PrequalificationRequest request)
        {
            if (request == null) { return null; }

            return await _context.CreditCards.Where(s => s.CreditScoreRequirement == CreditScoreUtils.GetCreditScoreFromSalary(request.Salary)).ToListAsync();

        }
    }
}
