using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.API.Gateway.Messages.Commands.OrderService
{
    [MessageNamespace("order-service")]
    public class UpdateOrderItemQuantity : ICommand
    {
        public Guid OrderId { get; }
        public string ProductCode { get; }
        public int Quantity { get; }

        [JsonConstructor]
        public UpdateOrderItemQuantity(Guid orderId, string productCode, int quantity)
        {
            OrderId = orderId;
            ProductCode = productCode;
            Quantity = quantity;
        }
    }
}
