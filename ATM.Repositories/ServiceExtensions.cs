using ATM.Core.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ATM.Repositories
{
    public static class ServiceExtensions
    {
        public static void InjectDataRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICardRepository, CardRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
