using System;
using System.Collections.Generic;
using System.Linq;
using ATM.Core.Application;
using ATM.Core.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATMDemo.Pages
{
    [Authorize]
    public class TransactionsModel : PageModel
    {
        private readonly ITransactionService _transactionService;
        private readonly ICardService _cardService;
        public decimal Balance { get; set; }

        public ICollection<TransactionDTO> transactionDTOs = new List<TransactionDTO>();
        public TransactionsModel(ITransactionService transactionService, ICardService cardService)
        {
            _transactionService = transactionService;
            _cardService = cardService;
        }
        public void OnGet()
        {
            var cardId = _cardService.GetCardId(HttpContext.User.Claims.First().Value);
            Balance = _transactionService.GetCurrentBalance(HttpContext.User.Claims.First().Value);
            transactionDTOs = _transactionService.GetCardTransanctions(cardId);
        }
        public IActionResult OnPost(Guid UserId, int value)
        {
            transactionDTOs = _transactionService.GetCardTransanctions(UserId);
            return Page();
        }
    }
}