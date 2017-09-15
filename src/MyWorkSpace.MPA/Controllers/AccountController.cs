using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWorkSpace.Domain.AggregateRoots.UserAggregateRoot;
using MyWorkSpace.MPA.Models;
using Microsoft.AspNetCore.Authorization;
using MyWorkSpace.Domain.Service;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWorkSpace.MPA.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly LoginService _loginService;

        public AccountController(IUserRepository userRepository, LoginService loginService)
        {
            _userRepository = userRepository;
            _loginService = loginService;
        }

        // GET: Account
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountModel loginModel)
        {
            if(_loginService.SignOn(loginModel.Account, loginModel.Password))
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
