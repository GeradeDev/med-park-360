using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Extensions;
using IdentityServer4.Services;
using MedPark.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedPark.Identity.Pages
{
    public class LogoutModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IPersistedGrantService _persistedGrantService;

        public static bool ShowLogoutPrompt = false;
        public static bool AutomaticRedirectAfterSignOut = true;

        public string LogoutId { get; set; } = "";
        public string PostLogoutRedirectUri { get; set; } = "";
        public string ClientName { get; set; } = "";
        public string SignOutIframeUrl { get; set; } = "";


        public LogoutModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IIdentityServerInteractionService interaction, IPersistedGrantService persistedGrantService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _persistedGrantService = persistedGrantService;
        }

        public async Task<IActionResult> OnGet(string logoutId)
        {
            LogoutId = logoutId;

            if (User.Identity.IsAuthenticated)
            {
                var context = await _interaction.GetLogoutContextAsync(logoutId);

                ClientName = context?.ClientId;

                if (context?.ShowSignoutPrompt == false)
                {
                    await OnPost(logoutId);
                }
            }

            return Page();
        }


        public async Task<IActionResult> OnPost(string logoutId)
        {
            LogoutId = logoutId;

            var idProvider = User?.FindFirst(JwtClaimTypes.IdentityProvider)?.Value;
            var subjectId = HttpContext.User.Identity.GetSubjectId();

            if (idProvider != null && idProvider != IdentityServerConstants.LocalIdentityProvider)
            {
                if (logoutId is null)
                {
                    // if there's no current logout context, we need to create one
                    // this captures necessary info from the current logged in user
                    // before we signout and redirect away to the external IdP for signout
                    LogoutId = await _interaction.CreateLogoutContextAsync();
                }

                string url = "/Logout/Logout?logoutId=" + logoutId;

                try
                {
                    await _signInManager.SignOutAsync();
                    // await HttpContext.Authentication.SignOutAsync(idp, new AuthenticationProperties { RedirectUri = url });
                }
                catch (NotSupportedException)
                {
                }
            }

            // delete authentication cookie
            await _signInManager.SignOutAsync();

            // set this so UI rendering sees an anonymous user
            HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());

            // get context information (client name, post logout redirect URI and iframe for federated signout)
            var logout = await _interaction.GetLogoutContextAsync(LogoutId);

            PostLogoutRedirectUri = logout?.PostLogoutRedirectUri;
            ClientName = logout?.ClientId;
            SignOutIframeUrl = logout?.SignOutIFrameUrl;

            //_clientSelector.SelectedClient = logout?.ClientId;

            await _persistedGrantService.RemoveAllGrantsAsync(subjectId, logout?.ClientId);

            //return View($"~/Themes/{logout?.ClientId}/Account/LoggedOut.cshtml", vm);

            return Page();
        }
    }
}