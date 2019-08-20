using IdentityServer4.Stores;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Common.Types;
using MedPark.Identity.Messages.Events;
using MedPark.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Identity.Handlers.Customers
{
    public class CustomerDetailsUpatedHandler : IEventHandler<CustomerDetailsUpated>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IClientStore _clientStore;
        private ApplicationUserContext _appUserContext { get; }

        public CustomerDetailsUpatedHandler(UserManager<ApplicationUser> userManager, IClientStore clientStore, ApplicationUserContext appUserContext)
        {
            _userManager = userManager;
            _clientStore = clientStore;
            _appUserContext = appUserContext;
        }

        public async Task HandleAsync(CustomerDetailsUpated @event, ICorrelationContext context)
        {
            var user = _appUserContext.Users.Where(x => x.IdentityId == @event.Id).FirstOrDefault();

            if (user == null)
                throw new MedParkException("");

            user.FirstName = @event.FirstName;
            user.LastName = @event.LastName;

            _appUserContext.Update(user);
        }
    }
}
