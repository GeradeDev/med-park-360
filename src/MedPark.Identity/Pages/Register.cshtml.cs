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
using MedPark.Identity.Services;
using MedPark.Identity.Models.MedicalPracticeService;

namespace MedPark.Identity.Pages
{
    public class RegisterModel : BasePageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IBusPublisher _busPublisher;


        private readonly IMedicalPracticeService _specialistService;

        public string ReturnURL { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Role { get; set; } = "";
        public Int32 SpecialistOTP { get; set; }

        public IHttpClientFactory _httpClient { get; }

        public RegisterModel(IMedicalPracticeService specialistService, IBusPublisher busPublisher, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IClientStore clientStore, IIdentityServerInteractionService interaction, IHttpClientFactory httpClient)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _httpClient = httpClient;
            _clientStore = clientStore;
            _busPublisher = busPublisher;
            _specialistService = specialistService;
        }

        public async Task<IActionResult> OnGet(string returnUrl = null)
        {
            ReturnURL = returnUrl;

            return Page();
        }

        public async Task<IActionResult> OnPost(string returnurl)
        {
            if (returnurl != null && Request.Form["Register"].Count > 0)
            {
                PendingRegistrationDto otpDetails = new PendingRegistrationDto();
                ApplicationUser user;

                //Validate if OTP is valid before registering specilist user
                if (Request.Form["Role"] == "Specialist")
                {
                    string otp = Request.Form["Otp"].ToString();

                    otpDetails = await _specialistService.GetRegistrationOTPDetails(otp);

                    if (otpDetails == null)
                    {
                        ModelState.AddModelError("invalis_registration_otp", "The OTP entered is not valid. Please try again.");
                        ReturnURL = returnurl;

                        return Page();
                    }
                    else
                        user = new ApplicationUser { UserName = otpDetails.Email, Email = otpDetails.Email, IsAdmin = false, FirstName = otpDetails.FirstName };
                }
                else
                    user = new ApplicationUser { UserName = Request.Form["Username"], Email = Request.Form["Username"], IsAdmin = false, FirstName = Request.Form["FirstName"] };
                
                var result = await _userManager.CreateAsync(user, Request.Form["userpassword"]);

                if (result.Succeeded)
                {
                    await _userManager.AddClaimsAsync(user, new Claim[] { new Claim("firstName", user.FirstName), new Claim("identityid", user.IdentityId.ToString()) });
                    
                    if (Request.Form["Role"] == "Patient")
                    {
                        await _userManager.AddClaimsAsync(user, new Claim[] { new Claim("accounttype", "patient") });
                        var newSignUpEvent = new SignedUp(user.IdentityId, Request.Form["FirstName"], Request.Form["LastName"], Request.Form["Username"], Role);

                        //Publish message to RabbitMq
                        await _busPublisher.PublishAsync(newSignUpEvent, CorrelationContext.Empty);
                    }
                    else
                    {
                        await _userManager.AddClaimsAsync(user, new Claim[] { new Claim("accounttype", "specialist") });
                        var newSignUpEvent = new SpecialistSignedUp(user.IdentityId, otpDetails.FirstName, otpDetails.LastName, otpDetails.Email, otpDetails.PracticeId, otpDetails.IsAdmin);

                        //Publish message to RabbitMq
                        await _busPublisher.PublishAsync(newSignUpEvent, CorrelationContext.Empty);
                    }
                    
                    //// For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=532713
                    //// Send an email with this link
                    ////var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    ////var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                    ////await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                    ////    $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");
                    //await _signInManager.PasswordSignInAsync(Request.Form["Username"], Request.Form["userpassword"], true, false);

                    ////_logger.LogInformation(3, "User created a new account with password.");

                    return Redirect(returnurl);
                }
                else
                {
                    result.Errors.ToList().ForEach(e =>
                    {
                        ModelState.AddModelError(e.Code, e.Description);
                    });

                    ReturnURL = returnurl;
                }
            }
            else
            {
                //Registration canceled
                return Redirect(returnurl);
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