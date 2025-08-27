using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TransactionAssessment.Models
{
    public class Transaction
    {
        [Key]
        public Guid TransactionId { get; set; } = Guid.NewGuid();

        [MaxLength(12)]
        public string? AccountNumber { get; set; }

        [MaxLength(100)]
        public string? BeneficiaryName { get; set; }

        [MaxLength(100)]
        public string? BankName { get; set; }

        [MaxLength(11)]
        public string? SWIFTCode { get; set; }

        public int Amount { get; set; }
    }
}
