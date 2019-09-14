using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MedPark.Common;
using MedPark.Common.API;
using MedPark.Web.Dto;
using MedPark.Web.Services;
using MedPark.Web.Utils.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace MedPark.Web.Pages.Specialist
{
    public class ProfileModel : BasePageModel
    {
        private IMedParcticeService _medPracServ { get; }

        Guid LoggedInGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }

        public string PracticeName { get; set; }
        public string PracticeEmail { get; set; }
        public string PracticeTel { get; set; }

        public ProfileModel(IHttpClientFactory httpClient, IIdentityParser<ApplicationUser> appUserParser, IMedParcticeService medPracServ) : base(httpClient, appUserParser)
        {
            _medPracServ = medPracServ;
        }

        public async Task<IActionResult> OnGet()
        {
            var user = _appUserParser.Parse(HttpContext.User);

            SpecialistDto specialist = await _medPracServ.GetSpecialistDetails(user.IdentityId);

            FirstName = specialist.FirstName;
            LastName = specialist.Surname;
            Email = specialist.Email;
            Avatar = specialist.Avatar;
            Mobile = specialist.Cellphone;

            if (string.IsNullOrEmpty(Avatar))
                Avatar = Email.GetAvatar();

            PracticeDto practice = await _medPracServ.GetPracticeDetails(specialist.PracticeId);

            PracticeName = practice.PracticeName;
            PracticeEmail = practice.Email;
            PracticeTel = practice.TelephonePrimary;

            return Page();
        }

    }
}