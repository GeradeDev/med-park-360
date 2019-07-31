using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Basket.Messaging.Events
{
    [MessageNamespace("customers")]
    public class CustomerCreated : IEvent
    {
        public Guid UserId { get; }

        [JsonConstructor]
        public CustomerCreated(Guid userid)
        {
            UserId = userid;
        }
    }
}
