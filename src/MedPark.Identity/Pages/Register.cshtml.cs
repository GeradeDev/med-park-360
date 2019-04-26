using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedPark.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedPark.Identity.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public string ReturnURL { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";

        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnURL = returnUrl;
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

                    //return Redirect(returnurl);
                }
            }

            return Page();
        }
    }
}