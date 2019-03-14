using System;
using System.Collections.Generic;
using System.Linq;
using ATM.Core.Entities;
using ATM.Core.Enums;
using System.Text;
using ATM.Core.Framework.Encryption;

namespace ATM.Data
{
    public class AtmDbInitializar
    {
        public static void AutomateMigrations(ATMDataContext context)
        {
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
        }
        public static void Initialize(ATMDataContext context, IHashProvider hashProvider)
        {
            if (!context.Users.Any())
            {
                var users = new List<User>
                  {
                    new User
                    {
                        Name = "John Carlos",  MobileNumber= 0723263400
                    },
                     new User
                     {
                         Name = "Tin Carlos", MobileNumber= 0723263401
                    },
                        new User
                    {
                         Name = "Dell Martin",  MobileNumber= 0723263402
                    }

                   };
                context.Users.AddRange(users);
                context.SaveChanges();
            }


            if (!context.Cards.Any())
            {
                var Id1 = context.Users.First().Id;
                var Id2 = context.Users.Skip(1).FirstOrDefault().Id;
                var Id3 = context.Users.Skip(2).FirstOrDefault().Id;

                var cards = new List<Card>
                {
                    new Card
                    {
                        Limit= 5000 , ExpiryDate = new DateTime().AddYears(2), CSV =123, PinCode= hashProvider.GetHash("4321"),
                        User = context.Users.FirstOrDefault(u=>u.Id==Id1), Balance = 4000,
                        Type = CardType.Debit, CardNumber="1234567890"
                    },
                    new Card
                    {
                        Limit= 5000 ,ExpiryDate = new DateTime().AddYears(3), CSV =456, PinCode= hashProvider.GetHash("1234"),
                        User = context.Users.FirstOrDefault(u=>u.Id==Id2),Balance = 4500,
                        Type = CardType.Debit, CardNumber="1234567891"
                    },
                    new Card
                    {
                         Limit= 5000 , ExpiryDate = new DateTime().AddYears(4), CSV =789, PinCode=hashProvider.GetHash("5678"),
                        User =context.Users.FirstOrDefault(u=>u.Id==Id3),Balance = 4600,
                        Type = CardType.Debit, CardNumber="1234567892"
                    },

                };
                context.Cards.AddRange(cards);
                context.SaveChanges();
            }

            if (!context.Transactions.Any())
            {
                var transactions = new List<Transaction>
                {
                    new Transaction{
                         Amount= 500,
                        Balance = 4500, Dated= new DateTime().AddDays(3),
                        CardId = context.Cards.FirstOrDefault().Id
                    },
                    new Transaction{
                         Amount= 400,
                        Balance = 5500, Dated= new DateTime().AddDays(13),
                        CardId = context.Cards.FirstOrDefault().Id
                    },
                    new Transaction{
                         Amount= 100,
                        Balance = 5500, Dated= new DateTime().AddDays(5),
                        CardId = context.Cards.FirstOrDefault().Id
                    },

                };
                context.Transactions.AddRange(transactions);
                context.SaveChanges();
            }
        }


    }

}

