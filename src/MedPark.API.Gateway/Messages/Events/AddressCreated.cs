using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Messages.Events
{
    public class AddressCreated : IEvent
    {
        public Guid Id { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public Int32 AddressType { get; set; }
        public Guid UserId { get; set; }

        public string PostalCode { get; set; }

        [JsonConstructor]
        public AddressCreated(Guid id, string line1, string line2, string line3, string postalCode, Int32 type, Guid userId)
        {
            Id = id;
            AddressLine1 = line1;
            AddressLine2 = line2;
            AddressLine3 = line3;
            PostalCode = postalCode;
            UserId = userId;
            AddressType = type;
        }
    }
}
