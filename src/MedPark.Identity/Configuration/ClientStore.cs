﻿using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Identity.Configuration
{
    public class ClientStore : IClientStore
    {
        private MedParkContext _medparkContext;

        public ClientStore(MedParkContext context)
        {
            _medparkContext = context;
        }

        Task<Client> IClientStore.FindClientByIdAsync(string clientId)
        {
            throw new NotImplementedException();
        }
    }
}
