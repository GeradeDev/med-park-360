using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Payment.Messages.Events
{
    [MessageNamespace("ordering-service")]
    public class OrderPlaced : IEvent
    {
        public Guid OrderId { get; set; }
        public Guid BuyerId { get; set; }

        [JsonConstructor]
        public OrderPlaced(Guid orderId, Guid buyerId)
        {
            OrderId = orderId;
            BuyerId = buyerId;
        }
    }
}
