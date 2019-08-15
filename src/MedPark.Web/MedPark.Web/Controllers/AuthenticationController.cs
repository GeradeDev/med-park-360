using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MedPark.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        private IOptions<IdentityConfig> _configOptions { get; }

        public AuthenticationController(IOptions<IdentityConfig> configOptions)
        {
            _configOptions = configOptions;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = "/"

            }, "oidc");
        }

        public IActionResult Logout()
        {
            return new SignOutResult(new[] { "Cookies", "oidc" });
        }

        public IActionResult SignUp()
        {
            return Redirect($"{ _configOptions.Value.Authority + "/register?returnUrl=" + _configOptions.Value.ClientEndpoint } &client_id={ _configOptions.Value.ClientId }");
        }
    }
}