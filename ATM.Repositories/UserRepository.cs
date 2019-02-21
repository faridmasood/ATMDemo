using ATM.Data;
using ATM.Core.DTOs;
using ATM.Core.Entities;
using ATM.Core.Enums;
using ATM.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Repositories
{
    class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ATMDataContext context) : base(context)
        {

        }
    }
}
