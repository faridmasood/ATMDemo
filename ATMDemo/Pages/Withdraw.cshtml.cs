using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM.Core.Application;
using ATM.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATMDemo.Pages
{
    public class WithdrawModel : PageModel
    {
        private readonly IWithdrawService _withdrawService;
        private readonly ITransactionService _transactionService;
        [TempData] public string Message { get; set; }
        public decimal Balance { get; set; }

        public ICollection<TransactionDTO> transactionDTOs = new List<TransactionDTO>();
        public WithdrawModel(IWithdrawService withdrawService, ITransactionService transactionService)
        {
            _withdrawService = withdrawService;
            _transactionService = transactionService;
        }
        public void OnGet()
        {
            Balance = _transactionService.GetCurrentBalance(HttpContext.User.Claims.First().Value);
        }
        public async Task<IActionResult> OnPostAsync(int value)
        {
            //var num = Request.Form["Amount"];
            //decimal d = decimal.Parse(value);
            var cardNumber = HttpContext.User.Claims.First().Value;
            var success = await _withdrawService.WithdrawAsync(cardNumber, value);
            if (success)
            {
                Message = "Amount is with draw from your account";
                return Page();
            }
            Message = "Amount could not with draw from your account";
            return Page();

        }
    }
}
