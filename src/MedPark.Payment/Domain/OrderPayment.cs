using MedPark.Common;
using MedPark.Common.Enums;
using MedPark.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Payment.Domain
{
    public class OrderPayment : BaseIdentifiable
    {
        public OrderPayment(Guid id) : base(id)
        {
            PaymentStatus = (int)OrderPaymentStatus.Awaiting_Confirmation;
        }

        public Guid OrderId { get; private set; }
        public Guid CustomerId { get; private set; }
        public Guid? OrderPaymentTypeId { get; private set; }
        public decimal OrderTotal { get; private set; }
        public int PaymentStatus { get; private set; }

        public void Create(Guid orderId, Guid customerId, decimal total)
        {
            OrderId = orderId;
            CustomerId = customerId;
            OrderTotal = total;
        }

        public void SetPaymentType(Guid paymentTypeId)
        {
            OrderPaymentTypeId = paymentTypeId;
        }

        public override void Use()
        {
            if (OrderId == Guid.Empty)
                throw new MedParkException("order_payment_order_invalid", $"The order for this order payment is not valid");

            if (CustomerId == Guid.Empty)
                throw new MedParkException("order_payment_customer_invalid", $"The customer Id may not be empty");

            if (OrderPaymentTypeId == Guid.Empty && PaymentStatus != (int)OrderPaymentStatus.Awaiting_Confirmation)
                throw new MedParkException("order_payment_customer_payment_type_invalid", $"The customer payment method Id for this order is not valid.");

            if (OrderTotal <= 0)
                throw new MedParkException("order_payment_order_total_invalid", $"The order total for this order payment is valid");

            UpdatedModified();
        }
    }
}
