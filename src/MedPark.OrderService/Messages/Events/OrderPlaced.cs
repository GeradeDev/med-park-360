using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Messages.Events
{
    public class OrderPlaced : IEvent
    {
        public Guid OrderId { get; private set; }
        public Guid BuyerId { get; private set; }
        public decimal OrderTotal { get; private set; }

        [JsonConstructor]
        public OrderPlaced(Guid orderId, Guid buyerId, decimal orderTotal)
        {
            OrderId = orderId;
            BuyerId = buyerId;
            OrderTotal = orderTotal;
        }
    }
}
