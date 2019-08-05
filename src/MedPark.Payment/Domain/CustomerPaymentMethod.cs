using MedPark.Common;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Payment.Domain
{
    public class CustomerPaymentMethod : BaseIdentifiable
    {
        public CustomerPaymentMethod(Guid id) : base(id)
        {

        }

        public Guid CustomerId { get; private set; }
        public Guid PaymentTypeId { get; private set; }

        public int PaymentCardType { get; private set; }
        public string PaymentCardNumber { get; private set; }
        public DateTime? PaymentCardExpiry { get; private set; }
        public string PaymentCardSecurityCode { get; private set; }

        public void SetCustomer(Guid customerId)
        {
            CustomerId = customerId;
        }

        public void SetPaymentType(Guid type)
        {
            PaymentTypeId = type;
        }

        public void SetOnlinePaymentDetails(int paymentCardType, string paymentCardNumber, DateTime? paymentCardExpiry, string paymentCardSecurityCode)
        {
            PaymentCardType = paymentCardType;
            PaymentCardNumber = paymentCardNumber;
            PaymentCardExpiry = paymentCardExpiry;
            PaymentCardSecurityCode = paymentCardSecurityCode;
        }

        public override void Use()
        {
            if (CustomerId == Guid.Empty)
                throw new MedParkException("customer_invalid_create_payment_method", $"The customer Id may not be empty");

            if (PaymentTypeId == Guid.Empty)
                throw new MedParkException("payment_type_invalid_create_payment_method", "The payment type Id may not be empty");

            if (PaymentCardType == 0 || string.IsNullOrEmpty(PaymentCardNumber) || string.IsNullOrEmpty(PaymentCardSecurityCode))
                throw new MedParkException("payment_type_online_details_invalid_create_payment_method", $"Online payment type details is not valid.");

            UpdatedModified();
        }
    }
}
