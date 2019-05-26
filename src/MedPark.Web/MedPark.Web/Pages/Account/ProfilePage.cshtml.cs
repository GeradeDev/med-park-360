using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MedPark.Common;
using MedPark.Common.API;
using MedPark.Web.Models;
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
        private readonly IHttpClientFactory _httpClient;

        Guid LoggedInGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }


        public ProfilePageModel(IHttpClientFactory httpClient, IIdentityParser<ApplicationUser> appUserParser)
        {
            _httpClient = httpClient;
            _appUserParser = appUserParser;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = _appUserParser.Parse(HttpContext.User);

            CustomerDto c = JsonConvert.DeserializeObject<CustomerDto>(await new CustomersService(_httpClient).GetDetails(user.IdentityId));

            FirstName = c.FirstName;
            LastName = c.LastName;
            Mobile = c.Mobile;
            Birthday = c.Birthday;
            Email = "GeradeGeldenhuys@Gmail.com";
            Avatar = c.Avatar;

            if (string.IsNullOrEmpty(Avatar))
                Avatar = Globals.GravatarEndpoint + Email.ToLower().CalculateMD5Hash();

            return Page();
        }
    }

    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Avatar { get; set; }
    }
}