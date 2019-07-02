using MedPark.Web.Utils.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MedPark.Web.Pages
{
    public class BasePageModel : PageModel
    {
        public IIdentityParser<ApplicationUser> _appUserParser;
        public IHttpClientFactory _httpClient;



        public BasePageModel(IHttpClientFactory httpClient, IIdentityParser<ApplicationUser> appUserParser)
        {
            _httpClient = httpClient;
            _appUserParser = appUserParser;
        }
    }
}
