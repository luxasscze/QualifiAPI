using Microsoft.EntityFrameworkCore;
using QualifiAPI.Data;
using QualifiAPI.Models;
using QualifiAPI.Services.Interfaces;
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

        public async Task<List<CreditCard>?> PrequalifyApplicant(Application application)
        {
            if (application == null) { return null; }

            try
            {
                List<CreditCard> creditCards = _context.CreditCards.Where(s => application.Salary >= s.MinSalary).ToList();

                PrequalificationRequest request = new()
                {
                    Address = application.Address,
                    CreditCards = new List<CreditCard>()
                    {
                        new CreditCard()
                        {
                            AnnualFee = 12.99M,
                            CardName = "Testing Card",
                            Features = "NONE",
                            Issuer = "HSBC",
                            MinSalary = 1299M
                        }
                    },
                    Dob = application.Dob,
                    Name = application.Name,
                    Salary = application.Salary,
                    Created = DateTime.Now
                };

                await _context.Requests.AddAsync(request);
                await _context.SaveChangesAsync();

                return creditCards;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<CreditCard>?> GetAllCreditCards()
        {
            return await _context.CreditCards.ToListAsync();
        }

        public async Task<List<PrequalificationRequest>> GetAllRequests()
        {
            return await _context.Requests.ToListAsync();
        }
    }
}
