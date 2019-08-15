using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Events;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using MedPark.Identity.Models;
using MedPark.Identity.Utils;
using MedPark.Identity.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedPark.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;


        public bool AllowRememberLogin { get; set; }
        public bool EnableLocalLogin { get; set; } = true;
        public IEnumerable<ExternalProvider> ExternalProviders { get; set; }
        public IEnumerable<ExternalProvider> VisibleExternalProviders => ExternalProviders.Where(x => !String.IsNullOrWhiteSpace(x.DisplayName));
        public bool IsExternalLoginOnly => EnableLocalLogin == false && ExternalProviders?.Count() == 1;
        public string ExternalLoginScheme => IsExternalLoginOnly ? ExternalProviders?.SingleOrDefault()?.AuthenticationScheme : null;
        
        public string Username { get; set; }
        public string Password { get; set; }
        public bool RememberLogin { get; set; }
        public string ReturnUrl { get; set; }
        public string Email { get; set; }
        public string ClientName { get; set; }
        public string ReturnCleintUrl { get; set; }



        public LoginModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IIdentityServerInteractionService interaction, IClientStore clientStore, IAuthenticationSchemeProvider schemeProvider, IEventService events)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _clientStore = clientStore;
        }

        public async Task<IActionResult> OnGet(string returnUrl)
        {
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);

            ReturnCleintUrl = context.RedirectUri.Replace("signin-oidc", "");

            if (context?.IdP != null)
            {
                // if IdP is passed, then bypass showing the login screen
                return ExternalLogin(context.IdP, returnUrl);
            }

            await BuildLoginViewModelAsync(returnUrl, context);

            if (EnableLocalLogin == false && ExternalProviders.Count() == 1)
            {
                // only one option for logging in
                return ExternalLogin(ExternalProviders.First().AuthenticationScheme, returnUrl);
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(string returnUrl)
        {
            var context = await _interaction.GetAuthorizationContextAsync(returnUrl);

            if (Request.Form["Login"].Count > 0)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Request.Form["Username"], Request.Form["Password"], true, false);

                if (result.Succeeded)
                {
                    return Redirect(context.RedirectUri);
                }
                if (result.RequiresTwoFactor)
                {
                    //return RedirectToAction(nameof(SendCode), new { ReturnUrl = returnUrl, RememberMe = model.RememberLogin });
                }
                if (result.IsLockedOut)
                {
                    //return View("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }
            else
            {
                //Login canceled
                return Redirect(context.RedirectUri.Replace("signin-oidc", ""));
            }

            return await OnGet(returnUrl);
        }





        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }

        private async Task BuildLoginViewModelAsync(string returnUrl, AuthorizationRequest context)
        {
            var loginProviders = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            var providers = loginProviders
                .Where(x => x.DisplayName != null)
                .Select(x => new ExternalProvider
                {
                    DisplayName = x.DisplayName,
                    AuthenticationScheme = x.Name
                });

            var allowLocal = true;

            if (context?.ClientId != null)
            {
                var client = await _clientStore.FindEnabledClientByIdAsync(context.ClientId);
                if (client != null)
                {
                    ClientName = client.ClientName;

                    allowLocal = client.EnableLocalLogin;

                    if (client.IdentityProviderRestrictions != null && client.IdentityProviderRestrictions.Any())
                    {
                        providers = providers.Where(provider => client.IdentityProviderRestrictions.Contains(provider.AuthenticationScheme));
                    }
                }
            }

            EnableLocalLogin = allowLocal;
            ReturnUrl = returnUrl;
            Email = context?.LoginHint;
            ExternalProviders = providers.ToArray();
        }
    }
}