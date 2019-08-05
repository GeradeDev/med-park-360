using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Messages.Commands.OrderService
{
    [MessageNamespace("order-service")]
    public class UpdateOrderShipping : ICommand
    {
        public Guid OrderId { get; }
        public int ShippingType { get; }
        public Guid AddressId { get; }

        [JsonConstructor]
        public UpdateOrderShipping(Guid orderId,int shippingType, Guid addressId)
        {
            OrderId = orderId;
            ShippingType = shippingType;
            AddressId = addressId;
        }
    }
}
