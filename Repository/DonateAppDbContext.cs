using Microsoft.EntityFrameworkCore;
using PaymentIntegration.Models;

namespace PaymentIntegration.Repository
{
    public class DonateAppDbContext : DbContext
    {
        public DonateAppDbContext(DbContextOptions<DonateAppDbContext> options) :  base(options)
        {

        }
        public DbSet<TransactionModel> Transactions { get; set; }
    }
}
