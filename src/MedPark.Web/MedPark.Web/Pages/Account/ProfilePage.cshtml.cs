using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MedPark.Common;
using MedPark.Web.Dto;
using MedPark.Web.Models;
using MedPark.Web.Services;
using MedPark.Web.Utils.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace MedPark.Web.Pages.Account
{
    [Authorize]
    public class ProfilePageModel : PageModel
    {
        private readonly IIdentityParser<ApplicationUser> _appUserParser;
        private readonly ICustomerService _custoemrServ;

        Guid LoggedInGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }


        public ProfilePageModel(IIdentityParser<ApplicationUser> appUserParser, ICustomerService custoemrServ)
        {
            _appUserParser = appUserParser;
            _custoemrServ = custoemrServ;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = _appUserParser.Parse(HttpContext.User);

            Customer c = await _custoemrServ.GetCustomer(user.IdentityId);

            FirstName = c.FirstName;
            LastName = c.LastName;
            Mobile = c.Mobile;
            Birthday = c.Birthday;
            Email = c.Email;
            Avatar = c.Avatar;

            if (string.IsNullOrEmpty(Avatar))
                Avatar = Email.GetAvatar();

            return Page();
        }
    }
}