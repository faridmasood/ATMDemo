using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATMDemo.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ATMDemo.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly ILoginService _loginService;

        public LogoutModel(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public void OnGet()
        {
            _loginService.Logout();
        }

        public void OnPost()
        {
            _loginService.Logout();
        }
    }
}