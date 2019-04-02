using ATM.Core.Entities;
using System;

namespace ATM.Core.Data
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUser(Guid userId);
    }
}
