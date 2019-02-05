using ATM.Data;
using ATM.DataObjects.DTOs;
using ATM.DataObjects.Entities;
using ATM.DataObjects.Enums;
using ATM.Interfaces.Data;
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
