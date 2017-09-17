using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWorkSpace.Domain.AggregateRoots.UserAggregateRoot;
using MyWorkSpace.MPA.Models;
using Microsoft.AspNetCore.Authorization;
using MyWorkSpace.Domain.Service;
using MyWorkSpace.Domain;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWorkSpace.MPA.Controllers
{
    
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
            var identyKey = _loginService.SignOn(loginModel.Account, loginModel.Password);
            if (identyKey != null)
            {
                Response.Cookies.Append(Consts.COOKIE_LOGIN_IDENTITY, identyKey);
                return RedirectToAction("Index", "Default", new { Area = "Dashbord" });
            }

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
