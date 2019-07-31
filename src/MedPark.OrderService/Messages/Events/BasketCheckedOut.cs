using MedPark.Common.Messages;
using MedPark.OrderService.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Messages.Events
{
    [MessageNamespace("basket-service")]
    public class BasketCheckedOut : IEvent
    {
        public Guid CustomerId { get; set; }
        public IEnumerable<LineItemDto> Items { get; set; }
        public int ShippingType { get; private set; }
        public Guid ShippingAddress { get; private set; }

        [JsonConstructor]
        public BasketCheckedOut(Guid buyerId, int shippingType, Guid shippingAddress)
        {
            CustomerId = buyerId;
            ShippingType = shippingType;
            ShippingAddress = shippingAddress;
        }
    }
}
