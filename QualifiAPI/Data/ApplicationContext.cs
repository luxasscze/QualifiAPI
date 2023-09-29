using Microsoft.EntityFrameworkCore;
using QualifiAPI.Models;

namespace QualifiAPI.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<PrequalificationRequest> Requests { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
