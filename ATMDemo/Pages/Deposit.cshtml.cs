using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM.Core.Application;
using ATM.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATMDemo.Pages
{
    [Authorize]
    public class DepositModel : PageModel
    {
        private ITransactionService _transactionService;
        private IDepositService _depositService;
        private ICardService _cardService;
        public decimal Balance { get; set; }
        [TempData] public string Message { get; set; }

        public ICollection<TransactionDTO> transactionDTOs = new List<TransactionDTO>();
           
        public DepositModel(
            ITransactionService transactionService, 
            IDepositService depositService, 
            ICardService cardService)
        {
            _transactionService = transactionService;
            _depositService = depositService;
            _cardService = cardService;

        }
        public void OnGet()
        {
            //Balance = _transactionService.GetCurrentBalance(HttpContext.User.Claims.First().Value);
            Balance = _cardService.GetCardBalance(HttpContext.User.Claims.First().Value);
        }

        public async Task<IActionResult> OnPostAsync(int value)
        {
            var cardNum = HttpContext.User.Claims.First().Value;
            //_transactionService.AddTransaction(cardNum, value, DateTime.Now, TransactionType.Deposit);
            var success = await _depositService.DepositAsync(cardNum, value);
            if (success)
            {
                Message = "Amount is deposit to your account";
                Balance = _cardService.GetCardBalance(HttpContext.User.Claims.First().Value);
                return Page();
            }
            Message = "Amount could not deposit to your account";
            return Page();
        }
    }
}