using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using MedPark.Identity.Models.Consent;
using MedPark.Identity.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedPark.Identity.Pages
{
    public class ConsentModel : PageModel
    {
        private readonly IClientStore _clientStore;
        private readonly IResourceStore _resourceStore;
        private readonly IIdentityServerInteractionService _interaction;
        private ConsentService _consentServ;
        
        public ConsentViewModel _viewModel;

        public ConsentModel(IIdentityServerInteractionService interaction, IClientStore clientStore, IResourceStore resourceStore)
        {
            _interaction = interaction;
            _clientStore = clientStore;
            _resourceStore = resourceStore;

            _consentServ = new ConsentService(_interaction, _clientStore, _resourceStore);
        }

        public async Task<IActionResult> OnGet(string returnUrl)
        {
            _viewModel = await _consentServ.BuildViewModelAsync(returnUrl);

            if (_viewModel != null)
            {
                _viewModel.ReturnUrl = returnUrl;

                return Page();
            }

            return Page();
        }


        public async Task<IActionResult> OnPost(ConsentInputModel model)
        {
            if (model != null)
            {
                var result = await _consentServ.ProcessConsent(model);

                if (result.IsRedirect)
                {
                    return Redirect(result.RedirectUri);
                }

                if (result.HasValidationError)
                {
                    ModelState.AddModelError("", result.ValidationError);
                }

                if (result.ShowView)
                {
                    _viewModel = result.ViewModel;

                    return Page();
                }
            }

            return await OnGet(model.ReturnUrl);
        }
    }
}