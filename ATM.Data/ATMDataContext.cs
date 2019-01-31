using ATM.DataObjects.Entities;
using Microsoft.EntityFrameworkCore;

namespace ATM.Data
{
    public class ATMDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<BaseEntity> BaseEntities { get; set; }  

        public ATMDataContext(DbContextOptions<ATMDataContext> options) : base(options)
        {
        }
    }
}
