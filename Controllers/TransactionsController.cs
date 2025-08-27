using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransactionAssessment.Interfaces;
using TransactionAssessment.Models;

namespace TransactionAssessment.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ITransactionRepository _transactionRepository;
        //private readonly ILogger<TransactionsController> _logger;
        private readonly IMapper _mapper;

        public TransactionsController(ITransactionRepository transactionRepository, ILogger<TransactionsController> logger, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            //_logger = logger;
            _mapper = mapper;
        }

        // GET: Transactions
        public IActionResult Index()
        {
            return View();
        }

        // GET: Transactions/GetAll
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await _transactionRepository.GetAllAsync();
            return Ok(transactions);
        }

        // GET: Transactions/Get/5
        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var transaction = await _transactionRepository.GetByIdAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        // POST: Transactions/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] TransactionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //_logger.LogWarning("Create transaction failed due to model validation errors.");
                return BadRequest(new { success = false, errors = ModelState });
            }

            var transaction = _mapper.Map<Transaction>(model);
            //var transaction = new Transaction
            //{
            //    AccountNumber = model.AccountNumber,
            //    BeneficiaryName = model.BeneficiaryName,
            //    BankName = model.BankName,
            //    SWIFTCode = model.SWIFTCode,
            //    Amount = model.Amount
            //};

            await _transactionRepository.AddAsync(transaction);

            //_logger.LogInformation("New transaction created successfully with ID {TransactionId}.", transaction.TransactionId);
            return Ok(new { success = true, message = "Transaction created successfully", id = transaction.TransactionId });
        }

        // PUT: Transactions/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [FromBody] TransactionViewModel model)
        {
            if (!ModelState.IsValid)
            {
               // _logger.LogWarning("Edit transaction for ID {TransactionId} failed due to model validation errors.", id);
                return BadRequest(new { success = false, errors = ModelState });
            }

            var transaction = await _transactionRepository.GetByIdAsync(id);
            if (transaction == null)
            {
                //_logger.LogWarning("Edit failed: Transaction with ID {TransactionId} not found.", id);
                return NotFound();
            }

            _mapper.Map(model, transaction);

            //transaction.AccountNumber = model.AccountNumber;
            //transaction.BeneficiaryName = model.BeneficiaryName;
            //transaction.BankName = model.BankName;
            //transaction.SWIFTCode = model.SWIFTCode;
            //transaction.Amount = model.Amount;

            await _transactionRepository.UpdateAsync(transaction);

           // _logger.LogInformation("Transaction with ID {TransactionId} was updated successfully.", id);
            return Ok(new { success = true, message = "Transaction updated successfully" });
        }

        // DELETE: Transactions/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var transaction = await _transactionRepository.GetByIdAsync(id);
                if (transaction == null)
                {
                    //_logger.LogWarning("Delete failed: Transaction with ID {TransactionId} not found.", id);
                    return NotFound();
                }

                await _transactionRepository.DeleteAsync(id);

                //_logger.LogInformation("Transaction with ID {TransactionId} was deleted successfully.", id);
                return Ok(new { success = true, message = "Transaction deleted successfully" });
            }
            catch (Exception)
            {
                //_logger.LogError(ex, "An unexpected error occurred while deleting transaction with ID {TransactionId}.", id);
                return StatusCode(500, "An internal server error occurred. Please try again later.");
            }
        }

        // Additional endpoints to demonstrate repository benefits
        [HttpGet]
        public async Task<IActionResult> GetByAmountRange(int min, int max)
        {
            var transactions = await _transactionRepository.GetByAmountRangeAsync(min, max);
            return Ok(transactions);
        }

        [HttpGet]
        public async Task<IActionResult> GetByBankName(string bankName)
        {
            var transactions = await _transactionRepository.GetByBankNameAsync(bankName);
            return Ok(transactions);
        }
    }
}
