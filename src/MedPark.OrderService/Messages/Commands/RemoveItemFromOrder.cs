using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Messages.Commands
{
    public class RemoveItemFromOrder : ICommand
    {
        public Guid OrderId { get; set; }
        public string ProductCode { get; set; }

        [JsonConstructor]
        public RemoveItemFromOrder(Guid orderId, string productCode)
        {
            OrderId = orderId;
            ProductCode = productCode;
        }
    }
}
