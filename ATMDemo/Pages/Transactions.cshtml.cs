using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using ATM.Core.Application;
using ATM.Core.DTOs;
using ATM.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATMDemo.Pages
{
    [Authorize]
    public class TransactionsModel : PageModel
    {
        public Guid tempUser = new Guid("EAFACF41-5A3C-49D1-A612-08D692741F4C");

        private readonly ITransactionService _transactionService;

        public ICollection<TransactionDTO> transactionDTOs = new List<TransactionDTO>();
        public TransactionsModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        public void OnGet()
        {
            transactionDTOs = _transactionService.GetCardTransanctions(tempUser);
            //return transactions;
        }
        public IActionResult OnPost(Guid UserId, int value)
        {

            var transaction = _transactionService.GetCardTransanctions(UserId);
            return Page();

        }
    }
}