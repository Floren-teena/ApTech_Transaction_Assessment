using Microsoft.EntityFrameworkCore;
using TransactionAssessment.Models;

namespace TransactionAssessment.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
