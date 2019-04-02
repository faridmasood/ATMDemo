using ATM.Data;
using ATM.Core.DTOs;
using ATM.Core.Entities;
using ATM.Core.Enums;
using ATM.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ATM.Repositories
{
    class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ATMDataContext context) : base(context)
        {

        }

        public User GetUser(Guid userId)
        {
            var user = DataContext.Users.FirstOrDefault(u => u.Id == userId);
            return user;
        }
    }
}
