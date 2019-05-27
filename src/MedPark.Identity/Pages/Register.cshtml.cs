using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using MedPark.Common.RabbitMq;
using MedPark.Identity.Messages.Events;

namespace MedPark.Identity.Pages
{
    public class RegisterModel : BasePageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IBusPublisher _busPublisher;

        public string ReturnURL { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string FirstName { get; set; } = "";
        public IHttpClientFactory _httpClient { get; }

        public RegisterModel(IBusPublisher busPublisher, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IClientStore clientStore, IIdentityServerInteractionService interaction, IHttpClientFactory httpClient)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _httpClient = httpClient;
            _clientStore = clientStore;
            _busPublisher = busPublisher;
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
                var user = new ApplicationUser { UserName = Request.Form["Username"], Email = Request.Form["Username"], IsAdmin = false, FirstName = Request.Form["FirstName"] };
                var result = await _userManager.CreateAsync(user, Request.Form["userpassword"]);

                if (result.Succeeded)
                {
                    await _userManager.AddClaimsAsync(user, new Claim[] { new Claim("firstName", user.FirstName), new Claim("identityid", user.IdentityId.ToString()) });

                    //Publish message to RabbitMq
                    await _busPublisher.PublishAsync(new SignedUp(user.IdentityId, Request.Form["FirstName"], "", Request.Form["Username"]), CorrelationContext.Empty);
                    
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

    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string Email { get; set; }
        public string Mobile { get;  set; }
        public string Avatar { get; set; }
    }
}