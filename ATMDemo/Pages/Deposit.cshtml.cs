using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using ATM.Core.Application;
using ATM.Core.DTOs;
using ATM.Core.Enums;
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
        public decimal Balance { get; set; }
        [TempData] public string Message { get; set; }

        public ICollection<TransactionDTO> transactionDTOs = new List<TransactionDTO>();
        // temp user
        public Guid tempUser = new Guid("EAFACF41-5A3C-49D1-A612-08D692741F4C");
        
        public DepositModel(ITransactionService transactionService, IDepositService depositService)
        {
            _transactionService = transactionService;
            _depositService = depositService;

        }
        public void OnGet()
        {
            transactionDTOs = _transactionService.GetCardTransanctions(tempUser);
            Balance = _transactionService.GetCurrentBalance(HttpContext.User.Claims.First().Value);
        }

        public IActionResult OnPost(int value)
        {
            var cardNum = HttpContext.User.Claims.First().Value;
            _depositService.Deposit(cardNum, value);
            return Page();
        }
    }
}