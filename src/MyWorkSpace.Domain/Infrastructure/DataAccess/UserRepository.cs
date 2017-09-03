using MyWorkSpace.Domain.AggregateRoots.UserAggregateRoot;
using System.Linq;
using MyWorkSpace.Domain.INeeds.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkSpace.Domain.Infrastructure.DataAccess
{
    public class UserRepository : IUserRepository
    {

        public UserRepository()
        {
        }

        public User GetUserByAccount(string Account)
        {
            using (var dbContext = new MyWorkSpaceDbContext())
            {
                var matchedUser = dbContext.Set<User>().Where(p => p.UserName == Account).FirstOrDefault();
                return matchedUser;
            }
        }
    }
}
