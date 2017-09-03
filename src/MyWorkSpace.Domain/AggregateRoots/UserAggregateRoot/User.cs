using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkSpace.Domain.AggregateRoots.UserAggregateRoot
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsMatch(string passWord)
        {
            return Password.Equals(passWord);
        }
    }
}
