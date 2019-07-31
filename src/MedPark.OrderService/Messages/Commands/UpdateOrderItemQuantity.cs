using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Messages.Commands
{
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
