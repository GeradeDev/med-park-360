using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Messages.Commands
{
    public class UpdateOrderPayment
    {
        public Guid OrderId { get; set; }
        public int PaymentMethod { get; set; }
        public string PaymentCardType { get; set; }
        public string PaymentCardNumber { get; set; }
        public DateTime PaymentCardExpiry { get; set; }
        public string PaymentCardSecurityCode { get; set; }

        [JsonConstructor]
        public UpdateOrderPayment(Guid orderId, int paymentMethod, string paymentCardType, string paymentCardNumber, DateTime paymentCardExpiry, string paymentCardSecurityCode)
        {
            OrderId = orderId;
        }
    }
}
