using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using MedPark.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;

namespace MedPark.Identity.Pages
{
    public class RegisterModel : BasePageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;

        public string ReturnURL { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";


        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IClientStore clientStore, IIdentityServerInteractionService interaction)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _clientStore = clientStore;
        }

        public async Task<IActionResult> OnGet(string returnUrl = null)
        {
            ReturnURL = returnUrl;

            return Page();
        }

        public async Task<IActionResult> OnPost(string returnurl)
        {
            if (returnurl != null)
            {
                var user = new ApplicationUser {  UserName = Request.Form["Username"], Email = Request.Form["Username"], IsAdmin = false };
                var result = await _userManager.CreateAsync(user, Request.Form["userpassword"]);

                if (result.Succeeded)
                {
                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                    // Send an email with this link
                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                    //    $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    //_logger.LogInformation(3, "User created a new account with password.");

                    return Redirect(returnurl);
                }
            }

            return Page();
        }


        
    }
}