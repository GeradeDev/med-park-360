using MedPark.Common;
using MedPark.Common.Handlers;
using MedPark.Common.RabbitMq;
using MedPark.Common.Types;
using MedPark.OrderService.Domain;
using MedPark.OrderService.Messages.Commands;
using MedPark.OrderService.Messages.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedPark.OrderService.Handlers.OrderService
{
    public class UpdateOrderPaymentHandler : ICommandHandler<UpdateOrderPayment>
    {
        private IMedParkRepository<Order> _orderRepo { get; }
        private IBusPublisher _busPublisher { get; }

        public UpdateOrderPaymentHandler(IMedParkRepository<Order> orderRepo, IBusPublisher busPublisher)
        {
            _orderRepo = orderRepo;
            _busPublisher = busPublisher;
        }

        public async Task HandleAsync(UpdateOrderPayment command, ICorrelationContext context)
        {
            Order o = await _orderRepo.GetAsync(command.OrderId);

            if (o is null)
                throw new MedParkException("update_payment_order_does_not_exist", $"Order {command.OrderId} does not exist.");

            o.SetPaymentMethod(command.PaymentMethodId);

            await _orderRepo.UpdateAsync(o);


            //Publish ordrr payment update event
            OrderPaymentMethodUpdated paymentMethodUpdated = new OrderPaymentMethodUpdated(o.Id, command.PaymentMethodId);
            await _busPublisher.PublishAsync<OrderPaymentMethodUpdated>(paymentMethodUpdated, null);
        }
    }
}
