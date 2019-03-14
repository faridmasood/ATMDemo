using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATM.Core.Application;
using ATM.Core.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATMDemo.Pages
{
    public class WithdrawModel : PageModel
    {
        public Guid tempUser = new Guid("EAFACF41-5A3C-49D1-A612-08D692741F4C");

        private readonly ITransactionService _transactionService;
        public string Message { get; set; }

        public IList<TransactionDTO> transactionDTOs = new List<TransactionDTO>();
        public WithdrawModel(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        public void OnGet()
        {
            Message = "Your Current Balance is : ";

            transactionDTOs = _transactionService.GetCardTransanctions(tempUser).ToList();
        }
    }
}
