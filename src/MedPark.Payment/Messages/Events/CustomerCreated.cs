using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Payment.Messages.Events
{
    [MessageNamespace("customers")]
    public class CustomerCreated : IEvent
    {
        public Guid UserId { get; }
        public string FirstName { get; }
        public string LastName { get; }

        [JsonConstructor]
        public CustomerCreated(Guid userid, string firstname, string lastname, string email, string mobile)
        {
            UserId = userid;
            FirstName = firstname;
            LastName = lastname;
        }
    }
}
