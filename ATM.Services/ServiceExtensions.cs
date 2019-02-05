using ATM.Interfaces.Application;
using Microsoft.Extensions.DependencyInjection;

namespace ATM.Services
{
    public static class ServiceExtensions
    {
        public static void InjectApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IWithdrawService, WithdrawService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<ICardService, CardService>();
            services.AddTransient<IDepositService, DepositService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IWithdrawValidationService, WithdrawValidationService>();
        }
    }
}
