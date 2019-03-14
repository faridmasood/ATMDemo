using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ATM.Core.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATMDemo.Pages
{
    public class ChangePinModel : PageModel
    {
        private ICardService _cardService;
        [TempData] public string StatusMessage { get; set; }

        public ChangePinModel(ICardService cardService)
        {
            _cardService = cardService;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost(string oldPin, string newPin, string rnewPin)
        {
            var datainfo = HttpContext.User.Claims;
            var _card = datainfo.First().Value;
            var _oldPin = datainfo.LastOrDefault().Value;

            //var _old = Request.Form["oldPin"];
            //var _new = Request.Form["newPin"];
            //var _rnew = Request.Form["rnewPin"];
            //if (_new == _rnew)
            //    _cardService.ChangePin(_card, _old, _new);
            if (newPin == rnewPin && oldPin == _oldPin)
            {
                _cardService.ChangePin(_card, oldPin, newPin);
                return Page();
            }
            StatusMessage = "Pin code are not similar";
            return Page();
        }
    }
}