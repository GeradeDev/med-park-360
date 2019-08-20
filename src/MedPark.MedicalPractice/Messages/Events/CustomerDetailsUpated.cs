using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.MedicalPractice.Messages.Events
{
    [MessageNamespace("customers")]
    public class CustomerDetailsUpated : IEvent
    {
        public Guid Id { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Mobile { get; private set; }

        [JsonConstructor]
        public CustomerDetailsUpated(Guid id, string firstname, string lastname, string email, string mobile)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Mobile = mobile;
        }
    }
}
