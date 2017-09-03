using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWorkSpace.MPA.Models
{
    public class AccountModel
    {
        public string Account { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ErrMsg { get; set; }
    }
}