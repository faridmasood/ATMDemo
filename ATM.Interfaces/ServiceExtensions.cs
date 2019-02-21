using ATM.Core.Application;
using ATM.Core.Framework.Encryption;
using Microsoft.Extensions.DependencyInjection;

namespace ATM.Core
{
    public static class ServiceExtensions
    {
        public static void InjectCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IHashProvider, HashProvider>();
        }
    }
}
