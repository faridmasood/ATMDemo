using Microsoft.EntityFrameworkCore;

namespace ATM.Data
{
    public class ATMDataContext : DbContext
    {
        public ATMDataContext(DbContextOptions<ATMDataContext> options) : base(options)
        {
        }
    }
}
