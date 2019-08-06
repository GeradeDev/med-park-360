using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Messages.Events
{
    [MessageNamespace("customers")]
    public class AddressCreated : IEvent
    {
        public Guid Id { get;}
        public DateTime Modified { get;}

        public string AddressLine1 { get;}
        public string AddressLine2 { get;}
        public string AddressLine3 { get;}
        public Int32 AddressType { get;}
        public Guid UserId { get;}

        public string PostalCode { get;}

        [JsonConstructor]
        public AddressCreated(Guid id, string addressLine1, string addressLine2, string addressLine3, string postalCode, Int32 addressType, Guid userId)
        {
            Id = id;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            AddressLine3 = addressLine3;
            PostalCode = postalCode;
            UserId = userId;
            AddressType = addressType;
        }
    }
}
