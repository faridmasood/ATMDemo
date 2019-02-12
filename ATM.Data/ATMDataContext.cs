using ATM.DataObjects.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace ATM.Data
{
    public class ATMDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public ATMDataContext(DbContextOptions<ATMDataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<User>().HasData(
            //    new User() { Name = "Ali", MobileNumber = 0723263414, Created = new DateTime(), Updated = new DateTime(100), UserId = new Guid() });

            base.OnModelCreating(builder);
        }
    }
}
