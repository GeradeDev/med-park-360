using MedPark.Common;
using MedPark.Common.Enums;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Common.Types;
using MedPark.Payment.Domain;
using MedPark.Payment.Messages.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Payment.Handlers.Payment
{
    public class AddPaymentMethodHandler : ICommandHandler<AddPaymentMethod>
    {
        private IMedParkRepository<Customer> _buyerRepo { get; }
        private IMedParkRepository<PaymentType> _paymentTypeRepo { get; }
        private IMedParkRepository<CustomerPaymentMethod> _paymentMethodsRepo { get; }

        public AddPaymentMethodHandler(IMedParkRepository<Customer> buyerRepo, IMedParkRepository<CustomerPaymentMethod> paymentMethodsRepo, IMedParkRepository<PaymentType> paymentTypeRepo)
        {
            _buyerRepo = buyerRepo;
            _paymentMethodsRepo = paymentMethodsRepo;
            _paymentTypeRepo = paymentTypeRepo;
        }

        public async Task HandleAsync(AddPaymentMethod @event, ICorrelationContext context)
        {
            Customer buyer = await _buyerRepo.GetAsync(@event.CustomerId);

            if (buyer is null)
                throw new MedParkException("customer_does_not_exist", $"Buyer {@event.CustomerId} does not exist.");


            CustomerPaymentMethod newPaymentMethod = new CustomerPaymentMethod(@event.Id);
            newPaymentMethod.SetCustomer(@event.CustomerId);

            OrderPaymentType paymentType = (OrderPaymentType)@event.PaymentTypeId;

            PaymentType payType = await _paymentTypeRepo.GetAsync(x => x.Name == paymentType.ToString().Replace("_", " "));

            if (payType is null)
                throw new MedParkException("payment_type_does_not_exist", $"Payment type {@event.PaymentTypeId} does not exist.");

            newPaymentMethod.SetPaymentType(payType.Id);

            switch(paymentType)
            {
                case OrderPaymentType.Online:
                    {
                        //Online payment method, set card details
                        newPaymentMethod.SetOnlinePaymentDetails(@event.PaymentCardType, @event.PaymentCardNumber, @event.PaymentCardExpiry, @event.PaymentCardSecurityCode);
                    }
                    break;
            }

            newPaymentMethod.Use();

            //Save the payment method for the customer
            await _paymentMethodsRepo.AddAsync(newPaymentMethod);
        }
    }
}
