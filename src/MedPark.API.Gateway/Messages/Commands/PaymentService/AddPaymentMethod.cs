using MedPark.Common.Messages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Payment.Messages.Commands.PaymentService
{
    [MessageNamespace("payment-service")]
    public class AddPaymentMethod : ICommand
    {
        public Guid Id { get; private set; }
        public Guid CustomerId { get; private set; }
        public int PaymentTypeId { get; private set; }
        public int PaymentCardType { get; private set; }
        public string PaymentCardNumber { get; private set; }
        public DateTime? PaymentCardExpiry { get; private set; }
        public string PaymentCardSecurityCode { get; private set; }

        [JsonConstructor]
        public AddPaymentMethod(Guid id, Guid customerId, int type, int paymentCardType, string paymentCardNumber, DateTime? paymentCardExpiry, string paymentCardSecurityCode)
        {
            Id = id;
            CustomerId = customerId;
            PaymentTypeId = type;
            PaymentCardType = paymentCardType;
            PaymentCardNumber = paymentCardNumber;
            PaymentCardExpiry = paymentCardExpiry;
            PaymentCardSecurityCode = paymentCardSecurityCode;
        }
    }
}
