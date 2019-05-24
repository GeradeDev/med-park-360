﻿using DShop.Common.Messages;
using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.CustomersService.Messages.Events
{
    [MessageNamespace("identity")]
    public class SignedUp : IEvent
    {
        public Guid UserId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        [JsonConstructor]
        public SignedUp(Guid userid, string firstname, string lastname, string email)
        {
            UserId = userid;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
        }
    }
}
