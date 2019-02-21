using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ATM.Core.Application;
using ATMDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATMDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IAuthService _authService;
        private readonly ILoginService _loginService;

        public IndexModel(IAuthService authService, ILoginService loginService)
        {
            _authService = authService;
            _loginService = loginService;
        }

        [Required]
        [BindProperty]
        public string cardNumber { get; set; }

        [Required]
        [BindProperty]
        [DataType(DataType.Password)]
        public string pinCode { get; set; }

        [TempData] public string StatusMessage { get; set; }
        public IActionResult OnGet()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToPage("Dashboard");
            }

            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            ViewData["CardNember"] = cardNumber;
            ViewData["PinCode"] = pinCode;
            var pathBase = HttpContext.Request.PathBase;
            if (ModelState.IsValid)
            {
                var success = _authService.Authorize(cardNumber, pinCode);
                if (success)
                {
                    await _loginService.LoginAsync(cardNumber, pinCode);
                    return RedirectToPage("Dashboard");
                }
            }

            StatusMessage = "Loging failed.";

            return Page();
        }
    }
}
