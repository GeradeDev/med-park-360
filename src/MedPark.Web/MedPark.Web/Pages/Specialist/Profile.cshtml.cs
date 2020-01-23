using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MedPark.Common;
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

        public SpecialistDto SpecialistDetails { get; set; }
        public PracticeDto PracticeDetails { get; set; }

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

            SpecialistDetails = await _medPracServ.GetSpecialistDetails(user.IdentityId);

            if (string.IsNullOrEmpty(SpecialistDetails.Avatar))
                SpecialistDetails.Avatar = SpecialistDetails.Email.GetAvatar();

            PracticeDetails = await _medPracServ.GetPracticeDetails(SpecialistDetails.PracticeId);

            return Page();
        }

    }
}