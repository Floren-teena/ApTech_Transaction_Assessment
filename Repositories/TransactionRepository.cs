using TransactionAssessment.Data;
using TransactionAssessment.Models;
using Microsoft.EntityFrameworkCore;
using TransactionAssessment.Interfaces;

namespace TransactionAssessment.Repositories
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetByAmountRangeAsync(int minAmount, int maxAmount)
        {
            return await _context.Transactions
                .Where(t => t.Amount >= minAmount && t.Amount <= maxAmount)
                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetByBankNameAsync(string bankName)
        {
            if (string.IsNullOrWhiteSpace(bankName))
            {
                return new List<Transaction>();
            }

            var lowerCaseBankName = bankName.Trim().ToLower();
            return await _context.Transactions
                .Where(t => t.BankName != null && t.BankName.ToLower().Contains(lowerCaseBankName))
                .ToListAsync();
        }
    }
}
