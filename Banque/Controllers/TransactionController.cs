using Banque.Services;
using Microsoft.AspNetCore.Mvc;

namespace Banque.Controllers
{
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("debit")]
        public IActionResult Debit(int accountId, decimal amount)
        {
            try
            {
                _transactionService.Debit(accountId, amount);
                return Ok("Debit operation successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("credit")]
        public IActionResult Credit(int accountId, decimal amount)
        {
            try
            {
                _transactionService.Credit(accountId, amount);
                return Ok("Credit operation successful");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
