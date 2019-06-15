using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MedPark.Common;
using MedPark.Common.API;
using MedPark.Web.Dto;
using MedPark.Web.Utils.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace MedPark.Web.Pages.Specialist
{
    public class ProfileModel : PageModel
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

        public ProfileModel(IHttpClientFactory httpClient, IIdentityParser<ApplicationUser> appUserParser)
        {
            _httpClient = httpClient;
            _appUserParser = appUserParser;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = _appUserParser.Parse(HttpContext.User);

            var specialist = JsonConvert.DeserializeObject<SpecialistDto>(await new SpecilaistService(_httpClient).GetDetails(user.IdentityId));

            BuildPageModel(specialist);

            return Page();
        }

        public void BuildPageModel(SpecialistDto dto)
        {
            LoggedInGuid = _appUserParser.Parse(HttpContext.User).IdentityId;
            FirstName = dto.FirstName;
            LastName = dto.Surname;
            Email = dto.Email;
            Mobile = dto.Cellphone;
            Avatar = dto.Avatar;

            if (string.IsNullOrEmpty(Avatar))
                Avatar = Email.GetAvatar();
        }
    }
}