using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATMDemo.Services
{
    public interface ILoginService
    {
        Task LoginAsync(string cardNumber, string pin);
        Task Logout();
    }
}
