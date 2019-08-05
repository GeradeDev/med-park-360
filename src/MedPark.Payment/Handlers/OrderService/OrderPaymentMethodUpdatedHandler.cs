using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Common.Types;
using MedPark.Payment.Domain;
using MedPark.Payment.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.Payment.Handlers.OrderService
{
    public class OrderPaymentMethodUpdatedHandler : IEventHandler<OrderPaymentMethodUpdated>
    {
        private IMedParkRepository<OrderPayment> _orderPayment { get; }

        public OrderPaymentMethodUpdatedHandler(IMedParkRepository<OrderPayment> orderPayment)
        {
            _orderPayment = orderPayment;
        }

        public async Task HandleAsync(OrderPaymentMethodUpdated @event, ICorrelationContext context)
        {
            OrderPayment op = await _orderPayment.GetAsync(@event.OrderId);

            if (op is null)
                throw new MedParkException("order_payment_does_not_exist", $"Order payment for order {@event.OrderId} does not exist.");

            op.SetPaymentType(@event.PaymentMethodId);

            await _orderPayment.UpdateAsync(op);

            //Proceed with executing payment
        }
    }
}
