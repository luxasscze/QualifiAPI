using Microsoft.EntityFrameworkCore;
using QualifiAPI.Models;

namespace QualifiAPI.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public ApplicationContext()
        {

        }

        public virtual DbSet<PrequalificationRequest> Requests { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
    }
}
