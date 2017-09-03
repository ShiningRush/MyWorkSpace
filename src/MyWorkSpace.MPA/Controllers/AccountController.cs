using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWorkSpace.Domain.AggregateRoots.UserAggregateRoot;
using MyWorkSpace.MPA.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWorkSpace.MPA.Controllers
{
    public class AccountController : Controller
    {
        private IUserRepository _userRepository = null;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: Account
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountModel loginModel)
        {
            var matchedUser = _userRepository.GetUserByAccount(loginModel.Account);
            var isCorrectUser = matchedUser?.IsMatch(loginModel.Password);

            if(isCorrectUser.HasValue && isCorrectUser.Value)
                return RedirectToAction("Index", "Default", new { Area = "Dashbord" });
            loginModel.ErrMsg = "帐号密码不匹配，请确认";

            return View(loginModel);
        }

        public IActionResult Logout()
        {
            //var inputDto = new AccountInputDto();
            //var result = _accountService.Logout();
            return View("Login");
        }
    }
}
