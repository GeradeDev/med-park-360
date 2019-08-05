using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Messages.Events
{
    public class OrderPaymentMethodUpdated : IEvent
    {
        public Guid OrderId { get; set; }
        public Guid PaymentMethodId { get; set; }

        [JsonConstructor]
        public OrderPaymentMethodUpdated(Guid orderId, Guid paymentMethodId)
        {
            OrderId = orderId;
            PaymentMethodId = paymentMethodId;
        }
    }
}
