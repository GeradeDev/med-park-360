using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedPark.Identity.Pages.Home
{
    public class ErrorModel : PageModel
    {
        private readonly IIdentityServerInteractionService _interaction;

        public ErrorMessage Error { get; set; }


        public ErrorModel(IIdentityServerInteractionService interaction)
        {
            _interaction = interaction;
        }

        public async Task<IActionResult> OnGet(string errorId)
        {
            var message = await _interaction.GetErrorContextAsync(errorId);

            if (message != null)
            {
                Error = message;
            }

            return Page();
        }
    }
}