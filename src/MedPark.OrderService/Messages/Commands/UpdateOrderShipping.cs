using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Messages.Commands
{
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
