using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkSpace.Domain.AggregateRoots.UserAggregateRoot
{
    public interface IUserRepository
    {
        User GetUserByAccount(string Account);
    }
}
