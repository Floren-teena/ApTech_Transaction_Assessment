using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TransactionAssessment.Models;

namespace TransactionAssessment.Data
{
    public class ApplicationDbContext: DbContext, IDataProtectionKeyContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
    }
}
