using Microsoft.EntityFrameworkCore;
using QualifiAPI.Data;
using QualifiAPI.Models;
using QualifiAPI.Services.Interfaces;
using System;

namespace QualifiAPI.Services
{
    public class PrequalificationService : IPrequalificationService
    {
        private ApplicationContext _context;

        public PrequalificationService(ApplicationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Function to determine available credit card offers for the applicant
        /// </summary>
        /// <param name="application">Input data</param>
        /// <returns>List of available credit card offers</returns>
        public async Task<List<CreditCard>?> PrequalifyApplicant(Application application)
        {
            if (application == null) { return null; }

            try
            {
                List<CreditCard> creditCards = _context.CreditCards.Where(s => application.Salary >= s.MinSalary).ToList();

                List<int> ccIds = new();
                creditCards.ForEach(s => ccIds.Add(s.Id));

                PrequalificationRequest request = new()
                {
                    Address = application.Address,
                    CreditCardIds = ccIds,
                    Dob = application.Dob,
                    Name = application.Name,
                    Salary = application.Salary,
                    Created = DateTime.Now
                };

                await _context.Requests.AddAsync(request);
                await _context.SaveChangesAsync();

                return creditCards;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
