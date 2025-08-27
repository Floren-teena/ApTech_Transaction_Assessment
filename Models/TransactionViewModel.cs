using System.ComponentModel.DataAnnotations;

namespace TransactionAssessment.Models
{
    public class TransactionViewModel
    {
        public Guid? TransactionId { get; set; }

        [Required(ErrorMessage = "Account number is required")]
        [StringLength(12, ErrorMessage = "Account number cannot exceed 12 characters")]
        public string? AccountNumber { get; set; }

        [Required(ErrorMessage = "Beneficiary name is required")]
        [StringLength(100, ErrorMessage = "Beneficiary name cannot exceed 100 characters")]
        public string? BeneficiaryName { get; set; }

        [Required(ErrorMessage = "Bank name is required")]
        [StringLength(100, ErrorMessage = "Bank name cannot exceed 100 characters")]
        public string? BankName { get; set; }

        [Required(ErrorMessage = "SWIFT code is required")]
        [StringLength(11, ErrorMessage = "SWIFT code cannot exceed 11 characters")]
        public string? SWIFTCode { get; set; }

        [Required(ErrorMessage = "Amount is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public int Amount { get; set; }
    }
}
