using TransactionAssessment.Models;

namespace TransactionAssessment.Interfaces
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetByAmountRangeAsync(int minAmount, int maxAmount);
        Task<IEnumerable<Transaction>> GetByBankNameAsync(string bankName);
    }
}
