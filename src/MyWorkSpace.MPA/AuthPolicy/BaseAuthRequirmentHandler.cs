using Microsoft.AspNetCore.Authorization;
using MyWorkSpace.Domain;
using MyWorkSpace.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWorkSpace.MPA.AuthPolicy
{
    public class BaseAuthRequirmentHandler : AuthorizationHandler<BaseAuthRequirment>
    {
        private readonly LoginService _loginService;

        public BaseAuthRequirmentHandler(LoginService loginService)
        {
            _loginService = loginService;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, BaseAuthRequirment requirement)
        {
            if (context.Resource is Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext mvcContext)
            {
                string identyKey;
                if (mvcContext.HttpContext.Request.Cookies.TryGetValue(Consts.COOKIE_LOGIN_IDENTITY, out identyKey))
                {
                    var loginInfo = _loginService.GetLoginInfo(identyKey);
                    if (loginInfo != null)
                        context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
