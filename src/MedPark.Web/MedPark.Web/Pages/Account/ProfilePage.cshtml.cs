﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedPark.Web.Pages.Account
{
    [Authorize]
    public class ProfilePageModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}