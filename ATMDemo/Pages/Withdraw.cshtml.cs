using System;
using System.Collections.Generic;
using System.Linq;
using ATM.Core.Application;
using ATM.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATMDemo.Pages
{
    public class WithdrawModel : PageModel
    {
        public Guid tempUser = new Guid("EAFACF41-5A3C-49D1-A612-08D692741F4C");

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
            transactionDTOs = _transactionService.GetCardTransanctions(tempUser);
            Balance = _transactionService.GetCurrentBalance(HttpContext.User.Claims.First().Value);
        }
        public IActionResult OnPost(int value)
        {
            //var num = Request.Form["Amount"];
            //decimal d = decimal.Parse(value);
            var cardNumber = HttpContext.User.Claims.First().Value;
            var success =_withdrawService.Withdraw(cardNumber, value);
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
